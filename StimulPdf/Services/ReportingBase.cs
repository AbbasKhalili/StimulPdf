using Stimulsoft.Report;
using Stimulsoft.Report.Export;

namespace StimulPdf.Services
{
    public abstract class ReportingBase
    {
        protected StiReport Report;

        private readonly string _reportFileName;

        protected ReportingBase(string reportFileName)
        {
            _reportFileName = $"Reports/{reportFileName}";
            Report = new StiReport();
        }

        protected void GenerateReport<T>(string name, T data)
        {
            var reportFilePath = ReportConfig.GetReportFilePath(_reportFileName);
            Report.RegBusinessObject(name, data);
            Report.Load(reportFilePath);
            Report.Dictionary.SynchronizeBusinessObjects();
            Report.Dictionary.Synchronize();
            Report.Render(false);
        }

        protected ReportDto GeneratePdf(string pdfFileName)
        {
            var memory = new MemoryStream { Position = 0 };
            Report.ExportDocument(StiExportFormat.Pdf, memory, new StiPdfExportSettings
            {
                EmbeddedFonts = true,
                CreatorString = "IranianGeo.ir"
            });
            memory.Position = 0;
            return new ReportDto
            {
                Content = memory,
                ContentType = "application/pdf",
                Filename = $"{pdfFileName}.PDF"
            };
        }
    }
}
