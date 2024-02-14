namespace SGTest.Controllers
{
    public interface IJobTitleController
    {
        Task ImportJobTitlesAsync(string filePath);
        void DisplayAllJobTitles();
    }
}