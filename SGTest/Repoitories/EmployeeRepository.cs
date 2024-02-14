using SGTest.Contexts;
using SGTest.Models.DatabaseModels;
using SGTest.Models.ImportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.Repoitories
{
    /// <summary>
    /// Класс репозитория для подразделений
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private Context context;

        /// <summary>
        /// Выполняет инициализацию экземпляра класса <see cref="EmployeeRepository"/>
        /// </summary>
        public EmployeeRepository(Context context)
        {
            this.context = context;
        }

        /// <summary>
        /// Добавляет в базу данных сотрудника
        /// </summary>
        /// <param name="department">Объект подразделения</param>
        /// <returns></returns>
        public async Task AddOrUpdateAsync(EmployeeImportModel employeeImportModel)
        {

            var employee = new Employee();
            employee.DepartmentName = employeeImportModel.Department;
            employee.FullName = employeeImportModel.FullName;
            employee.Login = employeeImportModel.Login;
            employee.Password = employeeImportModel.Password;
            employee.JobTitle = employeeImportModel.JobTitle;

            var existingEmployee = GetEmployeeInTable(employee);
            if (existingEmployee == null)
            {
                employee = AssignDepartmentId(employee);
                employee = AssignJobTitleId(employee);
                this.context.Employees.Add(employee);
                await this.context.SaveChangesAsync();
            }
            else
            {
                existingEmployee = MapEmployeeProperties(employee, existingEmployee);
                if (existingEmployee.DepartmentId == null)
                {
                    existingEmployee = AssignDepartmentId(existingEmployee);
                }
                if (existingEmployee.JobTitleId == null)
                {
                    existingEmployee = AssignJobTitleId(existingEmployee);
                }

                this.context.Employees.Update(existingEmployee);
                await this.context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Получает всех сотрудников
        /// </summary>
        /// <returns></returns>
        public IQueryable<Employee> GetAll()
        {
            return this.context.Employees;
        }

        /// <summary>
        /// Получает сотрудника
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        private Employee GetEmployeeInTable(Employee employee)
        {
            return this.context.Employees.FirstOrDefault(e => e.FullName == employee.FullName);
        }

        /// <summary>
        /// Выполняет маппинг полей сотрудника
        /// </summary>
        /// <param name="newEmployee"></param>
        /// <param name="existingEmployee"></param>
        /// <returns></returns>
        private Employee MapEmployeeProperties(Employee newEmployee, Employee existingEmployee)
        {
            existingEmployee.DepartmentName = newEmployee.DepartmentName;
            existingEmployee.FullName = newEmployee.FullName;
            existingEmployee.Login = newEmployee.Login;
            existingEmployee.Password = newEmployee.Password;
            existingEmployee.JobTitle = newEmployee.JobTitle;
            return existingEmployee;
        }

        /// <summary>
        /// Добавляет идентификатор руководителя
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        private Employee AssignDepartmentId(Employee employee)
        {
            try
            {
                var departmentId = this.context.Departments.First(d => d.Name == employee.DepartmentName).Id;
                employee.DepartmentId = departmentId;
                return employee;
            }
            catch (Exception)
            {
                return employee;   
            }
            
        }

        /// <summary>
        /// Добавляет идентификатор должности
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        private Employee AssignJobTitleId(Employee employee)
        {
            try
            {
                var jobTitleId = this.context.JobTitles.First(j => j.Name == employee.JobTitle).Id;
                employee.JobTitleId = jobTitleId;
                return employee;
            }
            catch (Exception)
            {
                return employee;
            }
        }
    }
}
