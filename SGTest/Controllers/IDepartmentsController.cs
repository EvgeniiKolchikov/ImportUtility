namespace SGTest.Controllers
{
    public interface IDepartmentsController
    {
        Task ImportDepartmentsAsync(string departmentsFilePath);
        void DisplayAllDepartments();
        void DisplayDepartmentsIerarchy();
        void DisplayDepartmentsIerarchy(int id);
    }
}