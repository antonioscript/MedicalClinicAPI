using MedicalClinic.Domain.Enums;
using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    public partial class DocumentParameter
    {
        public int Id { get; set; }
        public string LocalizationDocumentInput { get; set; } = null!;
        public string LocalizationDocumentOutput { get; set; } = null!;
        public string LocalizationLibreOffice { get; set; } = null!;
        public DocumentTypeCode DocumentType { get; set; } 
    }
}
