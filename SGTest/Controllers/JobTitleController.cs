using SGTest.Repoitories;
using SGTest.Services;

namespace SGTest.Controllers
{
    /// <summary>
    /// Класс контроллера для Должностей
    /// </summary>
    public class JobTitleController
    {

        private JobTitleRepository jobTitleRepository;
        private JobTitleImportService jobTitleImportService;

        /// <summary>
        /// Выполняет инициализацию экземпляра класса <see cref="JobTitleController"/>
        /// </summary>
        public JobTitleController()
        {
            jobTitleRepository = new JobTitleRepository();
            jobTitleImportService = new JobTitleImportService();
        }

        /// <summary>
        /// Импортирует должности в базу данных
        /// </summary>
        /// <param name="filePath">Путь к списку должностей</param>
        /// <returns></returns>
        public async Task ImportJobTitlesAsync(string filePath)
        {
            var jobTitleImportedList = jobTitleImportService.ImportTSVJobTitles(filePath);

            foreach (var jobTitleImportModel in jobTitleImportedList)
            {
                try
                {
                    await jobTitleRepository.AddAsync(jobTitleImportModel);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e);
                    continue;
                }
            }

            DisplayAllJobTitles();
        }

        /// <summary>
        /// Отображает все должности
        /// </summary>
        public void DisplayAllJobTitles()
        {
            var allJobTitles = jobTitleRepository.GetAll();

            foreach (var jobTitle in allJobTitles)
            {
                Console.Write(jobTitle.Id + "\t");
                Console.WriteLine(jobTitle.Name);
            }
        }
    }
}
