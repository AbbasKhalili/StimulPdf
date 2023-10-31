namespace StimulPdf.Services
{
    public class ReportDto
    {
        public string Filename { get; set; }
        public MemoryStream Content { get; set; }
        public string ContentType { get; set; } = "application/pdf";
    }
}
