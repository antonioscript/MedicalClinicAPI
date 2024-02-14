using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Interfaces.Shared
{
    public interface IDocumentProcessor
    {
        Task<string> CreateDocumentPdf(string templateFilePath, string fileName, string saveAsPath, Dictionary<string, string> documentProperties);

    }
}
