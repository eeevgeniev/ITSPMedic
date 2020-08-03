using Medic.EHR.RM;
using Medic.Formatters.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Medic.App.Controllers.Base
{
    public abstract class FormatterBaseController : MedicBaseController
    {
        protected virtual async Task<IActionResult> FormatModel(ReferenceModel model, IDataFormattable formatter)
        {
            if (formatter == default)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            if (model == default)
            {
                return BadRequest();
            }

            MemoryStream memoryStream = new MemoryStream();
            memoryStream = (MemoryStream)(await formatter.FormatObject(model, memoryStream));
            memoryStream.Position = 0;

            return new FileStreamResult(memoryStream, formatter.MimeType);
        }

        protected virtual async Task<IActionResult> FormatModel<T>(IEnumerable<T> model, string sheetName, IFormattableFactory formatFactory) where T : class
        {
            if (formatFactory == default)
            {
                throw new ArgumentNullException(nameof(formatFactory));
            }

            if (model == default)
            {
                return BadRequest();
            }

            MemoryStream memoryStream = new MemoryStream();

            IExcelFormattable excelFormatter = formatFactory.CreateExcelFormatter(memoryStream);

            await excelFormatter.AddSheet<T>(model, sheetName);
            memoryStream = (MemoryStream)excelFormatter.Save();
            memoryStream.Position = 0;

            return new FileStreamResult(memoryStream, excelFormatter.MimeType);
        }
    }
}
