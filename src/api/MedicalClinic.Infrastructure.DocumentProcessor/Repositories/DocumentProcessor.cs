using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocXToPdfConverter;
using MedicalClinic.Application.Interfaces.Shared;
using MedicalClinic.Infrastructure.DocumentProcessor.Messages;
using OpenXmlPowerTools;
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
        public async Task<string> CreateDocumentPdf(string templateFilePath, string fileName, string saveAsPath, Dictionary<string, string> documentProperties, string textFooter)
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

            
            //Replace Properties
            foreach (var documentProperty in documentProperties) 
            {
                await ReplaceTextInWordDocument(savePathDoc, documentProperty.Key, documentProperty.Value);
            }

            //Inserir rodapé
            await InsertFooter(savePathDoc, textFooter);

            //Export As PDF
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            var savePathPDf = $"{saveAsPath}{fileNameWithoutExtension}.pdf";
            await ExportAsPdf(savePathDoc, savePathPDf);

            //Delete DOC
            File.Delete(savePathDoc);

            //Retorno
            return string.Format(MESSAGE_WORD_DOCUMENT_SUCCESS, savePathPDf);
        }

        private async Task ReplaceTextInWordDocument(string documentPath, string placeholder, string replacement)
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

        private async Task InsertFooter (string documentPath, string textFooter)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(documentPath, true))
            {
                // Obter a seção atual (pode haver várias seções no documento)
                SectionProperties sectionProperties = wordDoc.MainDocumentPart.Document.Body.Elements<SectionProperties>().FirstOrDefault();

                // Criar um novo rodapé
                FooterPart footerPart = wordDoc.MainDocumentPart.AddNewPart<FooterPart>();
                string footerPartId = wordDoc.MainDocumentPart.GetIdOfPart(footerPart);

                // Adicionar conteúdo ao rodapé
                var paragraph = new Paragraph(new Run(new Text(textFooter)))
                {
                    ParagraphProperties = new ParagraphProperties(new Justification() { Val = JustificationValues.Center })
                };
                var footer = new Footer(paragraph);
                footer.Save(footerPart);

                // Vincular o rodapé à seção
                if (sectionProperties == null)
                {
                    sectionProperties = new SectionProperties();
                    wordDoc.MainDocumentPart.Document.Body.Append(sectionProperties);
                }

                FooterReference footerReference = new FooterReference() { Type = HeaderFooterValues.Default, Id = footerPartId };
                sectionProperties.InsertAt(footerReference, 0);

                wordDoc.MainDocumentPart.Document.Save();
            }
        }

        private async Task<string> ExportAsPdf(string templatePathInput, string templatePathOut)
        {

            // Caminho do novo documento
            string templatePathInput2 = @"C:\Projects\MedicalClinicAPI\docs\2.DocumentProcessor\01.MedicalPrescriptionsPDF\FirstDoc.docx";
            //string templatePathInput2 = @"C:\Projects\Análises\WordProcessor\MedicalPrescriptions\NewDocument.docx";
            //string templatePathOut2 = @"C:\Projects\Análises\WordProcessor\MedicalPrescriptions\NewDocument.pdf";
            string templatePathOut2 = @"C:\Projects\MedicalClinicAPI\docs\2.DocumentProcessor\01.MedicalPrescriptionsPDF\FirstDoc.pdf";

            string locationOfLibreOfficeSoffice = @"C:\Projects\MedicalClinicAPI\docs\03.LibreOffice\LibreOfficePortable\App\libreoffice\program\soffice.exe";
            //string locationOfLibreOfficeSoffice = @"C:\Projects\Análises\WordProcessor\LibreOfficePortable\App\libreoffice\program\soffice.exe";

            var placeholders = new Placeholders();

            placeholders.NewLineTag = "";
            placeholders.TextPlaceholderStartTag = "##";
            placeholders.TextPlaceholderEndTag = "##";
            placeholders.TablePlaceholderStartTag = "==";
            placeholders.TablePlaceholderEndTag = "==";
            placeholders.ImagePlaceholderStartTag = "++";
            placeholders.ImagePlaceholderEndTag = "++";
            // initialize report generator
            var test = new ReportGenerator(locationOfLibreOfficeSoffice);

            // convert DOCX to PDF
            test.Convert(templatePathInput2, templatePathOut2, placeholders);

            return templatePathOut2;
        }
    }
}
