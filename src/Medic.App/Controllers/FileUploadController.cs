using Medic.App.Controllers.Base;
using Medic.App.Models.FileUploads;
using Medic.Cache.Contacts;
using Medic.Entities;
using Medic.Identity;
using Medic.Import.Contracts;
using Medic.Logs.Contracts;
using Medic.Logs.Models;
using Medic.Mappers.Contracts;
using Medic.Resources;
using Medic.XMLParser.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Xml;
using CLPR = Medic.Models.CLPR;
using CP = Medic.Models.CP;

namespace Medic.App.Controllers
{
    [Authorize(Roles = MedicIdentityConstants.Administrator)]
    public class FileUploadController : MedicBaseController
    {
        private readonly IImportMedicFile ImportMedicFile;
        private readonly IMedicXmlParser MedicXmlParser;
        private readonly IMappable Mapper;
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly IMedicLoggerService MedicLoggerService;
        private readonly ICacheable MedicCache;

        public FileUploadController(
            IImportMedicFile importMedicFile,
            IMedicXmlParser medicXmlParser,
            IMappable mapper,
            MedicDataLocalization medicDataLocalization,
            IMedicLoggerService medicLoggerService,
            ICacheable medicCache)
        {
            ImportMedicFile = importMedicFile ?? throw new ArgumentNullException(nameof(importMedicFile));
            MedicXmlParser = medicXmlParser ?? throw new ArgumentNullException(nameof(medicXmlParser));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(MedicBaseController));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
            MedicCache = medicCache ?? throw new ArgumentNullException(nameof(medicCache));
        }

