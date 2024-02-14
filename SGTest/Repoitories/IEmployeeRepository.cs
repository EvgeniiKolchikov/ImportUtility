using SGTest.Models.DatabaseModels;
using SGTest.Models.ImportModels;

namespace SGTest.Repoitories
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Добавляет в базу данных сотрудника
        /// </summary>
        /// <param name="department">Объект подразделения</param>
        /// <returns></returns>
        Task AddOrUpdateAsync(EmployeeImportModel employeeImportModel);
        IQueryable<Employee> GetAll();
    }
}