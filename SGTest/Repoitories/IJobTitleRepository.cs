using SGTest.Models.DatabaseModels;
using SGTest.Models.ImportModels;

namespace SGTest.Repoitories
{
    public interface IJobTitleRepository
    {
        /// <summary>
        /// Добавляет в базу данных должность
        /// </summary>
        /// <param name="department">Объект подразделения</param>
        /// <returns></returns>
        Task AddAsync(JobTitleImportModel jobTitleImportModel);
        IQueryable<JobTitle> GetAll();
    }
}