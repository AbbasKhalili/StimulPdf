using Stimulsoft.Report;
using System.IO;

namespace StimulPdf.Services
{
    public static class ReportConfig
    {
        private static string Path { get; set; }

        public static void SetProperties(string reportPath)
        {
            Stimulsoft.Base.StiLicense.LoadFromFile($"{reportPath}license.key");
            StiOptions.Export.Pdf.AllowImportSystemLibraries = true;

            var filePaths = Directory.GetFiles(reportPath, "*.ttf", SearchOption.TopDirectoryOnly);
            foreach (var file in filePaths)
            {
                Stimulsoft.Base.StiFontCollection.AddFontFile($"{file}");
            }
            Path = reportPath;
        }

        public static string GetReportFilePath(string fileName)
        {
            var reportFilePath = "";

            if (string.IsNullOrEmpty(reportFilePath))
                if (File.Exists($"{Path}{fileName}"))
                    reportFilePath = $"{Path}{fileName}";

            return reportFilePath;
        }
    }
}
