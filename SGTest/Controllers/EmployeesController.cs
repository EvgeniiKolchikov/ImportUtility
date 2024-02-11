using SGTest.Repoitories;
using SGTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.Controllers
{
    /// <summary>
    /// Класс контроллера для сотрудников
    /// </summary>
    public class EmployeesController
    {

        private EmployeeRepository employeeRepository;
        private EmployeesImportService employeeImportService;

        /// <summary>
        /// Выполняет инициализацию экземпляра класса <see cref="EmployeesController"/>
        /// </summary>
        public EmployeesController()
        {
            employeeRepository = new EmployeeRepository();
            employeeImportService = new EmployeesImportService();
        }

        /// <summary>
        /// Импортирует сотрудников в базу данных
        /// </summary>
        /// <param name="filePath">Путь до файла с сотрудниками</param>
        /// <returns></returns>
        public async Task ImportEmployeesAsync(string filePath)
        {
            var employeeImportedList = employeeImportService.ImportTSVEmployees(filePath);

            foreach (var employeeImportModel in employeeImportedList)
            {
                try
                {
                    await employeeRepository.AddOrUpdateAsync(employeeImportModel);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e);
                    continue;
                }
            }

            DisplayAllEmployees();
        }

        /// <summary>
        /// Отображает всех сотрудников
        /// </summary>
        public void DisplayAllEmployees()
        {
            var allEmployees = employeeRepository.GetAll();

            Console.WriteLine("Данные из таблицы Employees");
            Console.WriteLine();

            foreach (var employee in allEmployees)
            {
                Console.Write(employee.Id + "\t");
                Console.Write(employee.DepartmentId + "\t");
                Console.Write(employee.DepartmentName + "\t");
                Console.Write(employee.FullName + "\t");
                Console.Write(employee.Login + "\t");
                Console.Write(employee.Password + "\t");
                Console.Write(employee.JobTitle + "\t");
                Console.WriteLine(employee.JobTitleId);


            }
        }
    }
}
