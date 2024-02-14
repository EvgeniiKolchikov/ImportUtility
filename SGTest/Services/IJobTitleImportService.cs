using SGTest.Models.ImportModels;

namespace SGTest.Services
{
    public interface IJobTitleImportService
    {
        /// <summary>
        /// Выполняет импорт данных из Tsv файла
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Импортированные данные</returns>
        List<JobTitleImportModel> ImportFromTSVJobTitles(string filePath);
    }
}