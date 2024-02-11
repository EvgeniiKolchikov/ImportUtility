using SGTest.Models.DatabaseModels;
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
    /// Класс контроллера для подразделения
    /// </summary>
    public class DepartmentsController
    {
        private DepartmentRepository departmentRepository;
        private EmployeeRepository employeeRepository;
        private DepartmentsImportService departmentsImportService;
       
        /// <summary>
        /// Выполняет инициализацию экземпляра класса <see cref="DepartmentsController"/>
        /// </summary>
        public DepartmentsController()
        {
            departmentRepository = new DepartmentRepository();
            employeeRepository = new EmployeeRepository();
            departmentsImportService = new DepartmentsImportService();
        }

        /// <summary>
        /// Выполняет импорт департамента в базу данных
        /// </summary>
        /// <param name="departmentsFilePath">Путь к файлу с подразделениями</param>
        /// <returns></returns>
        public async Task ImportDepartmentsAsync(string departmentsFilePath)
        {
            
            var departmentsImportedList = departmentsImportService.ImportTSVDepartments(departmentsFilePath);
            foreach (var deparmentImport in departmentsImportedList)
            {
                try
                {
                    await departmentRepository.AddOrUpdateAsync(deparmentImport);
                    
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e);
                    continue;
                }
            }
            DisplayAllDepartments();
        }

        /// <summary>
        /// Отображает все департамены
        /// </summary>
        public void DisplayAllDepartments()
        {
            var allDepartments = departmentRepository.GetAllDepartments();
            foreach (var department in allDepartments)
            {
                Console.Write(department.Id + "\t" );
                Console.Write(department.ParentId + "\t");
                Console.Write(department.ManagerId + "\t");
                Console.Write(department.Name + "\t\t");
                Console.Write(department.ParentName + "\t\t");
                Console.Write(department.ManagerName + "\t\t");
                Console.WriteLine(department.Phone);
            }
        }

        /// <summary>
        /// Отображает структуру подразделений
        /// </summary>
        public void DisplayDepartmentsIerarchy()
        {
            var allDepartments = departmentRepository.GetAllDepartments().OrderBy(x => x).ToList();
            var allEmployees = employeeRepository.GetAll().ToList();

            Console.WriteLine("Организационная иерархия:");

            foreach (var department in allDepartments.Where(d => d.ParentId == null))
            {
                PrintDepartmentIerarchy(department, 1, allDepartments, allEmployees);
            }
        }

        /// <summary>
        /// Отображает структуру конкретного подразделения
        /// </summary>
        /// <param name="id">Идентификатор подразделения</param>
        public void DisplayDepartmentsIerarchy(int id)
        {
            var allDepartments = departmentRepository.GetAllDepartments().OrderBy(x => x).ToList();
            var hierarchy = GetDepartmentHierarchy(allDepartments, id);

            var descendingHierarchy = hierarchy.Reverse();

            Console.WriteLine($"Организационная иерархия для подразделения ID={id}");

            var level = 1;
            foreach (var department in descendingHierarchy)
            {
                Console.WriteLine($"{new string('=', level)}{department.Name} Id:{department.Id}");
                level++;
            }
        }

        /// <summary>
        /// Выполняет отображение структуру подразделений с сотрудниками
        /// </summary>
        private void PrintDepartmentIerarchy(Department department, int level, List<Department> departments, List<Employee> employees)
        {
            Console.WriteLine($"{new string('=', level)}{department.Name} Id:{department.Id}");

            foreach (var employee in employees.Where(e => e.DepartmentId == department.Id))
            {

                if (employee.Id == department.ManagerId)
                {
                    Console.WriteLine($"{new string('*', level + 1)}{employee.FullName} ID={employee.Id} ({employee.JobTitle} ID={employee.JobTitleId})");
                }
                else
                {
                    Console.WriteLine($"{new string('-', level + 1)}{employee.FullName} ID={employee.Id} ({employee.JobTitle} ID={employee.JobTitleId})");
                }
            }

            foreach (var childDepartment in departments.Where(d => d.ParentId == department.Id))
            {
                PrintDepartmentIerarchy(childDepartment, level + 1, departments, employees);
            }
        }

        /// <summary>
        /// Получает иерархию подразделения
        /// </summary>
        /// <returns>Иерархия подразделения</returns>
        private IEnumerable<Department> GetDepartmentHierarchy(List<Department> departments, int? id)
        {
            var department = departments.FirstOrDefault(d => d.Id == id);

            if (department == null)
            {
                return Enumerable.Empty<Department>();
            }
                
            return Enumerable.Repeat(department, 1).Concat(GetDepartmentHierarchy(departments, department.ParentId));
        }
    }
}
