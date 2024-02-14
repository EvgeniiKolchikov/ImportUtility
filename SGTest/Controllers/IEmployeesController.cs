namespace SGTest.Controllers
{
    public interface IEmployeesController
    {
        Task ImportEmployeesAsync(string filePath);
        void DisplayAllEmployees();
    }
}