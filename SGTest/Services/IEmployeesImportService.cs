using SGTest.Models.ImportModels;

namespace SGTest.Services
{
    public interface IEmployeesImportService
    {
        List<EmployeeImportModel> ImportTSVEmployees(string filePath);
    }
}