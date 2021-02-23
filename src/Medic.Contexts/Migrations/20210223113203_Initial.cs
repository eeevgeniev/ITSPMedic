using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medic.Contexts.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mdc");

            migrationBuilder.CreateTable(
                name: "CeasedClinicals",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 20, nullable: true),
                    IZMedicalWard = table.Column<int>(nullable: false),
                    IZYearMedicalWard = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CeasedClinicals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Epicrises",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    History = table.Column<string>(nullable: true),
                    FairCondition = table.Column<string>(nullable: true),
                    ClinicalExaminations = table.Column<string>(nullable: true),
                    Consultations = table.Column<string>(nullable: true),
                    Regimen = table.Column<string>(nullable: true),
                    DiseaseCourse = table.Column<string>(nullable: true),
                    Complications = table.Column<string>(nullable: true),
                    DateOfSurgery = table.Column<DateTime>(nullable: true),
                    SampleProtocol = table.Column<string>(nullable: true),
                    PostoperativeStatus = table.Column<string>(nullable: true),
                    DischargeStatus = table.Column<string>(nullable: true),
                    Recommendations = table.Column<string>(nullable: true),
                    CheckupAfterDischarge = table.Column<string>(nullable: true),
                    GPRecommendations = table.Column<string>(nullable: true),
                    OtherDocuments = table.Column<string>(nullable: true),
                    DoctorsNames = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epicrises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileTypes",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthRegions",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    Code = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthRegions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistologicalResults",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 10, nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistologicalResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Histologies",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameHS = table.Column<string>(maxLength: 4000, nullable: true),
                    CodeHS = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImplantProductTypes",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    ProductType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImplantProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MKBs",
                schema: "mdc",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MKBs", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resigners",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutRefuse = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resigners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SenderTypes",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Code = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SenderTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sexes",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialtyTypes",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    SpecialtyCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialtyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TherapyTypes",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TherapyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VersionCodes",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchNumber = table.Column<string>(maxLength: 20, nullable: true),
                    ProductCode = table.Column<string>(maxLength: 14, nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: true),
                    SerialNumber = table.Column<string>(maxLength: 20, nullable: true),
                    DataMatrix = table.Column<string>(maxLength: 250, nullable: true),
                    QuantityPack = table.Column<decimal>(type: "decimal(15,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "APr38s",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    History = table.Column<string>(nullable: true),
                    FairCondition = table.Column<string>(maxLength: 4000, nullable: true),
                    Therapy = table.Column<string>(maxLength: 4000, nullable: true),
                    DecisionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APr38s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_APr38s_Evaluations_DecisionId",
                        column: x => x.DecisionId,
                        principalSchema: "mdc",
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    Checked = table.Column<int>(nullable: false),
                    Text = table.Column<string>(maxLength: 1000, nullable: true),
                    EvaluationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choices_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalSchema: "mdc",
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClinicChemotherapyParts",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ECOG = table.Column<int>(nullable: false),
                    TNM = table.Column<string>(maxLength: 100, nullable: true),
                    EvalutionId = table.Column<int>(nullable: true),
                    DecisionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicChemotherapyParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicChemotherapyParts_Evaluations_DecisionId",
                        column: x => x.DecisionId,
                        principalSchema: "mdc",
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClinicChemotherapyParts_Evaluations_EvalutionId",
                        column: x => x.EvalutionId,
                        principalSchema: "mdc",
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClinicHematologyParts",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageHemo = table.Column<string>(maxLength: 10, nullable: true),
                    OngoingTherapy = table.Column<int>(nullable: false),
                    EvalutionId = table.Column<int>(nullable: true),
                    DecisionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicHematologyParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicHematologyParts_Evaluations_DecisionId",
                        column: x => x.DecisionId,
                        principalSchema: "mdc",
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClinicHematologyParts_Evaluations_EvalutionId",
                        column: x => x.EvalutionId,
                        principalSchema: "mdc",
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HematologyParts",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PredMarkerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HematologyParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HematologyParts_Evaluations_PredMarkerId",
                        column: x => x.PredMarkerId,
                        principalSchema: "mdc",
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientBranches",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HealthRegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientBranches_HealthRegions_HealthRegionId",
                        column: x => x.HealthRegionId,
                        principalSchema: "mdc",
                        principalTable: "HealthRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Practices",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Branch = table.Column<int>(nullable: false),
                    Number = table.Column<string>(maxLength: 12, nullable: true),
                    Code = table.Column<string>(maxLength: 12, nullable: true),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    HealthRegionId = table.Column<int>(nullable: true),
                    Address = table.Column<string>(maxLength: 250, nullable: true),
                    NZOKCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Practices_HealthRegions_HealthRegionId",
                        column: x => x.HealthRegionId,
                        principalSchema: "mdc",
                        principalTable: "HealthRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChemotherapyParts",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiagnoseDate = table.Column<DateTime>(nullable: false),
                    ExpandDiagnose = table.Column<string>(maxLength: 4000, nullable: true),
                    HistologyId = table.Column<int>(nullable: true),
                    ECOG = table.Column<int>(nullable: false),
                    Staging = table.Column<string>(maxLength: 20, nullable: true),
                    StagingNumber = table.Column<int>(nullable: true),
                    TNM = table.Column<string>(maxLength: 100, nullable: true),
                    TargetAUC = table.Column<decimal>(type: "decimal(15,4)", nullable: true),
                    TherapyType = table.Column<int>(nullable: false),
                    EvalAfterCycle = table.Column<int>(nullable: false),
                    Interval = table.Column<int>(nullable: false),
                    EvaluationId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    ProtocolDrugTherapyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChemotherapyParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChemotherapyParts_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalSchema: "mdc",
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChemotherapyParts_Histologies_HistologyId",
                        column: x => x.HistologyId,
                        principalSchema: "mdc",
                        principalTable: "Histologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(maxLength: 50, nullable: true),
                    InstitutionId = table.Column<string>(maxLength: 100, nullable: true),
                    InstitutionName = table.Column<string>(maxLength: 100, nullable: true),
                    CertificateType = table.Column<string>(maxLength: 50, nullable: true),
                    DateTo = table.Column<DateTime>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: true),
                    DateIssue = table.Column<DateTime>(nullable: true),
                    EhicC = table.Column<string>(maxLength: 50, nullable: true),
                    PersonalIdNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Notes = table.Column<string>(maxLength: 200, nullable: true),
                    IdentityNumber = table.Column<string>(maxLength: 50, nullable: true),
                    NAPNumber = table.Column<string>(maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    LeadDocName = table.Column<string>(maxLength: 250, nullable: true),
                    LNCH = table.Column<string>(maxLength: 50, nullable: true),
                    SexId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    SecondName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 250, nullable: true),
                    PersonType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Sexes_SexId",
                        column: x => x.SexId,
                        principalSchema: "mdc",
                        principalTable: "Sexes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "APr05s",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiagnoseDate = table.Column<DateTime>(nullable: false),
                    HistologyId = table.Column<int>(nullable: false),
                    Staging = table.Column<string>(maxLength: 20, nullable: true),
                    StagingNumber = table.Column<int>(nullable: true),
                    PrognosticGroup = table.Column<int>(nullable: false),
                    Imuno = table.Column<string>(maxLength: 3000, nullable: true),
                    Genetic = table.Column<string>(maxLength: 2000, nullable: true),
                    ClinicChemotherapyPartId = table.Column<int>(nullable: true),
                    ClinicHematologyPartId = table.Column<int>(nullable: true),
                    Sign = table.Column<string>(maxLength: 50, nullable: true),
                    NZOKPay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APr05s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_APr05s_ClinicChemotherapyParts_ClinicChemotherapyPartId",
                        column: x => x.ClinicChemotherapyPartId,
                        principalSchema: "mdc",
                        principalTable: "ClinicChemotherapyParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_APr05s_ClinicHematologyParts_ClinicHematologyPartId",
                        column: x => x.ClinicHematologyPartId,
                        principalSchema: "mdc",
                        principalTable: "ClinicHematologyParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_APr05s_Histologies_HistologyId",
                        column: x => x.HistologyId,
                        principalSchema: "mdc",
                        principalTable: "Histologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CPFiles",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PracticeId = table.Column<int>(nullable: true),
                    FileTypeId = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CPFiles_FileTypes_FileTypeId",
                        column: x => x.FileTypeId,
                        principalSchema: "mdc",
                        principalTable: "FileTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPFiles_Practices_PracticeId",
                        column: x => x.PracticeId,
                        principalSchema: "mdc",
                        principalTable: "Practices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HealthcarePractitioners",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HealthRegionId = table.Column<int>(nullable: true),
                    PracticeId = table.Column<int>(nullable: true),
                    SenderTypeId = table.Column<int>(nullable: true),
                    UniqueIdentifier = table.Column<string>(maxLength: 12, nullable: true),
                    DeputyUniqueIdentifier = table.Column<string>(maxLength: 12, nullable: true),
                    SpecialityId = table.Column<int>(nullable: true),
                    ClinicalNumber = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    NZOKCode = table.Column<string>(maxLength: 12, nullable: true),
                    UINSubst = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthcarePractitioners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthcarePractitioners_HealthRegions_HealthRegionId",
                        column: x => x.HealthRegionId,
                        principalSchema: "mdc",
                        principalTable: "HealthRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HealthcarePractitioners_Practices_PracticeId",
                        column: x => x.PracticeId,
                        principalSchema: "mdc",
                        principalTable: "Practices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HealthcarePractitioners_SenderTypes_SenderTypeId",
                        column: x => x.SenderTypeId,
                        principalSchema: "mdc",
                        principalTable: "SenderTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HealthcarePractitioners_SpecialtyTypes_SpecialityId",
                        column: x => x.SpecialityId,
                        principalSchema: "mdc",
                        principalTable: "SpecialtyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HospitalPractices",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HealthRegionId = table.Column<int>(nullable: true),
                    PracticeId = table.Column<int>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    FileTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalPractices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalPractices_FileTypes_FileTypeId",
                        column: x => x.FileTypeId,
                        principalSchema: "mdc",
                        principalTable: "FileTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalPractices_HealthRegions_HealthRegionId",
                        column: x => x.HealthRegionId,
                        principalSchema: "mdc",
                        principalTable: "HealthRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HospitalPractices_Practices_PracticeId",
                        column: x => x.PracticeId,
                        principalSchema: "mdc",
                        principalTable: "Practices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenMarkers",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Sign = table.Column<int>(nullable: false),
                    ChemotherapyPartId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenMarkers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenMarkers_ChemotherapyParts_ChemotherapyPartId",
                        column: x => x.ChemotherapyPartId,
                        principalSchema: "mdc",
                        principalTable: "ChemotherapyParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ins",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: true),
                    PatientBranchId = table.Column<int>(nullable: true),
                    PatientHRegionId = table.Column<int>(nullable: true),
                    InType = table.Column<int>(nullable: false),
                    SenderId = table.Column<int>(nullable: true),
                    SendDate = table.Column<DateTime>(nullable: false),
                    SendUrgency = table.Column<int>(nullable: false),
                    SendPackageType = table.Column<int>(nullable: true),
                    SendAPr = table.Column<string>(maxLength: 10, nullable: true),
                    SendClinicalPath = table.Column<string>(maxLength: 10, nullable: true),
                    UniqueIdentifier = table.Column<string>(maxLength: 12, nullable: true),
                    ExaminationDate = table.Column<DateTime>(nullable: false),
                    PlannedEntryDate = table.Column<DateTime>(nullable: true),
                    PlannedNumber = table.Column<int>(nullable: true),
                    Urgency = table.Column<int>(nullable: false),
                    PackageType = table.Column<int>(nullable: true),
                    InAPr = table.Column<string>(maxLength: 10, nullable: true),
                    ClinicalPath = table.Column<string>(maxLength: 10, nullable: true),
                    NZOKPay = table.Column<int>(nullable: false),
                    InMedicalWard = table.Column<string>(maxLength: 10, nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    Severity = table.Column<int>(nullable: false),
                    Delay = table.Column<int>(nullable: true),
                    Payer = table.Column<int>(nullable: false),
                    AgeInDays = table.Column<int>(nullable: true),
                    WeightInGrams = table.Column<int>(nullable: true),
                    BirthWeight = table.Column<int>(nullable: true),
                    MotherIZYear = table.Column<int>(nullable: true),
                    MotherIZNo = table.Column<int>(nullable: true),
                    IZYear = table.Column<int>(nullable: true),
                    IZNo = table.Column<int>(nullable: true),
                    CPFileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ins_CPFiles_CPFileId",
                        column: x => x.CPFileId,
                        principalSchema: "mdc",
                        principalTable: "CPFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ins_PatientBranches_PatientBranchId",
                        column: x => x.PatientBranchId,
                        principalSchema: "mdc",
                        principalTable: "PatientBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ins_HealthRegions_PatientHRegionId",
                        column: x => x.PatientHRegionId,
                        principalSchema: "mdc",
                        principalTable: "HealthRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ins_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "mdc",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ins_HealthcarePractitioners_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "mdc",
                        principalTable: "HealthcarePractitioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Plannings",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: true),
                    PatientBranchId = table.Column<int>(nullable: true),
                    PatientHRegionId = table.Column<int>(nullable: true),
                    InType = table.Column<int>(nullable: false),
                    SenderId = table.Column<int>(nullable: true),
                    SendDate = table.Column<DateTime>(nullable: false),
                    SendUrgency = table.Column<int>(nullable: false),
                    SendPackageType = table.Column<int>(nullable: true),
                    SendClinicalPath = table.Column<string>(maxLength: 10, nullable: true),
                    SendAPr = table.Column<string>(maxLength: 10, nullable: true),
                    UniqueIdentifier = table.Column<string>(maxLength: 12, nullable: true),
                    ExaminationDate = table.Column<DateTime>(nullable: false),
                    PlannedEntryDate = table.Column<DateTime>(nullable: true),
                    PlannedNumber = table.Column<int>(nullable: true),
                    Urgency = table.Column<int>(nullable: false),
                    PackageType = table.Column<int>(nullable: true),
                    ClinicalPath = table.Column<string>(maxLength: 10, nullable: true),
                    InAPr = table.Column<string>(maxLength: 10, nullable: true),
                    NZOKPay = table.Column<int>(nullable: false),
                    CPFileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plannings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plannings_CPFiles_CPFileId",
                        column: x => x.CPFileId,
                        principalSchema: "mdc",
                        principalTable: "CPFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plannings_PatientBranches_PatientBranchId",
                        column: x => x.PatientBranchId,
                        principalSchema: "mdc",
                        principalTable: "PatientBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plannings_HealthRegions_PatientHRegionId",
                        column: x => x.PatientHRegionId,
                        principalSchema: "mdc",
                        principalTable: "HealthRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plannings_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "mdc",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plannings_HealthcarePractitioners_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "mdc",
                        principalTable: "HealthcarePractitioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DrugPacks",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrugDate = table.Column<DateTime>(nullable: true),
                    DrugCode = table.Column<string>(maxLength: 10, nullable: true),
                    DrugQuantity = table.Column<decimal>(type: "decimal(15,4)", nullable: true),
                    BatchNumber = table.Column<string>(maxLength: 30, nullable: true),
                    ProductCode = table.Column<string>(maxLength: 20, nullable: true),
                    ExpireDateAsString = table.Column<string>(maxLength: 6, nullable: true),
                    SerialNumber = table.Column<string>(maxLength: 20, nullable: true),
                    CPFileId = table.Column<int>(nullable: false),
                    HospitalPracticeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugPacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugPacks_CPFiles_CPFileId",
                        column: x => x.CPFileId,
                        principalSchema: "mdc",
                        principalTable: "CPFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugPacks_HospitalPractices_HospitalPracticeId",
                        column: x => x.HospitalPracticeId,
                        principalSchema: "mdc",
                        principalTable: "HospitalPractices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrugResidues",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrugDate = table.Column<DateTime>(nullable: true),
                    DrugCode = table.Column<string>(maxLength: 10, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(15,4)", nullable: true),
                    DrugCost = table.Column<decimal>(type: "decimal(15,4)", nullable: true),
                    ProductCode = table.Column<string>(maxLength: 20, nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: true),
                    BatchNumber = table.Column<string>(maxLength: 20, nullable: true),
                    SerialNumber = table.Column<string>(maxLength: 20, nullable: true),
                    CPFileId = table.Column<int>(nullable: true),
                    HospitalPracticeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugResidues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugResidues_CPFiles_CPFileId",
                        column: x => x.CPFileId,
                        principalSchema: "mdc",
                        principalTable: "CPFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DrugResidues_HospitalPractices_HospitalPracticeId",
                        column: x => x.HospitalPracticeId,
                        principalSchema: "mdc",
                        principalTable: "HospitalPractices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Markers",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: true),
                    Sign = table.Column<int>(nullable: false),
                    GenMarkerId = table.Column<int>(nullable: true),
                    EvaluationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Markers_Evaluations_EvaluationId",
                        column: x => x.EvaluationId,
                        principalSchema: "mdc",
                        principalTable: "Evaluations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Markers_GenMarkers_GenMarkerId",
                        column: x => x.GenMarkerId,
                        principalSchema: "mdc",
                        principalTable: "GenMarkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommissionAprs",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: true),
                    PatientBranchId = table.Column<int>(nullable: true),
                    PatientHRegionId = table.Column<int>(nullable: true),
                    SenderId = table.Column<int>(nullable: true),
                    AprSend = table.Column<string>(maxLength: 10, nullable: true),
                    SendDate = table.Column<DateTime>(nullable: false),
                    AprPriem = table.Column<string>(maxLength: 10, nullable: true),
                    SpecCommission = table.Column<int>(nullable: false),
                    NoDecision = table.Column<int>(nullable: false),
                    DecisionDate = table.Column<DateTime>(nullable: false),
                    ChairmanId = table.Column<int>(nullable: true),
                    MainDiagId = table.Column<int>(nullable: true),
                    HospitalPracticeId = table.Column<int>(nullable: true),
                    APr38Id = table.Column<int>(nullable: true),
                    APr05Id = table.Column<int>(nullable: true),
                    Sign = table.Column<int>(nullable: false),
                    NZOKPay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommissionAprs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommissionAprs_APr05s_APr05Id",
                        column: x => x.APr05Id,
                        principalSchema: "mdc",
                        principalTable: "APr05s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommissionAprs_APr38s_APr38Id",
                        column: x => x.APr38Id,
                        principalSchema: "mdc",
                        principalTable: "APr38s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommissionAprs_HealthcarePractitioners_ChairmanId",
                        column: x => x.ChairmanId,
                        principalSchema: "mdc",
                        principalTable: "HealthcarePractitioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommissionAprs_HospitalPractices_HospitalPracticeId",
                        column: x => x.HospitalPracticeId,
                        principalSchema: "mdc",
                        principalTable: "HospitalPractices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommissionAprs_PatientBranches_PatientBranchId",
                        column: x => x.PatientBranchId,
                        principalSchema: "mdc",
                        principalTable: "PatientBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommissionAprs_HealthRegions_PatientHRegionId",
                        column: x => x.PatientHRegionId,
                        principalSchema: "mdc",
                        principalTable: "HealthRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommissionAprs_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "mdc",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommissionAprs_HealthcarePractitioners_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "mdc",
                        principalTable: "HealthcarePractitioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommissionAprHealthcarePractitioner",
                schema: "mdc",
                columns: table => new
                {
                    HealthcarePractitionerId = table.Column<int>(nullable: false),
                    CommissionAprId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommissionAprHealthcarePractitioner", x => new { x.HealthcarePractitionerId, x.CommissionAprId });
                    table.ForeignKey(
                        name: "FK_CommissionAprHealthcarePractitioner_CommissionAprs_CommissionAprId",
                        column: x => x.CommissionAprId,
                        principalSchema: "mdc",
                        principalTable: "CommissionAprs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommissionAprHealthcarePractitioner_HealthcarePractitioners_HealthcarePractitionerId",
                        column: x => x.HealthcarePractitionerId,
                        principalSchema: "mdc",
                        principalTable: "HealthcarePractitioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diags",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeMD = table.Column<string>(maxLength: 500, nullable: true),
                    MKBCode = table.Column<string>(maxLength: 10, nullable: true),
                    LinkDName = table.Column<string>(maxLength: 500, nullable: true),
                    LinkDMKBCode = table.Column<string>(maxLength: 10, nullable: true),
                    ChemotherapyPartId = table.Column<int>(nullable: true),
                    CommissionAprId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diags_ChemotherapyParts_ChemotherapyPartId",
                        column: x => x.ChemotherapyPartId,
                        principalSchema: "mdc",
                        principalTable: "ChemotherapyParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diags_CommissionAprs_CommissionAprId",
                        column: x => x.CommissionAprId,
                        principalSchema: "mdc",
                        principalTable: "CommissionAprs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diags_MKBs_LinkDMKBCode",
                        column: x => x.LinkDMKBCode,
                        principalSchema: "mdc",
                        principalTable: "MKBs",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diags_MKBs_MKBCode",
                        column: x => x.MKBCode,
                        principalSchema: "mdc",
                        principalTable: "MKBs",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DispObservations",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: true),
                    PatientBranchId = table.Column<int>(nullable: true),
                    PatientHRegionId = table.Column<int>(nullable: true),
                    DoctorId = table.Column<int>(nullable: true),
                    DispNum = table.Column<int>(nullable: false),
                    DispDate = table.Column<DateTime>(nullable: false),
                    AprCode = table.Column<string>(maxLength: 10, nullable: true),
                    DiagDate = table.Column<DateTime>(nullable: false),
                    DispanserDate = table.Column<DateTime>(nullable: true),
                    DispVisit = table.Column<int>(nullable: false),
                    FirstCodeSpecConsult = table.Column<string>(maxLength: 5, nullable: true),
                    SecondCodeSpecConsult = table.Column<string>(maxLength: 5, nullable: true),
                    MainDiagFirstId = table.Column<int>(nullable: true),
                    MainDiagSecondId = table.Column<int>(nullable: true),
                    HospitalPracticeId = table.Column<int>(nullable: true),
                    Anamnesa = table.Column<string>(maxLength: 4000, nullable: true),
                    HState = table.Column<string>(maxLength: 4000, nullable: true),
                    Therapy = table.Column<string>(maxLength: 4000, nullable: true),
                    Sign = table.Column<int>(nullable: false),
                    NZOKPay = table.Column<int>(nullable: false),
                    HealthcarePractitionerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispObservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DispObservations_HealthcarePractitioners_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "mdc",
                        principalTable: "HealthcarePractitioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DispObservations_HealthcarePractitioners_HealthcarePractitionerId",
                        column: x => x.HealthcarePractitionerId,
                        principalSchema: "mdc",
                        principalTable: "HealthcarePractitioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DispObservations_HospitalPractices_HospitalPracticeId",
                        column: x => x.HospitalPracticeId,
                        principalSchema: "mdc",
                        principalTable: "HospitalPractices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DispObservations_Diags_MainDiagFirstId",
                        column: x => x.MainDiagFirstId,
                        principalSchema: "mdc",
                        principalTable: "Diags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DispObservations_Diags_MainDiagSecondId",
                        column: x => x.MainDiagSecondId,
                        principalSchema: "mdc",
                        principalTable: "Diags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DispObservations_PatientBranches_PatientBranchId",
                        column: x => x.PatientBranchId,
                        principalSchema: "mdc",
                        principalTable: "PatientBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DispObservations_HealthRegions_PatientHRegionId",
                        column: x => x.PatientHRegionId,
                        principalSchema: "mdc",
                        principalTable: "HealthRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DispObservations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "mdc",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InClinicProcedures",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: true),
                    PatientBranchId = table.Column<int>(nullable: true),
                    PatientHealthRegionId = table.Column<int>(nullable: true),
                    SenderId = table.Column<int>(nullable: true),
                    CPrSend = table.Column<string>(maxLength: 10, nullable: true),
                    APrSend = table.Column<string>(maxLength: 10, nullable: true),
                    TypeProcSend = table.Column<int>(nullable: true),
                    SendPackageType = table.Column<int>(nullable: true),
                    DateSend = table.Column<DateTime>(nullable: false),
                    CPrPriem = table.Column<string>(maxLength: 10, nullable: true),
                    APrPriem = table.Column<string>(maxLength: 10, nullable: true),
                    TypeProcPriem = table.Column<int>(nullable: true),
                    PackageType = table.Column<int>(nullable: true),
                    ProcRefuse = table.Column<int>(nullable: false),
                    CeasedClinicalPathId = table.Column<int>(nullable: true),
                    CeasedProcedureId = table.Column<int>(nullable: true),
                    CeasedOnlyId = table.Column<int>(nullable: true),
                    IZNumChild = table.Column<int>(nullable: true),
                    IZYearChild = table.Column<int>(nullable: false),
                    FirstVisitDate = table.Column<DateTime>(nullable: true),
                    PlanVisitDate = table.Column<DateTime>(nullable: true),
                    PlannedNumber = table.Column<int>(nullable: true),
                    VisitDoctorUniqueIdentifier = table.Column<string>(maxLength: 12, nullable: true),
                    VisitDoctorName = table.Column<string>(maxLength: 200, nullable: true),
                    FirstMainDiagId = table.Column<int>(nullable: true),
                    SecondMainDiagId = table.Column<int>(nullable: true),
                    PatientStatus = table.Column<int>(nullable: false),
                    NZOKPay = table.Column<int>(nullable: false),
                    HospitalPracticeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InClinicProcedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InClinicProcedures_CeasedClinicals_CeasedClinicalPathId",
                        column: x => x.CeasedClinicalPathId,
                        principalSchema: "mdc",
                        principalTable: "CeasedClinicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InClinicProcedures_CeasedClinicals_CeasedOnlyId",
                        column: x => x.CeasedOnlyId,
                        principalSchema: "mdc",
                        principalTable: "CeasedClinicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InClinicProcedures_CeasedClinicals_CeasedProcedureId",
                        column: x => x.CeasedProcedureId,
                        principalSchema: "mdc",
                        principalTable: "CeasedClinicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InClinicProcedures_Diags_FirstMainDiagId",
                        column: x => x.FirstMainDiagId,
                        principalSchema: "mdc",
                        principalTable: "Diags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InClinicProcedures_HospitalPractices_HospitalPracticeId",
                        column: x => x.HospitalPracticeId,
                        principalSchema: "mdc",
                        principalTable: "HospitalPractices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InClinicProcedures_PatientBranches_PatientBranchId",
                        column: x => x.PatientBranchId,
                        principalSchema: "mdc",
                        principalTable: "PatientBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InClinicProcedures_HealthRegions_PatientHealthRegionId",
                        column: x => x.PatientHealthRegionId,
                        principalSchema: "mdc",
                        principalTable: "HealthRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InClinicProcedures_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "mdc",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InClinicProcedures_Diags_SecondMainDiagId",
                        column: x => x.SecondMainDiagId,
                        principalSchema: "mdc",
                        principalTable: "Diags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InClinicProcedures_HealthcarePractitioners_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "mdc",
                        principalTable: "HealthcarePractitioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PathProcedures",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: true),
                    PatientBranchId = table.Column<int>(nullable: true),
                    PatientHRegionId = table.Column<int>(nullable: true),
                    SenderId = table.Column<int>(nullable: true),
                    CPrSend = table.Column<string>(maxLength: 10, nullable: true),
                    APrSend = table.Column<string>(maxLength: 10, nullable: true),
                    TypeProcSend = table.Column<int>(nullable: false),
                    SendPackageType = table.Column<int>(nullable: true),
                    DateSend = table.Column<DateTime>(nullable: false),
                    CPrPriem = table.Column<string>(maxLength: 10, nullable: true),
                    APrPriem = table.Column<string>(maxLength: 10, nullable: true),
                    MedicalWard = table.Column<string>(maxLength: 10, nullable: true),
                    BirthPractice = table.Column<string>(maxLength: 10, nullable: true),
                    BirthNumber = table.Column<int>(nullable: true),
                    BirthGestWeek = table.Column<int>(nullable: true),
                    TypeProcPriem = table.Column<int>(nullable: false),
                    PackageType = table.Column<int>(nullable: true),
                    ProcRefuse = table.Column<int>(nullable: false),
                    CeasedProcedureId = table.Column<int>(nullable: true),
                    CeasedClinicalPathId = table.Column<int>(nullable: true),
                    CeasedOnlyId = table.Column<int>(nullable: true),
                    IZNumChild = table.Column<string>(maxLength: 12, nullable: true),
                    IZYearChild = table.Column<int>(nullable: false),
                    FirstVisitDate = table.Column<DateTime>(nullable: true),
                    DatePlanPriem = table.Column<DateTime>(nullable: true),
                    PlannedNumber = table.Column<int>(nullable: true),
                    VisitDoctorUniqueIdentifier = table.Column<string>(maxLength: 12, nullable: true),
                    VisitDoctorName = table.Column<string>(maxLength: 150, nullable: true),
                    FirstMainDiagId = table.Column<int>(nullable: true),
                    SecondMainDiagId = table.Column<int>(nullable: true),
                    DateProcedureBegins = table.Column<DateTime>(nullable: true),
                    DateProcedureEnd = table.Column<DateTime>(nullable: true),
                    AllDoneProcedures = table.Column<int>(nullable: true),
                    AllDays = table.Column<int>(nullable: true),
                    AllDrugCost = table.Column<decimal>(type: "decimal(15,4)", nullable: true),
                    RedirectedClinicalPath = table.Column<string>(maxLength: 6, nullable: true),
                    PatientStatus = table.Column<int>(nullable: false),
                    RedirectedProc = table.Column<string>(maxLength: 4, nullable: true),
                    EndCourse = table.Column<int>(nullable: true),
                    OutUniqueIdentifier = table.Column<string>(maxLength: 12, nullable: true),
                    Sign = table.Column<int>(nullable: false),
                    NZOKPay = table.Column<int>(nullable: false),
                    HospitalPracticeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PathProcedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PathProcedures_CeasedClinicals_CeasedClinicalPathId",
                        column: x => x.CeasedClinicalPathId,
                        principalSchema: "mdc",
                        principalTable: "CeasedClinicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PathProcedures_CeasedClinicals_CeasedOnlyId",
                        column: x => x.CeasedOnlyId,
                        principalSchema: "mdc",
                        principalTable: "CeasedClinicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PathProcedures_CeasedClinicals_CeasedProcedureId",
                        column: x => x.CeasedProcedureId,
                        principalSchema: "mdc",
                        principalTable: "CeasedClinicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PathProcedures_Diags_FirstMainDiagId",
                        column: x => x.FirstMainDiagId,
                        principalSchema: "mdc",
                        principalTable: "Diags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PathProcedures_HospitalPractices_HospitalPracticeId",
                        column: x => x.HospitalPracticeId,
                        principalSchema: "mdc",
                        principalTable: "HospitalPractices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PathProcedures_PatientBranches_PatientBranchId",
                        column: x => x.PatientBranchId,
                        principalSchema: "mdc",
                        principalTable: "PatientBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PathProcedures_HealthRegions_PatientHRegionId",
                        column: x => x.PatientHRegionId,
                        principalSchema: "mdc",
                        principalTable: "HealthRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PathProcedures_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "mdc",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PathProcedures_Diags_SecondMainDiagId",
                        column: x => x.SecondMainDiagId,
                        principalSchema: "mdc",
                        principalTable: "Diags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PathProcedures_HealthcarePractitioners_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "mdc",
                        principalTable: "HealthcarePractitioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProtocolDrugTherapies",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: true),
                    PatientBranchId = table.Column<int>(nullable: true),
                    PatientHRegionId = table.Column<int>(nullable: true),
                    PracticeId = table.Column<int>(nullable: true),
                    NumberOfDecision = table.Column<int>(nullable: false),
                    DecisionDate = table.Column<DateTime>(nullable: false),
                    PracticeCodeProtocol = table.Column<string>(maxLength: 12, nullable: true),
                    NumberOfProtocol = table.Column<int>(nullable: false),
                    ProtocolDate = table.Column<DateTime>(nullable: false),
                    StartTreatment = table.Column<DateTime>(nullable: true),
                    DiagId = table.Column<int>(nullable: true),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    BSA = table.Column<double>(nullable: false),
                    TherapyLine = table.Column<int>(nullable: false),
                    Scheme = table.Column<string>(maxLength: 4000, nullable: true),
                    CycleCount = table.Column<int>(nullable: false),
                    HematologyPartId = table.Column<int>(nullable: true),
                    ChemotherapyPartId = table.Column<int>(nullable: true),
                    ChairmanId = table.Column<int>(nullable: true),
                    HospitalPracticeId = table.Column<int>(nullable: true),
                    Sign = table.Column<int>(nullable: false),
                    CPFileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProtocolDrugTherapies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProtocolDrugTherapies_CPFiles_CPFileId",
                        column: x => x.CPFileId,
                        principalSchema: "mdc",
                        principalTable: "CPFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProtocolDrugTherapies_HealthcarePractitioners_ChairmanId",
                        column: x => x.ChairmanId,
                        principalSchema: "mdc",
                        principalTable: "HealthcarePractitioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProtocolDrugTherapies_ChemotherapyParts_ChemotherapyPartId",
                        column: x => x.ChemotherapyPartId,
                        principalSchema: "mdc",
                        principalTable: "ChemotherapyParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProtocolDrugTherapies_Diags_DiagId",
                        column: x => x.DiagId,
                        principalSchema: "mdc",
                        principalTable: "Diags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProtocolDrugTherapies_HematologyParts_HematologyPartId",
                        column: x => x.HematologyPartId,
                        principalSchema: "mdc",
                        principalTable: "HematologyParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProtocolDrugTherapies_HospitalPractices_HospitalPracticeId",
                        column: x => x.HospitalPracticeId,
                        principalSchema: "mdc",
                        principalTable: "HospitalPractices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProtocolDrugTherapies_PatientBranches_PatientBranchId",
                        column: x => x.PatientBranchId,
                        principalSchema: "mdc",
                        principalTable: "PatientBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProtocolDrugTherapies_HealthRegions_PatientHRegionId",
                        column: x => x.PatientHRegionId,
                        principalSchema: "mdc",
                        principalTable: "HealthRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProtocolDrugTherapies_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "mdc",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProtocolDrugTherapies_Practices_PracticeId",
                        column: x => x.PracticeId,
                        principalSchema: "mdc",
                        principalTable: "Practices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IZYear = table.Column<int>(nullable: false),
                    IZNumber = table.Column<int>(nullable: false),
                    FirstMainDiagId = table.Column<int>(nullable: true),
                    SecondMainDiagId = table.Column<int>(nullable: true),
                    CashPatient = table.Column<int>(nullable: false),
                    ClinicalProcedure = table.Column<int>(nullable: false),
                    ClinicalPath = table.Column<double>(nullable: false),
                    AmbulatoryProcedure = table.Column<string>(maxLength: 4, nullable: true),
                    DischargeWard = table.Column<string>(maxLength: 5, nullable: true),
                    TransferWard = table.Column<string>(maxLength: 5, nullable: true),
                    TransferDateTime = table.Column<DateTime>(nullable: true),
                    HospitalPracticeId = table.Column<int>(nullable: true),
                    CPFileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfers_CPFiles_CPFileId",
                        column: x => x.CPFileId,
                        principalSchema: "mdc",
                        principalTable: "CPFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transfers_Diags_FirstMainDiagId",
                        column: x => x.FirstMainDiagId,
                        principalSchema: "mdc",
                        principalTable: "Diags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transfers_HospitalPractices_HospitalPracticeId",
                        column: x => x.HospitalPracticeId,
                        principalSchema: "mdc",
                        principalTable: "HospitalPractices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transfers_Diags_SecondMainDiagId",
                        column: x => x.SecondMainDiagId,
                        principalSchema: "mdc",
                        principalTable: "Diags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MDIs",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MDIName = table.Column<string>(maxLength: 200, nullable: true),
                    MDICode = table.Column<decimal>(type: "decimal(15,4)", nullable: true),
                    ACHIcode = table.Column<string>(maxLength: 12, nullable: true),
                    DispObservationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MDIs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MDIs_DispObservations_DispObservationId",
                        column: x => x.DispObservationId,
                        principalSchema: "mdc",
                        principalTable: "DispObservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VSDs",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameVSD = table.Column<string>(maxLength: 250, nullable: true),
                    CodeVSD = table.Column<string>(maxLength: 5, nullable: true),
                    ACHIcode = table.Column<string>(maxLength: 12, nullable: true),
                    DispObservationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VSDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VSDs_DispObservations_DispObservationId",
                        column: x => x.DispObservationId,
                        principalSchema: "mdc",
                        principalTable: "DispObservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClinicProcedures",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcedureName = table.Column<string>(maxLength: 300, nullable: true),
                    ProcedureCode = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    ProcedureDate = table.Column<DateTime>(nullable: false),
                    ACHIcode = table.Column<string>(maxLength: 12, nullable: true),
                    PathProcedureId = table.Column<int>(nullable: true),
                    InClinicProcedureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicProcedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicProcedures_InClinicProcedures_InClinicProcedureId",
                        column: x => x.InClinicProcedureId,
                        principalSchema: "mdc",
                        principalTable: "InClinicProcedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClinicProcedures_PathProcedures_PathProcedureId",
                        column: x => x.PathProcedureId,
                        principalSchema: "mdc",
                        principalTable: "PathProcedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClinicUsedDrugs",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrugDate = table.Column<DateTime>(nullable: false),
                    DrugCode = table.Column<string>(maxLength: 10, nullable: true),
                    DrugName = table.Column<string>(maxLength: 200, nullable: true),
                    DrugQuantity = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    DrugCost = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    ICDDrug = table.Column<string>(maxLength: 10, nullable: true),
                    UINPrescr = table.Column<string>(maxLength: 20, nullable: true),
                    NoPrescr = table.Column<string>(maxLength: 10, nullable: true),
                    DatePrescr = table.Column<DateTime>(nullable: false),
                    PracticeCodeProtocol = table.Column<string>(maxLength: 20, nullable: true),
                    ProtocolNumber = table.Column<int>(nullable: false),
                    ProtocolDate = table.Column<DateTime>(nullable: false),
                    ProtocolType = table.Column<int>(nullable: false),
                    VersionCodeId = table.Column<int>(nullable: true),
                    PathProcedureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicUsedDrugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicUsedDrugs_PathProcedures_PathProcedureId",
                        column: x => x.PathProcedureId,
                        principalSchema: "mdc",
                        principalTable: "PathProcedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClinicUsedDrugs_VersionCodes_VersionCodeId",
                        column: x => x.VersionCodeId,
                        principalSchema: "mdc",
                        principalTable: "VersionCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoneProcedures",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcedureStartDate = table.Column<DateTime>(nullable: true),
                    ProcedureEndDate = table.Column<DateTime>(nullable: true),
                    DoctorId = table.Column<int>(nullable: true),
                    PathProcedureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoneProcedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoneProcedures_HealthcarePractitioners_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "mdc",
                        principalTable: "HealthcarePractitioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoneProcedures_PathProcedures_PathProcedureId",
                        column: x => x.PathProcedureId,
                        principalSchema: "mdc",
                        principalTable: "PathProcedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccompanyingDrugs",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TherapyTypeId = table.Column<int>(nullable: true),
                    ATCCode = table.Column<string>(maxLength: 20, nullable: true),
                    ATCName = table.Column<string>(maxLength: 200, nullable: true),
                    SingleDose = table.Column<decimal>(type: "decimal(12,4)", nullable: false),
                    AllDose = table.Column<decimal>(type: "decimal(12,4)", nullable: false),
                    ProtocolDrugTherapyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccompanyingDrugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccompanyingDrugs_ProtocolDrugTherapies_ProtocolDrugTherapyId",
                        column: x => x.ProtocolDrugTherapyId,
                        principalSchema: "mdc",
                        principalTable: "ProtocolDrugTherapies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccompanyingDrugs_TherapyTypes_TherapyTypeId",
                        column: x => x.TherapyTypeId,
                        principalSchema: "mdc",
                        principalTable: "TherapyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DrugProtocols",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TherapyTypeId = table.Column<int>(nullable: true),
                    ATCCode = table.Column<string>(maxLength: 10, nullable: true),
                    ATCName = table.Column<string>(maxLength: 200, nullable: true),
                    Days = table.Column<string>(maxLength: 200, nullable: true),
                    NumberOfDays = table.Column<int>(nullable: true),
                    ApplicationWay = table.Column<string>(maxLength: 20, nullable: true),
                    StandartDose = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    IndividualDose = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    CycleDose = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    AllDose = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    ProtocolDrugTherapyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugProtocols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugProtocols_ProtocolDrugTherapies_ProtocolDrugTherapyId",
                        column: x => x.ProtocolDrugTherapyId,
                        principalSchema: "mdc",
                        principalTable: "ProtocolDrugTherapies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DrugProtocols_TherapyTypes_TherapyTypeId",
                        column: x => x.TherapyTypeId,
                        principalSchema: "mdc",
                        principalTable: "TherapyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProtocolDrugTherapyHealthPractitioner",
                schema: "mdc",
                columns: table => new
                {
                    HealthcarePractitionerId = table.Column<int>(nullable: false),
                    ProtocolDrugTherapyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProtocolDrugTherapyHealthPractitioner", x => new { x.HealthcarePractitionerId, x.ProtocolDrugTherapyId });
                    table.ForeignKey(
                        name: "FK_ProtocolDrugTherapyHealthPractitioner_HealthcarePractitioners_HealthcarePractitionerId",
                        column: x => x.HealthcarePractitionerId,
                        principalSchema: "mdc",
                        principalTable: "HealthcarePractitioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProtocolDrugTherapyHealthPractitioner_ProtocolDrugTherapies_ProtocolDrugTherapyId",
                        column: x => x.ProtocolDrugTherapyId,
                        principalSchema: "mdc",
                        principalTable: "ProtocolDrugTherapies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Implants",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeId = table.Column<int>(nullable: true),
                    TradeName = table.Column<string>(maxLength: 600, nullable: true),
                    ReferenceNumber = table.Column<string>(maxLength: 10, nullable: true),
                    Manufacturer = table.Column<string>(maxLength: 100, nullable: true),
                    ProviderId = table.Column<int>(nullable: true),
                    Code = table.Column<string>(maxLength: 20, nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Stickers = table.Column<int>(nullable: false),
                    DistributorInvoiceNumber = table.Column<string>(maxLength: 10, nullable: true),
                    DistributorInvoiceDate = table.Column<DateTime>(nullable: false),
                    NhifAmount = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    PatientAmount = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    ClinicProcedureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Implants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Implants_ClinicProcedures_ClinicProcedureId",
                        column: x => x.ClinicProcedureId,
                        principalSchema: "mdc",
                        principalTable: "ClinicProcedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Implants_ImplantProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalSchema: "mdc",
                        principalTable: "ImplantProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Implants_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalSchema: "mdc",
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Outs",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: true),
                    PatientBranchId = table.Column<int>(nullable: true),
                    PatientHRegionId = table.Column<int>(nullable: true),
                    InType = table.Column<int>(nullable: false),
                    SenderId = table.Column<int>(nullable: true),
                    SendDate = table.Column<DateTime>(nullable: false),
                    SendUrgency = table.Column<int>(nullable: false),
                    SendPackageType = table.Column<int>(nullable: true),
                    SendClinicalPath = table.Column<string>(nullable: true),
                    SendAPr = table.Column<string>(maxLength: 10, nullable: true),
                    UniqueIdentifier = table.Column<string>(maxLength: 12, nullable: true),
                    ExaminationDate = table.Column<DateTime>(nullable: false),
                    PlannedEntryDate = table.Column<DateTime>(nullable: true),
                    PlannedNumber = table.Column<int>(nullable: true),
                    Urgency = table.Column<int>(nullable: false),
                    PackageType = table.Column<int>(nullable: true),
                    ClinicalPath = table.Column<string>(maxLength: 10, nullable: true),
                    InAPr = table.Column<string>(maxLength: 10, nullable: true),
                    NZOKPay = table.Column<int>(nullable: false),
                    InMedicalWard = table.Column<string>(maxLength: 10, nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    Severity = table.Column<int>(nullable: true),
                    Delay = table.Column<int>(nullable: true),
                    Payer = table.Column<int>(nullable: false),
                    AgeInDays = table.Column<int>(nullable: true),
                    WeightInGrams = table.Column<int>(nullable: true),
                    BirthWeight = table.Column<int>(nullable: true),
                    MotherIZYear = table.Column<int>(nullable: true),
                    MotherIZNo = table.Column<int>(nullable: true),
                    IZYear = table.Column<int>(nullable: true),
                    IZNo = table.Column<int>(nullable: true),
                    OutMedicalWard = table.Column<string>(maxLength: 10, nullable: true),
                    OutUniqueIdentifier = table.Column<string>(maxLength: 12, nullable: true),
                    OutDate = table.Column<DateTime>(nullable: false),
                    OutType = table.Column<int>(nullable: false),
                    DeadId = table.Column<int>(nullable: true),
                    BirthPractice = table.Column<string>(maxLength: 12, nullable: true),
                    BirthNumber = table.Column<int>(nullable: true),
                    BirthGestWeek = table.Column<int>(nullable: true),
                    ResignId = table.Column<int>(nullable: true),
                    RedirectedId = table.Column<int>(nullable: true),
                    OutClinicalPath = table.Column<string>(maxLength: 10, nullable: true),
                    OutAPr = table.Column<string>(maxLength: 10, nullable: true),
                    HistologicalResultId = table.Column<int>(nullable: true),
                    EpicrisisId = table.Column<int>(nullable: false),
                    IZinDetail = table.Column<string>(maxLength: 4000, nullable: true),
                    OutMainDiagnoseId = table.Column<int>(nullable: true),
                    LinkMedia = table.Column<string>(maxLength: 250, nullable: true),
                    BedDays = table.Column<int>(nullable: true),
                    HLDateFrom = table.Column<DateTime>(nullable: true),
                    HLNumber = table.Column<string>(maxLength: 12, nullable: true),
                    HLTotalDays = table.Column<int>(nullable: true),
                    StateAtDischarge = table.Column<int>(nullable: true),
                    Laparoscopic = table.Column<int>(nullable: true),
                    PathologicFinding = table.Column<int>(nullable: true),
                    EndCourse = table.Column<int>(nullable: true),
                    CPFileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outs_CPFiles_CPFileId",
                        column: x => x.CPFileId,
                        principalSchema: "mdc",
                        principalTable: "CPFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Outs_Epicrises_EpicrisisId",
                        column: x => x.EpicrisisId,
                        principalSchema: "mdc",
                        principalTable: "Epicrises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Outs_HistologicalResults_HistologicalResultId",
                        column: x => x.HistologicalResultId,
                        principalSchema: "mdc",
                        principalTable: "HistologicalResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Outs_PatientBranches_PatientBranchId",
                        column: x => x.PatientBranchId,
                        principalSchema: "mdc",
                        principalTable: "PatientBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Outs_HealthRegions_PatientHRegionId",
                        column: x => x.PatientHRegionId,
                        principalSchema: "mdc",
                        principalTable: "HealthRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Outs_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "mdc",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Outs_Resigners_ResignId",
                        column: x => x.ResignId,
                        principalSchema: "mdc",
                        principalTable: "Resigners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Outs_HealthcarePractitioners_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "mdc",
                        principalTable: "HealthcarePractitioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimaryCode = table.Column<string>(maxLength: 10, nullable: true),
                    SecondaryCode = table.Column<string>(maxLength: 10, nullable: true),
                    SendInId = table.Column<int>(nullable: true),
                    InId = table.Column<int>(nullable: true),
                    SendOutId = table.Column<int>(nullable: true),
                    OutId = table.Column<int>(nullable: true),
                    OutOutId = table.Column<int>(nullable: true),
                    SendPlannedId = table.Column<int>(nullable: true),
                    PlannedId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnoses_Ins_InId",
                        column: x => x.InId,
                        principalSchema: "mdc",
                        principalTable: "Ins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnoses_Outs_OutId",
                        column: x => x.OutId,
                        principalSchema: "mdc",
                        principalTable: "Outs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnoses_Outs_OutOutId",
                        column: x => x.OutOutId,
                        principalSchema: "mdc",
                        principalTable: "Outs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnoses_Plannings_PlannedId",
                        column: x => x.PlannedId,
                        principalSchema: "mdc",
                        principalTable: "Plannings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnoses_MKBs_PrimaryCode",
                        column: x => x.PrimaryCode,
                        principalSchema: "mdc",
                        principalTable: "MKBs",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnoses_MKBs_SecondaryCode",
                        column: x => x.SecondaryCode,
                        principalSchema: "mdc",
                        principalTable: "MKBs",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnoses_Ins_SendInId",
                        column: x => x.SendInId,
                        principalSchema: "mdc",
                        principalTable: "Ins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnoses_Outs_SendOutId",
                        column: x => x.SendOutId,
                        principalSchema: "mdc",
                        principalTable: "Outs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diagnoses_Plannings_SendPlannedId",
                        column: x => x.SendPlannedId,
                        principalSchema: "mdc",
                        principalTable: "Plannings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Procedures",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Code = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    ACHICode = table.Column<string>(maxLength: 12, nullable: true),
                    OutHospital = table.Column<int>(nullable: false),
                    ImplantId = table.Column<int>(nullable: true),
                    BedDays = table.Column<int>(nullable: true),
                    HLDateFrom = table.Column<DateTime>(nullable: true),
                    HLNumber = table.Column<string>(maxLength: 12, nullable: true),
                    HLTotalDays = table.Column<int>(nullable: true),
                    StateAtDischarge = table.Column<int>(nullable: true),
                    Laparoscopic = table.Column<int>(nullable: true),
                    PathologicFinding = table.Column<int>(nullable: true),
                    EndCourse = table.Column<int>(nullable: true),
                    SendAPr = table.Column<string>(maxLength: 12, nullable: true),
                    InAPr = table.Column<string>(maxLength: 12, nullable: true),
                    OutId = table.Column<int>(nullable: true),
                    PathProcedureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Procedures_Implants_ImplantId",
                        column: x => x.ImplantId,
                        principalSchema: "mdc",
                        principalTable: "Implants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Procedures_Outs_OutId",
                        column: x => x.OutId,
                        principalSchema: "mdc",
                        principalTable: "Outs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Procedures_PathProcedures_PathProcedureId",
                        column: x => x.PathProcedureId,
                        principalSchema: "mdc",
                        principalTable: "PathProcedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsedDrugs",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    ICDDrug = table.Column<string>(maxLength: 10, nullable: true),
                    UINPrescr = table.Column<string>(maxLength: 10, nullable: true),
                    NoPrescr = table.Column<string>(maxLength: 10, nullable: true),
                    DatePrescr = table.Column<DateTime>(nullable: true),
                    PracticeCodeProtocol = table.Column<string>(maxLength: 12, nullable: true),
                    ProtocolNumber = table.Column<int>(nullable: false),
                    ProtocolDate = table.Column<DateTime>(nullable: false),
                    ProtocolType = table.Column<int>(nullable: false),
                    VersionCodeId = table.Column<int>(nullable: true),
                    OutId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedDrugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsedDrugs_Outs_OutId",
                        column: x => x.OutId,
                        principalSchema: "mdc",
                        principalTable: "Outs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsedDrugs_VersionCodes_VersionCodeId",
                        column: x => x.VersionCodeId,
                        principalSchema: "mdc",
                        principalTable: "VersionCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Redirects",
                schema: "mdc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PracticeId = table.Column<int>(nullable: true),
                    DiagnoseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redirects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Redirects_Diagnoses_DiagnoseId",
                        column: x => x.DiagnoseId,
                        principalSchema: "mdc",
                        principalTable: "Diagnoses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Redirects_Practices_PracticeId",
                        column: x => x.PracticeId,
                        principalSchema: "mdc",
                        principalTable: "Practices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccompanyingDrugs_ProtocolDrugTherapyId",
                schema: "mdc",
                table: "AccompanyingDrugs",
                column: "ProtocolDrugTherapyId");

            migrationBuilder.CreateIndex(
                name: "IX_AccompanyingDrugs_TherapyTypeId",
                schema: "mdc",
                table: "AccompanyingDrugs",
                column: "TherapyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_APr05s_ClinicChemotherapyPartId",
                schema: "mdc",
                table: "APr05s",
                column: "ClinicChemotherapyPartId");

            migrationBuilder.CreateIndex(
                name: "IX_APr05s_ClinicHematologyPartId",
                schema: "mdc",
                table: "APr05s",
                column: "ClinicHematologyPartId");

            migrationBuilder.CreateIndex(
                name: "IX_APr05s_HistologyId",
                schema: "mdc",
                table: "APr05s",
                column: "HistologyId");

            migrationBuilder.CreateIndex(
                name: "IX_APr38s_DecisionId",
                schema: "mdc",
                table: "APr38s",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChemotherapyParts_EvaluationId",
                schema: "mdc",
                table: "ChemotherapyParts",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_ChemotherapyParts_HistologyId",
                schema: "mdc",
                table: "ChemotherapyParts",
                column: "HistologyId");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_EvaluationId",
                schema: "mdc",
                table: "Choices",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicChemotherapyParts_DecisionId",
                schema: "mdc",
                table: "ClinicChemotherapyParts",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicChemotherapyParts_EvalutionId",
                schema: "mdc",
                table: "ClinicChemotherapyParts",
                column: "EvalutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicHematologyParts_DecisionId",
                schema: "mdc",
                table: "ClinicHematologyParts",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicHematologyParts_EvalutionId",
                schema: "mdc",
                table: "ClinicHematologyParts",
                column: "EvalutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicProcedures_InClinicProcedureId",
                schema: "mdc",
                table: "ClinicProcedures",
                column: "InClinicProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicProcedures_PathProcedureId",
                schema: "mdc",
                table: "ClinicProcedures",
                column: "PathProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicUsedDrugs_PathProcedureId",
                schema: "mdc",
                table: "ClinicUsedDrugs",
                column: "PathProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicUsedDrugs_VersionCodeId",
                schema: "mdc",
                table: "ClinicUsedDrugs",
                column: "VersionCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionAprHealthcarePractitioner_CommissionAprId",
                schema: "mdc",
                table: "CommissionAprHealthcarePractitioner",
                column: "CommissionAprId");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionAprs_APr05Id",
                schema: "mdc",
                table: "CommissionAprs",
                column: "APr05Id");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionAprs_APr38Id",
                schema: "mdc",
                table: "CommissionAprs",
                column: "APr38Id");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionAprs_ChairmanId",
                schema: "mdc",
                table: "CommissionAprs",
                column: "ChairmanId");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionAprs_HospitalPracticeId",
                schema: "mdc",
                table: "CommissionAprs",
                column: "HospitalPracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionAprs_MainDiagId",
                schema: "mdc",
                table: "CommissionAprs",
                column: "MainDiagId");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionAprs_PatientBranchId",
                schema: "mdc",
                table: "CommissionAprs",
                column: "PatientBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionAprs_PatientHRegionId",
                schema: "mdc",
                table: "CommissionAprs",
                column: "PatientHRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionAprs_PatientId",
                schema: "mdc",
                table: "CommissionAprs",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionAprs_SenderId",
                schema: "mdc",
                table: "CommissionAprs",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_CPFiles_FileTypeId",
                schema: "mdc",
                table: "CPFiles",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CPFiles_PracticeId",
                schema: "mdc",
                table: "CPFiles",
                column: "PracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_InId",
                schema: "mdc",
                table: "Diagnoses",
                column: "InId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_OutId",
                schema: "mdc",
                table: "Diagnoses",
                column: "OutId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_OutOutId",
                schema: "mdc",
                table: "Diagnoses",
                column: "OutOutId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_PlannedId",
                schema: "mdc",
                table: "Diagnoses",
                column: "PlannedId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_PrimaryCode",
                schema: "mdc",
                table: "Diagnoses",
                column: "PrimaryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_SecondaryCode",
                schema: "mdc",
                table: "Diagnoses",
                column: "SecondaryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_SendInId",
                schema: "mdc",
                table: "Diagnoses",
                column: "SendInId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_SendOutId",
                schema: "mdc",
                table: "Diagnoses",
                column: "SendOutId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_SendPlannedId",
                schema: "mdc",
                table: "Diagnoses",
                column: "SendPlannedId");

            migrationBuilder.CreateIndex(
                name: "IX_Diags_ChemotherapyPartId",
                schema: "mdc",
                table: "Diags",
                column: "ChemotherapyPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Diags_CommissionAprId",
                schema: "mdc",
                table: "Diags",
                column: "CommissionAprId");

            migrationBuilder.CreateIndex(
                name: "IX_Diags_LinkDMKBCode",
                schema: "mdc",
                table: "Diags",
                column: "LinkDMKBCode");

            migrationBuilder.CreateIndex(
                name: "IX_Diags_MKBCode",
                schema: "mdc",
                table: "Diags",
                column: "MKBCode");

            migrationBuilder.CreateIndex(
                name: "IX_DispObservations_DoctorId",
                schema: "mdc",
                table: "DispObservations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DispObservations_HealthcarePractitionerId",
                schema: "mdc",
                table: "DispObservations",
                column: "HealthcarePractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_DispObservations_HospitalPracticeId",
                schema: "mdc",
                table: "DispObservations",
                column: "HospitalPracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_DispObservations_MainDiagFirstId",
                schema: "mdc",
                table: "DispObservations",
                column: "MainDiagFirstId");

            migrationBuilder.CreateIndex(
                name: "IX_DispObservations_MainDiagSecondId",
                schema: "mdc",
                table: "DispObservations",
                column: "MainDiagSecondId");

            migrationBuilder.CreateIndex(
                name: "IX_DispObservations_PatientBranchId",
                schema: "mdc",
                table: "DispObservations",
                column: "PatientBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_DispObservations_PatientHRegionId",
                schema: "mdc",
                table: "DispObservations",
                column: "PatientHRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_DispObservations_PatientId",
                schema: "mdc",
                table: "DispObservations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DoneProcedures_DoctorId",
                schema: "mdc",
                table: "DoneProcedures",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoneProcedures_PathProcedureId",
                schema: "mdc",
                table: "DoneProcedures",
                column: "PathProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugPacks_CPFileId",
                schema: "mdc",
                table: "DrugPacks",
                column: "CPFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugPacks_HospitalPracticeId",
                schema: "mdc",
                table: "DrugPacks",
                column: "HospitalPracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugProtocols_ProtocolDrugTherapyId",
                schema: "mdc",
                table: "DrugProtocols",
                column: "ProtocolDrugTherapyId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugProtocols_TherapyTypeId",
                schema: "mdc",
                table: "DrugProtocols",
                column: "TherapyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugResidues_CPFileId",
                schema: "mdc",
                table: "DrugResidues",
                column: "CPFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugResidues_HospitalPracticeId",
                schema: "mdc",
                table: "DrugResidues",
                column: "HospitalPracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_GenMarkers_ChemotherapyPartId",
                schema: "mdc",
                table: "GenMarkers",
                column: "ChemotherapyPartId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcarePractitioners_HealthRegionId",
                schema: "mdc",
                table: "HealthcarePractitioners",
                column: "HealthRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcarePractitioners_PracticeId",
                schema: "mdc",
                table: "HealthcarePractitioners",
                column: "PracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcarePractitioners_SenderTypeId",
                schema: "mdc",
                table: "HealthcarePractitioners",
                column: "SenderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthcarePractitioners_SpecialityId",
                schema: "mdc",
                table: "HealthcarePractitioners",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthRegions_Code",
                schema: "mdc",
                table: "HealthRegions",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HematologyParts_PredMarkerId",
                schema: "mdc",
                table: "HematologyParts",
                column: "PredMarkerId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalPractices_FileTypeId",
                schema: "mdc",
                table: "HospitalPractices",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalPractices_HealthRegionId",
                schema: "mdc",
                table: "HospitalPractices",
                column: "HealthRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalPractices_PracticeId",
                schema: "mdc",
                table: "HospitalPractices",
                column: "PracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_Implants_ClinicProcedureId",
                schema: "mdc",
                table: "Implants",
                column: "ClinicProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_Implants_ProductTypeId",
                schema: "mdc",
                table: "Implants",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Implants_ProviderId",
                schema: "mdc",
                table: "Implants",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_InClinicProcedures_CeasedClinicalPathId",
                schema: "mdc",
                table: "InClinicProcedures",
                column: "CeasedClinicalPathId");

            migrationBuilder.CreateIndex(
                name: "IX_InClinicProcedures_CeasedOnlyId",
                schema: "mdc",
                table: "InClinicProcedures",
                column: "CeasedOnlyId");

            migrationBuilder.CreateIndex(
                name: "IX_InClinicProcedures_CeasedProcedureId",
                schema: "mdc",
                table: "InClinicProcedures",
                column: "CeasedProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_InClinicProcedures_FirstMainDiagId",
                schema: "mdc",
                table: "InClinicProcedures",
                column: "FirstMainDiagId");

            migrationBuilder.CreateIndex(
                name: "IX_InClinicProcedures_HospitalPracticeId",
                schema: "mdc",
                table: "InClinicProcedures",
                column: "HospitalPracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_InClinicProcedures_PatientBranchId",
                schema: "mdc",
                table: "InClinicProcedures",
                column: "PatientBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_InClinicProcedures_PatientHealthRegionId",
                schema: "mdc",
                table: "InClinicProcedures",
                column: "PatientHealthRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_InClinicProcedures_PatientId",
                schema: "mdc",
                table: "InClinicProcedures",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_InClinicProcedures_SecondMainDiagId",
                schema: "mdc",
                table: "InClinicProcedures",
                column: "SecondMainDiagId",
                unique: true,
                filter: "[SecondMainDiagId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InClinicProcedures_SenderId",
                schema: "mdc",
                table: "InClinicProcedures",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Ins_CPFileId",
                schema: "mdc",
                table: "Ins",
                column: "CPFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Ins_PatientBranchId",
                schema: "mdc",
                table: "Ins",
                column: "PatientBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Ins_PatientHRegionId",
                schema: "mdc",
                table: "Ins",
                column: "PatientHRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ins_PatientId",
                schema: "mdc",
                table: "Ins",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Ins_SenderId",
                schema: "mdc",
                table: "Ins",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Markers_EvaluationId",
                schema: "mdc",
                table: "Markers",
                column: "EvaluationId");

            migrationBuilder.CreateIndex(
                name: "IX_Markers_GenMarkerId",
                schema: "mdc",
                table: "Markers",
                column: "GenMarkerId");

            migrationBuilder.CreateIndex(
                name: "IX_MDIs_DispObservationId",
                schema: "mdc",
                table: "MDIs",
                column: "DispObservationId");

            migrationBuilder.CreateIndex(
                name: "IX_MKBs_Name",
                schema: "mdc",
                table: "MKBs",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Outs_CPFileId",
                schema: "mdc",
                table: "Outs",
                column: "CPFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Outs_DeadId",
                schema: "mdc",
                table: "Outs",
                column: "DeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Outs_EpicrisisId",
                schema: "mdc",
                table: "Outs",
                column: "EpicrisisId");

            migrationBuilder.CreateIndex(
                name: "IX_Outs_HistologicalResultId",
                schema: "mdc",
                table: "Outs",
                column: "HistologicalResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Outs_OutMainDiagnoseId",
                schema: "mdc",
                table: "Outs",
                column: "OutMainDiagnoseId");

            migrationBuilder.CreateIndex(
                name: "IX_Outs_PatientBranchId",
                schema: "mdc",
                table: "Outs",
                column: "PatientBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Outs_PatientHRegionId",
                schema: "mdc",
                table: "Outs",
                column: "PatientHRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Outs_PatientId",
                schema: "mdc",
                table: "Outs",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Outs_RedirectedId",
                schema: "mdc",
                table: "Outs",
                column: "RedirectedId");

            migrationBuilder.CreateIndex(
                name: "IX_Outs_ResignId",
                schema: "mdc",
                table: "Outs",
                column: "ResignId");

            migrationBuilder.CreateIndex(
                name: "IX_Outs_SenderId",
                schema: "mdc",
                table: "Outs",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PathProcedures_CeasedClinicalPathId",
                schema: "mdc",
                table: "PathProcedures",
                column: "CeasedClinicalPathId");

            migrationBuilder.CreateIndex(
                name: "IX_PathProcedures_CeasedOnlyId",
                schema: "mdc",
                table: "PathProcedures",
                column: "CeasedOnlyId");

            migrationBuilder.CreateIndex(
                name: "IX_PathProcedures_CeasedProcedureId",
                schema: "mdc",
                table: "PathProcedures",
                column: "CeasedProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_PathProcedures_FirstMainDiagId",
                schema: "mdc",
                table: "PathProcedures",
                column: "FirstMainDiagId");

            migrationBuilder.CreateIndex(
                name: "IX_PathProcedures_HospitalPracticeId",
                schema: "mdc",
                table: "PathProcedures",
                column: "HospitalPracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_PathProcedures_PatientBranchId",
                schema: "mdc",
                table: "PathProcedures",
                column: "PatientBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PathProcedures_PatientHRegionId",
                schema: "mdc",
                table: "PathProcedures",
                column: "PatientHRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_PathProcedures_PatientId",
                schema: "mdc",
                table: "PathProcedures",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PathProcedures_SecondMainDiagId",
                schema: "mdc",
                table: "PathProcedures",
                column: "SecondMainDiagId");

            migrationBuilder.CreateIndex(
                name: "IX_PathProcedures_SenderId",
                schema: "mdc",
                table: "PathProcedures",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientBranches_HealthRegionId",
                schema: "mdc",
                table: "PatientBranches",
                column: "HealthRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_IdentityNumber",
                schema: "mdc",
                table: "Patients",
                column: "IdentityNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_SexId",
                schema: "mdc",
                table: "Patients",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_Plannings_CPFileId",
                schema: "mdc",
                table: "Plannings",
                column: "CPFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Plannings_PatientBranchId",
                schema: "mdc",
                table: "Plannings",
                column: "PatientBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Plannings_PatientHRegionId",
                schema: "mdc",
                table: "Plannings",
                column: "PatientHRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Plannings_PatientId",
                schema: "mdc",
                table: "Plannings",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Plannings_SenderId",
                schema: "mdc",
                table: "Plannings",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Practices_HealthRegionId",
                schema: "mdc",
                table: "Practices",
                column: "HealthRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_ImplantId",
                schema: "mdc",
                table: "Procedures",
                column: "ImplantId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_OutId",
                schema: "mdc",
                table: "Procedures",
                column: "OutId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_PathProcedureId",
                schema: "mdc",
                table: "Procedures",
                column: "PathProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProtocolDrugTherapies_CPFileId",
                schema: "mdc",
                table: "ProtocolDrugTherapies",
                column: "CPFileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProtocolDrugTherapies_ChairmanId",
                schema: "mdc",
                table: "ProtocolDrugTherapies",
                column: "ChairmanId");

            migrationBuilder.CreateIndex(
                name: "IX_ProtocolDrugTherapies_ChemotherapyPartId",
                schema: "mdc",
                table: "ProtocolDrugTherapies",
                column: "ChemotherapyPartId");

            migrationBuilder.CreateIndex(
                name: "IX_ProtocolDrugTherapies_DiagId",
                schema: "mdc",
                table: "ProtocolDrugTherapies",
                column: "DiagId");

            migrationBuilder.CreateIndex(
                name: "IX_ProtocolDrugTherapies_HematologyPartId",
                schema: "mdc",
                table: "ProtocolDrugTherapies",
                column: "HematologyPartId");

            migrationBuilder.CreateIndex(
                name: "IX_ProtocolDrugTherapies_HospitalPracticeId",
                schema: "mdc",
                table: "ProtocolDrugTherapies",
                column: "HospitalPracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProtocolDrugTherapies_PatientBranchId",
                schema: "mdc",
                table: "ProtocolDrugTherapies",
                column: "PatientBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ProtocolDrugTherapies_PatientHRegionId",
                schema: "mdc",
                table: "ProtocolDrugTherapies",
                column: "PatientHRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProtocolDrugTherapies_PatientId",
                schema: "mdc",
                table: "ProtocolDrugTherapies",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ProtocolDrugTherapies_PracticeId",
                schema: "mdc",
                table: "ProtocolDrugTherapies",
                column: "PracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProtocolDrugTherapyHealthPractitioner_ProtocolDrugTherapyId",
                schema: "mdc",
                table: "ProtocolDrugTherapyHealthPractitioner",
                column: "ProtocolDrugTherapyId");

            migrationBuilder.CreateIndex(
                name: "IX_Redirects_DiagnoseId",
                schema: "mdc",
                table: "Redirects",
                column: "DiagnoseId");

            migrationBuilder.CreateIndex(
                name: "IX_Redirects_PracticeId",
                schema: "mdc",
                table: "Redirects",
                column: "PracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_SenderTypes_Code",
                schema: "mdc",
                table: "SenderTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SenderTypes_Name",
                schema: "mdc",
                table: "SenderTypes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Sexes_Name",
                schema: "mdc",
                table: "Sexes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialtyTypes_Name",
                schema: "mdc",
                table: "SpecialtyTypes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialtyTypes_SpecialtyCode",
                schema: "mdc",
                table: "SpecialtyTypes",
                column: "SpecialtyCode",
                unique: true,
                filter: "[SpecialtyCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TherapyTypes_Code",
                schema: "mdc",
                table: "TherapyTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_CPFileId",
                schema: "mdc",
                table: "Transfers",
                column: "CPFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_FirstMainDiagId",
                schema: "mdc",
                table: "Transfers",
                column: "FirstMainDiagId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_HospitalPracticeId",
                schema: "mdc",
                table: "Transfers",
                column: "HospitalPracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_SecondMainDiagId",
                schema: "mdc",
                table: "Transfers",
                column: "SecondMainDiagId");

            migrationBuilder.CreateIndex(
                name: "IX_UsedDrugs_OutId",
                schema: "mdc",
                table: "UsedDrugs",
                column: "OutId");

            migrationBuilder.CreateIndex(
                name: "IX_UsedDrugs_VersionCodeId",
                schema: "mdc",
                table: "UsedDrugs",
                column: "VersionCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_VSDs_DispObservationId",
                schema: "mdc",
                table: "VSDs",
                column: "DispObservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommissionAprs_Diags_MainDiagId",
                schema: "mdc",
                table: "CommissionAprs",
                column: "MainDiagId",
                principalSchema: "mdc",
                principalTable: "Diags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Outs_Diagnoses_DeadId",
                schema: "mdc",
                table: "Outs",
                column: "DeadId",
                principalSchema: "mdc",
                principalTable: "Diagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Outs_Diagnoses_OutMainDiagnoseId",
                schema: "mdc",
                table: "Outs",
                column: "OutMainDiagnoseId",
                principalSchema: "mdc",
                principalTable: "Diagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Outs_Redirects_RedirectedId",
                schema: "mdc",
                table: "Outs",
                column: "RedirectedId",
                principalSchema: "mdc",
                principalTable: "Redirects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APr05s_ClinicChemotherapyParts_ClinicChemotherapyPartId",
                schema: "mdc",
                table: "APr05s");

            migrationBuilder.DropForeignKey(
                name: "FK_APr05s_ClinicHematologyParts_ClinicHematologyPartId",
                schema: "mdc",
                table: "APr05s");

            migrationBuilder.DropForeignKey(
                name: "FK_APr05s_Histologies_HistologyId",
                schema: "mdc",
                table: "APr05s");

            migrationBuilder.DropForeignKey(
                name: "FK_ChemotherapyParts_Histologies_HistologyId",
                schema: "mdc",
                table: "ChemotherapyParts");

            migrationBuilder.DropForeignKey(
                name: "FK_APr38s_Evaluations_DecisionId",
                schema: "mdc",
                table: "APr38s");

            migrationBuilder.DropForeignKey(
                name: "FK_ChemotherapyParts_Evaluations_EvaluationId",
                schema: "mdc",
                table: "ChemotherapyParts");

            migrationBuilder.DropForeignKey(
                name: "FK_Diags_CommissionAprs_CommissionAprId",
                schema: "mdc",
                table: "Diags");

            migrationBuilder.DropForeignKey(
                name: "FK_Ins_HealthcarePractitioners_SenderId",
                schema: "mdc",
                table: "Ins");

            migrationBuilder.DropForeignKey(
                name: "FK_Outs_HealthcarePractitioners_SenderId",
                schema: "mdc",
                table: "Outs");

            migrationBuilder.DropForeignKey(
                name: "FK_Plannings_HealthcarePractitioners_SenderId",
                schema: "mdc",
                table: "Plannings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ins_PatientBranches_PatientBranchId",
                schema: "mdc",
                table: "Ins");

            migrationBuilder.DropForeignKey(
                name: "FK_Outs_PatientBranches_PatientBranchId",
                schema: "mdc",
                table: "Outs");

            migrationBuilder.DropForeignKey(
                name: "FK_Plannings_PatientBranches_PatientBranchId",
                schema: "mdc",
                table: "Plannings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ins_HealthRegions_PatientHRegionId",
                schema: "mdc",
                table: "Ins");

            migrationBuilder.DropForeignKey(
                name: "FK_Outs_HealthRegions_PatientHRegionId",
                schema: "mdc",
                table: "Outs");

            migrationBuilder.DropForeignKey(
                name: "FK_Plannings_HealthRegions_PatientHRegionId",
                schema: "mdc",
                table: "Plannings");

            migrationBuilder.DropForeignKey(
                name: "FK_Practices_HealthRegions_HealthRegionId",
                schema: "mdc",
                table: "Practices");

            migrationBuilder.DropForeignKey(
                name: "FK_Ins_Patients_PatientId",
                schema: "mdc",
                table: "Ins");

            migrationBuilder.DropForeignKey(
                name: "FK_Outs_Patients_PatientId",
                schema: "mdc",
                table: "Outs");

            migrationBuilder.DropForeignKey(
                name: "FK_Plannings_Patients_PatientId",
                schema: "mdc",
                table: "Plannings");

            migrationBuilder.DropForeignKey(
                name: "FK_CPFiles_FileTypes_FileTypeId",
                schema: "mdc",
                table: "CPFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_CPFiles_Practices_PracticeId",
                schema: "mdc",
                table: "CPFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Redirects_Practices_PracticeId",
                schema: "mdc",
                table: "Redirects");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Ins_InId",
                schema: "mdc",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Ins_SendInId",
                schema: "mdc",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Outs_OutId",
                schema: "mdc",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Outs_OutOutId",
                schema: "mdc",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Outs_SendOutId",
                schema: "mdc",
                table: "Diagnoses");

            migrationBuilder.DropTable(
                name: "AccompanyingDrugs",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Choices",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "ClinicUsedDrugs",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "CommissionAprHealthcarePractitioner",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "DoneProcedures",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "DrugPacks",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "DrugProtocols",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "DrugResidues",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Markers",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "MDIs",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Procedures",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "ProtocolDrugTherapyHealthPractitioner",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Transfers",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "UsedDrugs",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "VSDs",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "TherapyTypes",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "GenMarkers",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Implants",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "ProtocolDrugTherapies",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "VersionCodes",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "DispObservations",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "ClinicProcedures",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "ImplantProductTypes",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Providers",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "HematologyParts",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "InClinicProcedures",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "PathProcedures",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "CeasedClinicals",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "ClinicChemotherapyParts",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "ClinicHematologyParts",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Histologies",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Evaluations",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "CommissionAprs",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "APr05s",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "APr38s",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "HospitalPractices",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Diags",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "ChemotherapyParts",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "HealthcarePractitioners",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "SenderTypes",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "SpecialtyTypes",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "PatientBranches",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "HealthRegions",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Sexes",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "FileTypes",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Practices",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Ins",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Outs",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Epicrises",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "HistologicalResults",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Redirects",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Resigners",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Diagnoses",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "Plannings",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "MKBs",
                schema: "mdc");

            migrationBuilder.DropTable(
                name: "CPFiles",
                schema: "mdc");
        }
    }
}
