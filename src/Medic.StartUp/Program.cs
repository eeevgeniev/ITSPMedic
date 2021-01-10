using Medic.Contexts;
using Medic.Contexts.Contracts;
using Medic.Contexts.Seeders;
using Medic.Entities;
using Medic.FileImport.Contracts;
using Medic.FileImport.Reader;
using Medic.FileImport.Writer;
using Medic.Import;
using Medic.Import.Contracts;
using Medic.Infrastructure;
using Medic.Mappers;
using Medic.Mappers.Contracts;
using Medic.XMLImportHelper;
using Medic.XMLParser;
using Medic.XMLParser.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text;
using CLPR = Medic.Models.CLPR;
using CP = Medic.Models.CP;

namespace Medic.FileImport
{
    class Program
    {
        private static IReadable consoleReader = new ConsoleReader();
        private static INotifiable consoleWriter = new ConsoleWriter();

        static void Main(string[] args)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddUserSecrets<Program>();
                configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

                IConfigurationRoot configuration = configurationBuilder.Build();

                DbContextOptionsBuilder<MedicContext> builder = new DbContextOptionsBuilder<MedicContext>();
                builder.UseSqlServer(configuration[Constants.ConnectionString]);
                builder.EnableSensitiveDataLogging();

                using MedicContext context = new MedicContext(builder.Options);
                IMedicContextSeeder medicContextSeeder = new MedicContextSeeder(context);
                medicContextSeeder.Seed();

                AMapperConfiguration mapConfiguration = new AMapperConfiguration();
                IMappable mapper = new AMapper(mapConfiguration.CreateConfiguration());

                string cpDirectory, clprDirectory;
                bool doesCpDirectoryExist = true, doesCLPRDirectoryExist = true;

                while (true)
                {
                    consoleWriter.Notify("Enter directory for CP files");
                    cpDirectory = consoleReader.Read();
                    consoleWriter.Notify("Enter directory for CLPR files");
                    clprDirectory = consoleReader.Read();

                    if (!string.IsNullOrWhiteSpace(cpDirectory))
                    {
                        doesCpDirectoryExist = Directory.Exists(cpDirectory);
                    }

                    if (!string.IsNullOrWhiteSpace(clprDirectory))
                    {
                        doesCLPRDirectoryExist = Directory.Exists(clprDirectory);
                    }

                    if (doesCpDirectoryExist && doesCLPRDirectoryExist)
                    {
                        break;
                    }
                    else
                    {
                        if (!doesCpDirectoryExist)
                        {
                            consoleWriter.Notify("CP directory does not exist.");
                        }

                        if (!doesCLPRDirectoryExist)
                        {
                            consoleWriter.Notify("CLPR directory does not exist.");
                        }
                    }

                    doesCpDirectoryExist = true;
                    doesCLPRDirectoryExist = true;
                }

                if (!string.IsNullOrWhiteSpace(cpDirectory))
                {
                    ReadCpFiles(mapper, builder, cpDirectory);
                }

                if (!string.IsNullOrWhiteSpace(clprDirectory))
                {
                    ReadCLPRFiles(mapper, builder, clprDirectory);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            consoleWriter.Notify("Press any key to exit.");
            Console.ReadKey();
        }

        private static void ReadCpFiles(IMappable mapper, DbContextOptionsBuilder<MedicContext> builder, string directoryPath)
        {
            string invalidCpFileMessage = "Invalid CP file.";

            string[] files = Directory.GetFiles(directoryPath, "*.xml");
            IMedicXmlParser medicXmlParser = new DefaultMedicXmlParser(new GetXmlParameters());

            int counter = 1;

            foreach (string file in files)
            {
                using FileStream sr = new FileStream(file, FileMode.Open, FileAccess.Read);

                CP.CPFile cpFile = medicXmlParser.ParseXML<CP.CPFile>(sr);

                if (cpFile != default)
                {
                    CPFile cpFileEntity = mapper.Map<CPFile, CP.CPFile>(cpFile);

                    if (cpFileEntity != default)
                    {
                        using MedicContext medicContext = new MedicContext(builder.Options);
                        using IImportMedicFile importMedicFile = new ImportMedicFile(medicContext);

                        importMedicFile.ImportCPFile(cpFileEntity);

                        consoleWriter.Notify($"{file} - imported, ({counter++}/{files.Length}).");
                    }
                    else
                    {
                        consoleWriter.Notify(invalidCpFileMessage);
                    }
                }
                else
                {
                    consoleWriter.Notify(invalidCpFileMessage);
                }
            }
        }

        private static void ReadCLPRFiles(IMappable mapper, DbContextOptionsBuilder<MedicContext> builder, string directoryPath)
        {
            string invalidCLPRFileMessage = "Invalid CLPR file.";


            string[] files = Directory.GetFiles(directoryPath, "*.xml");
            IMedicXmlParser medicXmlParser = new DefaultMedicXmlParser(new GetXmlParameters());

            int counter = 1;

            foreach (string file in files)
            {
                using FileStream sr = new FileStream(file, FileMode.Open, FileAccess.Read);

                CLPR.HospitalPractice clprFile = medicXmlParser.ParseXML<CLPR.HospitalPractice>(sr);

                if (clprFile != default)
                {
                    HospitalPractice hospitalPracticeEntity = mapper.Map<HospitalPractice, CLPR.HospitalPractice>(clprFile);

                    if (hospitalPracticeEntity != default)
                    {
                        using MedicContext medicContext = new MedicContext(builder.Options);
                        using IImportMedicFile importMedicFile = new ImportMedicFile(medicContext);

                        importMedicFile.ImportHospitalPractice(hospitalPracticeEntity);

                        consoleWriter.Notify($"{file} - imported, ({counter++}/{files.Length}).");
                    }
                    else
                    {
                        consoleWriter.Notify(invalidCLPRFileMessage);
                    }
                }
                else
                {
                    consoleWriter.Notify(invalidCLPRFileMessage);
                }
            }
        }
    }
}