        [HttpGet]
        public IActionResult CPFile() => View(new FileUploadPageCPFile()
        {
            Title = MedicDataLocalization.Get(MedicDataLocalization.CPFile),
            Description = MedicDataLocalization.Get(MedicDataLocalization.CPFile),
            Keywords = MedicDataLocalization.Get(MedicDataLocalization.CPFileSummary)
        });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CPFile(IFormFile CpFileFormFile)
        {
            try
            {
                string error = default;

                if (CpFileFormFile != default)
                {

                    CP.CPFile cpFileModel = MedicXmlParser
                        .ParseXML<CP.CPFile>(CpFileFormFile.OpenReadStream());

                    if (cpFileModel != default)
                    {
                        CPFile cpFileEntity = Mapper.Map<CPFile, CP.CPFile>(cpFileModel);

                        await Task.Run(() => ImportMedicFile.ImportCPFile(cpFileEntity));

                        ClearCache();
                    }
                    else
                    {
                        error = MedicDataLocalization.Get(MedicDataLocalization.InvalidFile);
                    }
                }
                else
                {
                    error = MedicDataLocalization.Get(MedicDataLocalization.InvalidFile);
                }

                return View(new FileUploadPageCPFile()
                {
                    Title = MedicDataLocalization.Get(MedicDataLocalization.CPFile),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.CPFile),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.CPFileSummary),
                    Error = error
                });
            }
            catch (XmlException xmlEx)
            {
                Task<int> _ = MedicLoggerService.SaveAsync(new Log()
                {
                    Message = xmlEx.Message,
                    InnerExceptionMessage = xmlEx?.InnerException?.Message ?? null,
                    Source = xmlEx.Source,
                    StackTrace = xmlEx.StackTrace,
                    Date = DateTime.Now
                });

                return View(new FileUploadPageCPFile()
                {
                    Title = MedicDataLocalization.Get(MedicDataLocalization.CPFile),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.CPFile),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.CPFileSummary),
                    Error = MedicDataLocalization.Get(MedicDataLocalization.InvalidFile)
                });
            }
            catch (InvalidOperationException invalOpEx)
            {
                Task<int> _ = MedicLoggerService.SaveAsync(new Log()
                {
                    Message = invalOpEx.Message,
                    InnerExceptionMessage = invalOpEx?.InnerException?.Message ?? null,
                    Source = invalOpEx.Source,
                    StackTrace = invalOpEx.StackTrace,
                    Date = DateTime.Now
                });

                return View(new FileUploadPageCPFile()
                {
                    Title = MedicDataLocalization.Get(MedicDataLocalization.CPFile),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.CPFile),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.CPFileSummary),
                    Error = MedicDataLocalization.Get(MedicDataLocalization.InvalidFile)
                });
            }
            catch (Exception ex)
            {
                Task<int> _ = MedicLoggerService.SaveAsync(new Log()
                {
                    Message = ex.Message,
                    InnerExceptionMessage = ex?.InnerException?.Message ?? null,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace,
                    Date = DateTime.Now
                });

                throw;
            }
        }

        [HttpGet]
        public IActionResult HospitalPractice() => View(new FileUploadPageHospitalPractice()
        {
            Title = MedicDataLocalization.Get(MedicDataLocalization.HospitalPracticeFile),
            Description = MedicDataLocalization.Get(MedicDataLocalization.HospitalPracticeFile),
            Keywords = MedicDataLocalization.Get(MedicDataLocalization.HospitalPracticeFileSummary)
        });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HospitalPractice(IFormFile HopsitalPracticeFormFile)
        {
            try
            {
                string error = string.Empty;

                if (HopsitalPracticeFormFile != default)
                {
                    CLPR.HospitalPractice hospitalPracticeModel = MedicXmlParser
                        .ParseXML<CLPR.HospitalPractice>(HopsitalPracticeFormFile.OpenReadStream());

                    if (hospitalPracticeModel != default)
                    {
                        HospitalPractice hospitalPracticeEntity = Mapper.Map<HospitalPractice, CLPR.HospitalPractice>(hospitalPracticeModel);

                        await Task.Run(() => ImportMedicFile.ImportHospitalPractice(hospitalPracticeEntity));

                        ClearCache();
                    }
                    else
                    {
                        error = MedicDataLocalization.Get(MedicDataLocalization.InvalidFile);
                    }
                }
                else
                {
                    error = MedicDataLocalization.Get(MedicDataLocalization.InvalidFile);
                }

                return View(new FileUploadPageHospitalPractice()
                {
                    Title = MedicDataLocalization.Get(MedicDataLocalization.HospitalPracticeFile),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.HospitalPracticeFile),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.HospitalPracticeFileSummary),
                    Error = error
                });
            }
            catch (XmlException xmlEx)
            {
                Task<int> _ = MedicLoggerService.SaveAsync(new Log()
                {
                    Message = xmlEx.Message,
                    InnerExceptionMessage = xmlEx?.InnerException?.Message ?? null,
                    Source = xmlEx.Source,
                    StackTrace = xmlEx.StackTrace,
                    Date = DateTime.Now
                });

                return View(new FileUploadPageHospitalPractice()
                {
                    Title = MedicDataLocalization.Get(MedicDataLocalization.CPFile),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.CPFile),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.CPFileSummary),
                    Error = MedicDataLocalization.Get(MedicDataLocalization.InvalidFile)
                });
            }
            catch (InvalidOperationException invalOpEx)
            {
                Task<int> _ = MedicLoggerService.SaveAsync(new Log()
                {
                    Message = invalOpEx.Message,
                    InnerExceptionMessage = invalOpEx?.InnerException?.Message ?? null,
                    Source = invalOpEx.Source,
                    StackTrace = invalOpEx.StackTrace,
                    Date = DateTime.Now
                });

                return View(new FileUploadPageHospitalPractice()
                {
                    Title = MedicDataLocalization.Get(MedicDataLocalization.HospitalPracticeFile),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.HospitalPracticeFile),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.HospitalPracticeFileSummary),
                    Error = MedicDataLocalization.Get(MedicDataLocalization.InvalidFile)
                });
            }
            catch (Exception ex)
            {
                Task<int> _ = MedicLoggerService.SaveAsync(new Log()
                {
                    Message = ex.Message,
                    InnerExceptionMessage = ex?.InnerException?.Message ?? null,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace,
                    Date = DateTime.Now
                });

                throw;
            }
        }

        private void ClearCache() => MedicCache.Clear();
    }
}
