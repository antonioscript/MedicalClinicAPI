using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocXToPdfConverter;
using MedicalClinic.Application.Interfaces.Shared;
using MedicalClinic.Infrastructure.DocumentProcessor.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;

namespace MedicalClinic.Infrastructure.DocumentProcessor.Repositories
{
    public class DocumentProcessor : Message, IDocumentProcessor
    {
        public async Task<string> CreateDocumentMedicalPrescription(string templateFilePath, string fileName, string saveAsPath)
        {

            if (!File.Exists(templateFilePath))
            {
                throw new FileNotFoundException(String.Format(MESSAGE_WORD_DOCUMENT_PATH_NOT_FOUND, templateFilePath));
            }

            if (!Directory.Exists(saveAsPath))
            {
                throw new FileNotFoundException(String.Format(MESSAGE_WORD_DOCUMENT_SAVE_NOT_FOUND, saveAsPath));
            }

            if (!Path.GetExtension(fileName).Equals(".docx", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(String.Format(MESSAGE_WORD_DOCUMENT_EXTENSION, fileName));
            }


            string savePathDoc = saveAsPath + fileName;

            File.Copy(templateFilePath, savePathDoc, true);

            // Palavras para substituição
            string doctorName = "Dr. John Doe";
            string patientName = "Jane Doe";
            string consultValue = "$100.00";

            // Realiza as substituições no novo documento
            ReplaceTextInWordDocument(savePathDoc, "MD_DOCTOR_NAME", doctorName);
            ReplaceTextInWordDocument(savePathDoc, "MD_PATIENT_NAME", patientName);
            ReplaceTextInWordDocument(savePathDoc, "MD_VALOR", consultValue);

            //PDF
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            var savePathPDf = $"{saveAsPath}{fileNameWithoutExtension}.pdf";
            await CreateNewPdfMedicalPrescription(savePathDoc, savePathPDf);

            //Delete DOC
            File.Delete(savePathDoc);

            //Retorno
            return string.Format(MESSAGE_WORD_DOCUMENT_SUCCESS, savePathPDf);
        }

        private void ReplaceTextInWordDocument(string documentPath, string placeholder, string replacement)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(documentPath, true))
            {
                Body body = wordDocument.MainDocumentPart.Document.Body;

                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains(placeholder)))
                {
                    text.Text = text.Text.Replace(placeholder, replacement);
                }

                wordDocument.MainDocumentPart.Document.Save();
            }
        }

        private async Task CreateNewPdfMedicalPrescription(string templatePathInput, string templatePathOut)
        {
            string locationOfLibreOfficeSoffice = @"C:\Projects\MedicalClinicAPI\docs\03.LibreOffice\LibreOfficePortable\App\libreoffice\program\soffice.exe";

            var placeholders = new Placeholders();

            placeholders.NewLineTag = "";
            placeholders.TextPlaceholderStartTag = "##";
            placeholders.TextPlaceholderEndTag = "##";
            placeholders.TablePlaceholderStartTag = "==";
            placeholders.TablePlaceholderEndTag = "==";
            placeholders.ImagePlaceholderStartTag = "++";
            placeholders.ImagePlaceholderEndTag = "++";

            // initialize report generator
            var reportGenerator = new ReportGenerator(locationOfLibreOfficeSoffice);

            // convert DOCX to PDF
            reportGenerator.Convert(templatePathInput, templatePathOut, placeholders);
        }
    }
}
