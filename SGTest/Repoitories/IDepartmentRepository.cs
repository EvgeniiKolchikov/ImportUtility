using SGTest.Models.DatabaseModels;
using SGTest.Models.ImportModels;

namespace SGTest.Repoitories
{
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Добавляет в базу данных подразделение
        /// </summary>
        /// <param name="department">Объект подразделения</param>
        /// <returns></returns>
        Task AddOrUpdateAsync(DepartmentImportModel departmentImportModel);
        IQueryable<Department> GetAll();
    }
}