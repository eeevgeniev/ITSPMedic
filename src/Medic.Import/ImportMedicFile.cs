﻿using Medic.Contexts;
using Medic.Entities;
using Medic.Import.Contracts;
using Medic.Import.Rules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Medic.Import
{
    public class ImportMedicFile : IImportMedicFile
    {
        private readonly MedicContext MedicContext;

        private bool _isDisposed = false;
        private bool _areHelpLibrariesLoaded = false;

        private HashSet<Provider> _providers;
        private HashSet<TherapyType> _therapyTypes;
        private HashSet<PatientBranch> _patientBranches;
        private HashSet<Patient> _patients;
        private HashSet<HealthcarePractitioner> _healthcarePractitioners;
        private HashSet<Practice> _practices;
        private HashSet<FileType> _fileTypes;
        private HashSet<SenderType> _senderTypes;
        private HashSet<Sex> _sexes;
        private HashSet<HealthRegion> _healthRegions;
        private HashSet<SpecialtyType> _specialtyTypes;
        private HashSet<MKB> _mkbs;

        public ImportMedicFile(MedicContext medicContext)
        {
            MedicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));

            _providers = new HashSet<Provider>(new ProviderComparer());
            _therapyTypes = new HashSet<TherapyType>(new TherapyTypeComparer());
            _patientBranches = new HashSet<PatientBranch>(new PatientBranchComparer());
            _patients = new HashSet<Patient>(new PatientComparer());
            _healthcarePractitioners = new HashSet<HealthcarePractitioner>(new HealthcarePractitionerComparer());
            _practices = new HashSet<Practice>(new PracticeComparer());
            _fileTypes = new HashSet<FileType>(new FileTypeComparer());
            _senderTypes = new HashSet<SenderType>(new SenderTypeComparer());
            _sexes = new HashSet<Sex>(new SexComparer());
            _healthRegions = new HashSet<HealthRegion>(new HealthRegionComparer());
            _specialtyTypes = new HashSet<SpecialtyType>(new SpecialtyTypeComparer());
            _mkbs = new HashSet<MKB>(new MKBComparer());
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _providers = null;
                _therapyTypes = null;
                _patientBranches = null;
                _patients = null;
                _healthcarePractitioners = null;
                _practices = null;
                _fileTypes = null;
                _senderTypes = null;
                _sexes = null;
                _healthRegions = null;
                _specialtyTypes = null;
                _mkbs = null;

                _isDisposed = !_isDisposed;
                GC.SuppressFinalize(this);
            }
        }

        public CPFile ImportCPFile(CPFile cpFile)
        {
            if (cpFile == default)
            {
                throw new ArgumentNullException(nameof(cpFile));
            }

            if (!_areHelpLibrariesLoaded)
            {
                LoadHelpData();
                _areHelpLibrariesLoaded = !_areHelpLibrariesLoaded;
            }

            cpFile.FileType = AddFileType(cpFile.FileType);
            cpFile.Practice = AddPractice(cpFile.Practice);

            foreach (PlannedProcedure plannedProcedure in cpFile.PlannedProcedures)
            {
                plannedProcedure.Patient = AddPatient(plannedProcedure.Patient);
                plannedProcedure.PatientBranch = AddPatientBarch(plannedProcedure.PatientBranch);
                plannedProcedure.Sender = AddHealthcarePractitioner(plannedProcedure.Sender);
                plannedProcedure.PatientHRegion = AddHealthRegion(plannedProcedure.PatientHRegion);

                if (plannedProcedure.Diagnose != default)
                {
                    plannedProcedure.Diagnose.Primary = AddMKB(plannedProcedure.Diagnose.Primary);
                    plannedProcedure.Diagnose.Secondary = AddMKB(plannedProcedure.Diagnose.Secondary);
                }

                if (plannedProcedure.SendDiagnose != default)
                {
                    plannedProcedure.SendDiagnose.Primary = AddMKB(plannedProcedure.SendDiagnose.Primary);
                    plannedProcedure.SendDiagnose.Secondary = AddMKB(plannedProcedure.SendDiagnose.Secondary);
                }
            }

            foreach (In currentIn in cpFile.Ins)
            {
                currentIn.Patient = AddPatient(currentIn.Patient);
                currentIn.PatientBranch = AddPatientBarch(currentIn.PatientBranch);
                currentIn.Sender = AddHealthcarePractitioner(currentIn.Sender);
                currentIn.PatientHRegion = AddHealthRegion(currentIn.PatientHRegion);

                if (currentIn.SendDiagnose != default)
                {
                    currentIn.SendDiagnose.Primary = AddMKB(currentIn.SendDiagnose.Primary);
                    currentIn.SendDiagnose.Secondary = AddMKB(currentIn.SendDiagnose.Secondary);
                }

                foreach (Diagnose diagnose in currentIn.Diagnoses)
                {
                    if (diagnose != default)
                    {
                        diagnose.Primary = AddMKB(diagnose.Primary);
                        diagnose.Secondary = AddMKB(diagnose.Secondary);
                    }
                }
            }

            foreach (Out currentOut in cpFile.Outs)
            {
                currentOut.Patient = AddPatient(currentOut.Patient);
                currentOut.PatientBranch = AddPatientBarch(currentOut.PatientBranch);
                currentOut.Sender = AddHealthcarePractitioner(currentOut.Sender);
                currentOut.PatientHRegion = AddHealthRegion(currentOut.PatientHRegion);

                foreach (Procedure procedure in currentOut.Procedures)
                {
                    if (procedure.Implant != default)
                    {
                        procedure.Implant.Provider = AddProvider(procedure.Implant.Provider);
                    }
                }

                if (currentOut.Epicrisis != default)
                {
                    foreach (HealthcarePractitionerEpicrisis sender in currentOut.Epicrisis.HealthcarePractitionerEpicrisises)
                    {
                        sender.HealthcarePractitioner = AddHealthcarePractitioner(sender.HealthcarePractitioner);
                    }
                }

                if (currentOut.OutMainDiagnose != default)
                {
                    currentOut.OutMainDiagnose.Primary = AddMKB(currentOut.OutMainDiagnose.Primary);
                    currentOut.OutMainDiagnose.Secondary = AddMKB(currentOut.OutMainDiagnose.Secondary);
                }

                if (currentOut.SendDiagnose != default)
                {
                    currentOut.SendDiagnose.Primary = AddMKB(currentOut.SendDiagnose.Primary);
                    currentOut.SendDiagnose.Secondary = AddMKB(currentOut.SendDiagnose.Secondary);
                }

                if (currentOut.Dead != default)
                {
                    currentOut.Dead.Primary = AddMKB(currentOut.Dead.Primary);
                    currentOut.Dead.Secondary = AddMKB(currentOut.Dead.Secondary);
                }

                foreach (Diagnose diagnose in currentOut.Diagnoses)
                {
                    if (diagnose != default)
                    {
                        diagnose.Primary = AddMKB(diagnose.Primary);
                        diagnose.Secondary = AddMKB(diagnose.Secondary);
                    }
                }

                foreach (Diagnose diagnose in currentOut.OutDiagnoses)
                {
                    if (diagnose != default)
                    {
                        diagnose.Primary = AddMKB(diagnose.Primary);
                        diagnose.Secondary = AddMKB(diagnose.Secondary);
                    }
                }
            }

            foreach (ProtocolDrugTherapy protocolDrugTherapy in cpFile.ProtocolDrugTherapies)
            {
                protocolDrugTherapy.Patient = AddPatient(protocolDrugTherapy.Patient);
                protocolDrugTherapy.PatientHRegion = AddHealthRegion(protocolDrugTherapy.PatientHRegion);
                protocolDrugTherapy.PatientBranch = AddPatientBarch(protocolDrugTherapy.PatientBranch);
                protocolDrugTherapy.Chairman = AddHealthcarePractitioner(protocolDrugTherapy.Chairman);
                protocolDrugTherapy.Practice = AddPractice(protocolDrugTherapy.Practice);

                foreach (AccompanyingDrug accompanyingDrug in protocolDrugTherapy.AccompanyingDrugs)
                {
                    accompanyingDrug.TherapyType = AddTherapyType(accompanyingDrug.TherapyType);
                }

                foreach (DrugProtocol drugProtocol in protocolDrugTherapy.DrugProtocols)
                {
                    drugProtocol.TherapyType = AddTherapyType(drugProtocol.TherapyType);
                }

                if (protocolDrugTherapy.Members != default)
                {
                    foreach (ProtocolDrugTherapyHealthPractitioner member in protocolDrugTherapy.Members)
                    {
                        member.HealthcarePractitioner = AddHealthcarePractitioner(member.HealthcarePractitioner);
                    }
                }

                if (protocolDrugTherapy.Diag != default)
                {
                    protocolDrugTherapy.Diag.MKB = AddMKB(protocolDrugTherapy.Diag.MKB);
                    protocolDrugTherapy.Diag.LinkDMKB = AddMKB(protocolDrugTherapy.Diag.LinkDMKB);
                }

                if (protocolDrugTherapy.ChemotherapyPart != default && protocolDrugTherapy.ChemotherapyPart.AddDiag != default)
                {
                    protocolDrugTherapy.ChemotherapyPart.AddDiag.MKB = AddMKB(protocolDrugTherapy.ChemotherapyPart.AddDiag.MKB);
                    protocolDrugTherapy.ChemotherapyPart.AddDiag.LinkDMKB = AddMKB(protocolDrugTherapy.ChemotherapyPart.AddDiag.LinkDMKB);
                }
            }

            foreach (PatientTransfer patientTransfer in cpFile.PatientTransfers)
            {
                if (patientTransfer.FirstMainDiag != default)
                {
                    patientTransfer.FirstMainDiag.MKB = AddMKB(patientTransfer.FirstMainDiag.MKB);
                    patientTransfer.FirstMainDiag.LinkDMKB = AddMKB(patientTransfer.FirstMainDiag.LinkDMKB);
                }

                if (patientTransfer.SecondMainDiag != default)
                {
                    patientTransfer.SecondMainDiag.MKB = AddMKB(patientTransfer.SecondMainDiag.MKB);
                    patientTransfer.SecondMainDiag.LinkDMKB = AddMKB(patientTransfer.SecondMainDiag.LinkDMKB);
                }
            }

            MedicContext.CPFiles.Add(cpFile);

            MedicContext.SaveChanges();

            return cpFile;
        }

        public HospitalPractice ImportHospitalPractice(HospitalPractice hospitalPractice)
        {
            if (hospitalPractice == default)
            {
                throw new ArgumentNullException(nameof(hospitalPractice));
            }

            if (!_areHelpLibrariesLoaded)
            {
                LoadHelpData();
                _areHelpLibrariesLoaded = !_areHelpLibrariesLoaded;
            }

            hospitalPractice.FileType = AddFileType(hospitalPractice.FileType);
            hospitalPractice.HealthRegion = AddHealthRegion(hospitalPractice.HealthRegion);
            hospitalPractice.Practice = AddPractice(hospitalPractice.Practice);

            foreach (InClinicProcedure inClinicProcedure in hospitalPractice.InClinicProcedures)
            {
                inClinicProcedure.Patient = AddPatient(inClinicProcedure.Patient);
                inClinicProcedure.PatientHealthRegion = AddHealthRegion(inClinicProcedure.PatientHealthRegion);
                inClinicProcedure.PatientBranch = AddPatientBarch(inClinicProcedure.PatientBranch);
                inClinicProcedure.Sender = AddHealthcarePractitioner(inClinicProcedure.Sender);

                if (inClinicProcedure.FirstMainDiag != null)
                {
                    inClinicProcedure.FirstMainDiag.MKB = AddMKB(inClinicProcedure.FirstMainDiag.MKB);
                    inClinicProcedure.FirstMainDiag.LinkDMKB = AddMKB(inClinicProcedure.FirstMainDiag.LinkDMKB);
                }

                if (inClinicProcedure.SecondMainDiag != null)
                {
                    inClinicProcedure.SecondMainDiag.MKB = AddMKB(inClinicProcedure.SecondMainDiag.MKB);
                    inClinicProcedure.SecondMainDiag.LinkDMKB = AddMKB(inClinicProcedure.SecondMainDiag.LinkDMKB);
                }
            }

            foreach (PathProcedure pathProcedure in hospitalPractice.PathProcedures)
            {
                pathProcedure.Patient = AddPatient(pathProcedure.Patient);
                pathProcedure.PatientHRegion = AddHealthRegion(pathProcedure.PatientHRegion);
                pathProcedure.PatientBranch = AddPatientBarch(pathProcedure.PatientBranch);
                pathProcedure.Sender = AddHealthcarePractitioner(pathProcedure.Sender);

                foreach (DoneProcedure doneProcedure in pathProcedure.DoneProcedures)
                {
                    doneProcedure.Doctor = AddHealthcarePractitioner(doneProcedure.Doctor);
                }

                if (pathProcedure.FirstMainDiag != null)
                {
                    pathProcedure.FirstMainDiag.MKB = AddMKB(pathProcedure.FirstMainDiag.MKB);
                    pathProcedure.FirstMainDiag.LinkDMKB = AddMKB(pathProcedure.FirstMainDiag.LinkDMKB);
                }

                if (pathProcedure.SecondMainDiag != null)
                {
                    pathProcedure.SecondMainDiag.MKB = AddMKB(pathProcedure.SecondMainDiag.MKB);
                    pathProcedure.SecondMainDiag.LinkDMKB = AddMKB(pathProcedure.SecondMainDiag.LinkDMKB);
                }
            }

            foreach (DispObservation dispObservation in hospitalPractice.DispObservations)
            {
                dispObservation.Patient = AddPatient(dispObservation.Patient);
                dispObservation.PatientHRegion = AddHealthRegion(dispObservation.PatientHRegion);
                dispObservation.PatientBranch = AddPatientBarch(dispObservation.PatientBranch);
                dispObservation.Sender = AddHealthcarePractitioner(dispObservation.Sender);
                dispObservation.Doctor = AddHealthcarePractitioner(dispObservation.Doctor);

                if (dispObservation.FirstMainDiag != default)
                {
                    dispObservation.FirstMainDiag.MKB = AddMKB(dispObservation.FirstMainDiag.MKB);
                    dispObservation.FirstMainDiag.LinkDMKB = AddMKB(dispObservation.FirstMainDiag.LinkDMKB);
                }

                if (dispObservation.SecondMainDiag != default)
                {
                    dispObservation.SecondMainDiag.MKB = AddMKB(dispObservation.SecondMainDiag.MKB);
                    dispObservation.SecondMainDiag.LinkDMKB = AddMKB(dispObservation.SecondMainDiag.LinkDMKB);
                }
            }

            foreach (CommissionApr commissionApr in hospitalPractice.CommissionAprs)
            {
                commissionApr.Patient = AddPatient(commissionApr.Patient);
                commissionApr.PatientHRegion = AddHealthRegion(commissionApr.PatientHRegion);
                commissionApr.PatientBranch = AddPatientBarch(commissionApr.PatientBranch);
                commissionApr.Sender = AddHealthcarePractitioner(commissionApr.Sender);
                commissionApr.Chairman = AddHealthcarePractitioner(commissionApr.Chairman);

                foreach (CommissionAprHealthcarePractitioner practitioner in commissionApr.Members)
                {
                    practitioner.HealthcarePractitioner = AddHealthcarePractitioner(practitioner.HealthcarePractitioner);
                }

                if (commissionApr.MainDiag != default)
                {
                    commissionApr.MainDiag.MKB = AddMKB(commissionApr.MainDiag.MKB);
                    commissionApr.MainDiag.LinkDMKB = AddMKB(commissionApr.MainDiag.LinkDMKB);
                }

                foreach (Diag diag in commissionApr.AddDiag)
                {
                    diag.MKB = AddMKB(diag.MKB);
                    diag.LinkDMKB = AddMKB(diag.LinkDMKB);
                }
            }

            foreach (ProtocolDrugTherapy protocolDrugTherapy in hospitalPractice.ProtocolDrugTherapies)
            {
                protocolDrugTherapy.Patient = AddPatient(protocolDrugTherapy.Patient);
                protocolDrugTherapy.PatientHRegion = AddHealthRegion(protocolDrugTherapy.PatientHRegion);
                protocolDrugTherapy.PatientBranch = AddPatientBarch(protocolDrugTherapy.PatientBranch);
                protocolDrugTherapy.Chairman = AddHealthcarePractitioner(protocolDrugTherapy.Chairman);
                protocolDrugTherapy.Practice = AddPractice(protocolDrugTherapy.Practice);

                foreach (ProtocolDrugTherapyHealthPractitioner practitioner in protocolDrugTherapy.Members)
                {
                    practitioner.HealthcarePractitioner = AddHealthcarePractitioner(practitioner.HealthcarePractitioner);
                }

                foreach (AccompanyingDrug accompanyingDrug in protocolDrugTherapy.AccompanyingDrugs)
                {
                    accompanyingDrug.TherapyType = AddTherapyType(accompanyingDrug.TherapyType);
                }

                foreach (DrugProtocol drugProtocol in protocolDrugTherapy.DrugProtocols)
                {
                    drugProtocol.TherapyType = AddTherapyType(drugProtocol.TherapyType);
                }

                if (protocolDrugTherapy.Diag != default)
                {
                    protocolDrugTherapy.Diag.MKB = AddMKB(protocolDrugTherapy.Diag.MKB);
                    protocolDrugTherapy.Diag.LinkDMKB = AddMKB(protocolDrugTherapy.Diag.LinkDMKB);
                }

                if (protocolDrugTherapy.ChemotherapyPart != default && protocolDrugTherapy.ChemotherapyPart.AddDiag != default)
                {
                    protocolDrugTherapy.ChemotherapyPart.AddDiag.MKB = AddMKB(protocolDrugTherapy.ChemotherapyPart.AddDiag.MKB);
                    protocolDrugTherapy.ChemotherapyPart.AddDiag.LinkDMKB = AddMKB(protocolDrugTherapy.ChemotherapyPart.AddDiag.LinkDMKB);
                }
            }

            foreach (PatientTransfer patientTransfer in hospitalPractice.PatientTransfers)
            {
                if (patientTransfer.FirstMainDiag != default)
                {
                    patientTransfer.FirstMainDiag.MKB = AddMKB(patientTransfer.FirstMainDiag.MKB);
                    patientTransfer.FirstMainDiag.LinkDMKB = AddMKB(patientTransfer.FirstMainDiag.LinkDMKB);
                }

                if (patientTransfer.SecondMainDiag != default)
                {
                    patientTransfer.SecondMainDiag.MKB = AddMKB(patientTransfer.SecondMainDiag.MKB);
                    patientTransfer.SecondMainDiag.LinkDMKB = AddMKB(patientTransfer.SecondMainDiag.LinkDMKB);
                }
            }

            MedicContext.HospitalPractices.Add(hospitalPractice);

            MedicContext.SaveChanges();

            return hospitalPractice;
        }

        private void LoadHelpData()
        {
            _providers.UnionWith(MedicContext.Providers.ToList());
            _therapyTypes.UnionWith(MedicContext.TherapyTypes.ToList());
            _patientBranches.UnionWith(MedicContext.PatientBranches.Include(pb => pb.HealthRegion).ToList());
            _practices.UnionWith(MedicContext.Practices.ToList());
            _fileTypes.UnionWith(MedicContext.FileTypes.ToList());
            _senderTypes.UnionWith(MedicContext.SenderTypes.ToList());
            _specialtyTypes.UnionWith(MedicContext.SpecialtyTypes.ToList());
            _healthRegions.UnionWith(MedicContext.HealthRegions.ToList());
            _sexes.UnionWith(MedicContext.Sexes.ToList());
            _mkbs.UnionWith(MedicContext.MKBs.ToList());
        }

        private Patient AddPatient(Patient patient)
        {
            if (patient != default)
            {
                if (!_patients.TryGetValue(patient, out Patient currentPatient))
                {
                    HashSet<Patient> patients = MedicContext.Patients.Where(p => p.IdentityNumber == patient.IdentityNumber).ToHashSet();
                    currentPatient = patients.FirstOrDefault(p => DateTime.Equals(p.BirthDate, patient.BirthDate));

                    if (currentPatient == default)
                    {
                        _patients.Add(patient);
                    }
                    else
                    {
                        _patients.Add(currentPatient);
                        patient = currentPatient;
                    }
                }
                else
                {
                    patient = currentPatient;
                }

                patient.Sex = AddSex(patient.Sex);
            }

            return patient;
        }

        private Practice AddPractice(Practice practice)
        {
            if (practice != default)
            {
                _practices.Add(practice);
                _practices.TryGetValue(practice, out practice);

                practice.HealthRegion = AddHealthRegion(practice.HealthRegion);
            }

            return practice;
        }

        private HealthcarePractitioner AddHealthcarePractitioner(HealthcarePractitioner practitioner)
        {
            if (practitioner != default)
            {
                if (!_healthcarePractitioners.TryGetValue(practitioner, out HealthcarePractitioner currentPractitioner))
                {
                    HashSet<HealthcarePractitioner> healthcarePractitioners = MedicContext.HealthcarePractitioners.Where(hp => hp.UniqueIdentifier == practitioner.UniqueIdentifier).ToHashSet();
                    currentPractitioner = healthcarePractitioners.FirstOrDefault(p => string.Equals(p.Name, practitioner.Name));

                    if (currentPractitioner == default)
                    {
                        _healthcarePractitioners.Add(practitioner);
                    }
                    else
                    {
                        _healthcarePractitioners.Add(currentPractitioner);
                        practitioner = currentPractitioner;
                    }
                }
                else
                {
                    practitioner = currentPractitioner;
                }

                practitioner.Speciality = AddSpecialtyType(practitioner.Speciality);
                practitioner.HealthRegion = AddHealthRegion(practitioner.HealthRegion);
                practitioner.Practice = AddPractice(practitioner.Practice);
                practitioner.SenderType = AddSenderType(practitioner.SenderType);
            }

            return practitioner;
        }

        private Provider AddProvider(Provider provider)
        {
            if (provider != default)
            {
                _providers.Add(provider);
                _providers.TryGetValue(provider, out provider);
            }

            return provider;
        }

        private TherapyType AddTherapyType(TherapyType therapyType)
        {
            if (therapyType != default)
            {
                _therapyTypes.Add(therapyType);
                _therapyTypes.TryGetValue(therapyType, out therapyType);
            }

            return therapyType;
        }

        private PatientBranch AddPatientBarch(PatientBranch patientBranch)
        {
            if (patientBranch != default)
            {
                _patientBranches.Add(patientBranch);
                _patientBranches.TryGetValue(patientBranch, out patientBranch);

                patientBranch.HealthRegion = AddHealthRegion(patientBranch.HealthRegion);
            }

            return patientBranch;
        }

        private Sex AddSex(Sex sex)
        {
            if (sex != default)
            {
                _sexes.TryGetValue(sex, out sex);
            }

            return sex;
        }

        private HealthRegion AddHealthRegion(HealthRegion healthRegion)
        {
            if (healthRegion != default)
            {
                _healthRegions.TryGetValue(healthRegion, out healthRegion);
            }

            return healthRegion;
        }

        private SpecialtyType AddSpecialtyType(SpecialtyType specialtyType)
        {
            if (specialtyType != default)
            {
                _specialtyTypes.TryGetValue(specialtyType, out specialtyType);
            }

            return specialtyType;
        }

        private FileType AddFileType(FileType fileType)
        {
            if (fileType != default)
            {
                _fileTypes.Add(fileType);
                _fileTypes.TryGetValue(fileType, out fileType);
            }

            return fileType;
        }

        private SenderType AddSenderType(SenderType senderType)
        {
            if (senderType != default)
            {
                _senderTypes.Add(senderType);
                _senderTypes.TryGetValue(senderType, out senderType);
            }

            return senderType;
        }

        private MKB AddMKB(MKB mkb)
        {
            if (mkb != default)
            {
                _mkbs.Add(mkb);
                _mkbs.TryGetValue(mkb, out mkb);
            }

            return mkb;
        }
    }
}