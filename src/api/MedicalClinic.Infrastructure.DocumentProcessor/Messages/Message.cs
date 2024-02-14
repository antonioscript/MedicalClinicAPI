using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Infrastructure.DocumentProcessor.Messages
{
    public class Message
    {
        public string MESSAGE_WORD_DOCUMENT_PATH_NOT_FOUND { get; set; } = "File path '{0}' not found!";
        public string MESSAGE_DOCUMENT_PROPERTY { get; set; } = "Property '{0}' does not exist in the Word document.";
        public string MESSAGE_WORD_DOCUMENT_SAVE_NOT_FOUND { get; set; } = "Destination directory '{0}' not found!";
        public string MESSAGE_WORD_DOCUMENT_SUCCESS { get; set; } = "Document created successfully at '{0}'!";
        public string MESSAGE_WORD_DOCUMENT_EXTENSION { get; set; } = "File name '{0}' must have the extension '.docx'";

        public string MESSAGE_WORD_PDF_EXTENSION { get; set; } = "File name '{0}' must have the extension '.pdf'";
        public string MESSAGE_WORD_PDF_LIBRE_OFFICE { get; set; } = "Unable to locate Libre Office at '{0}'. Make sure to provide the correct path in 'appsettings.json'";
        public string MESSAGE_WORD_PDF_SUCCESS { get; set; } = "PDF exported successfully at '{0}'!";

        public string MESSAGE_FILE_NOT_FOUND { get; set; } = "Word Template path '{0}' not found";
        public string MESSAGE_TABLE_LOCATION_NOT_FOUND { get; set; } = "Text '{0}' not found in the Word document. The table was not inserted.";
        public string MESSAGE_IMAGE_NOT_FOUND { get; set; } = "Text '{0}' not found in the Word document. The image was not inserted.";

    }
}
