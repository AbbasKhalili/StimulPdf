using Microsoft.CodeAnalysis.Semantics;
using System.IO;
using System.Threading.Tasks;

namespace StimulPdf.Services
{
    public interface ISheetFacadeReporting
    {
        Task<ReportDto> PrintSheet();
    }
}
