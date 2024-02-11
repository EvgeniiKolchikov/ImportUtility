using SGTest.Models.ImportModels;
using System.Text;

namespace SGTest.Services
{
    /// <summary>
    /// Класс сервиса извлечения сотрудников из TSV файла
    /// </summary>
    public class EmployeesImportService
    {
        /// <summary>
        /// Выполняет импорт данных из Tsv файла
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Импортированные данные</returns>
        public List<EmployeeImportModel> ImportTSVEmployees(string filePath)
        {

            var tsvDataList = File.ReadAllLines(filePath).Skip(1).Select(x => x.Split("\t")).ToList();

            var employeesList = new List<EmployeeImportModel>();

            foreach (var row in tsvDataList)
            {
                if (TextFormatService.IsRowEmpty(row))
                {
                    continue;
                }
                var employee = new EmployeeImportModel
                {
                    Department = row[0].Trim(),
                    FullName = row[1].Trim(),
                    Login = row[2].Trim(),
                    Password = row[3].Trim(),
                    JobTitle = row[4].Trim()
                };

                FormatEmployeeData(employee);

                employeesList.Add(employee);
            }

            return employeesList;
        }

        /// <summary>
        /// Выполняет форматирование полей сотрудника
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        private void FormatEmployeeData(EmployeeImportModel employee)
        {
            employee.Department = TextFormatService.RemoveExtraSpaces(employee.Department);
            employee.Department = TextFormatService.WriteFirstCharacterToUpperCase(employee.Department);
        }

    }
}
