using SGTest.Contexts;
using SGTest.Exceptions;
using SGTest.Models.DatabaseModels;
using SGTest.Models.ImportModels;
using SGTest.Properties;
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
    public class DepartmentRepository
    {
        private Context context;
       
        /// <summary>
        /// Выполняет инициализацию экземпляра класса <see cref="DepartmentRepository"/>
        /// </summary>
        public DepartmentRepository()
        {
            this.context = new Context();
        }

        /// <summary>
        /// Добавляет в базу данных подразделение
        /// </summary>
        /// <param name="department">Объект подразделения</param>
        /// <returns></returns>
        public async Task AddOrUpdateAsync(DepartmentImportModel departmentImportModel)
        {

            var department = new Department()
            {
                Name = departmentImportModel.Name,
                ManagerName = departmentImportModel.Manager,
                Phone = departmentImportModel.Phone,
                ParentName = departmentImportModel.ParentDepartment                
            };


            var existingDepartment = GetDepartmenFromTable(department);

            if (existingDepartment == null)
            {
                department = GetParentId(department);
                department = GetManagerId(department);
                this.context.Departments.Add(department);
                await this.context.SaveChangesAsync();
            }
            else
            {
                existingDepartment = MapDepartmentProperties(department, existingDepartment);
                existingDepartment = GetParentId(existingDepartment);
                existingDepartment = GetManagerId(existingDepartment);
                this.context.Departments.Update(existingDepartment);
                await this.context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Получает все департаменты
        /// </summary>
        /// <returns></returns>
        public IQueryable<Department> GetAllDepartments()
        {
            return this.context.Departments;
        }

        /// <summary>
        /// Получает департамент
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        private Department GetDepartmenFromTable(Department department)
        {
            return this.context.Departments.FirstOrDefault(d => d.Name == department.Name && d.ParentName == department.ParentName);
        }

        /// <summary>
        /// Выполняет мапинг полей департамента
        /// </summary>
        /// <param name="newDepartment"></param>
        /// <param name="existinDepartment"></param>
        /// <returns></returns>
        private Department MapDepartmentProperties(Department newDepartment, Department existinDepartment)
        {
            existinDepartment.ManagerName = newDepartment.ManagerName;
            existinDepartment.Name = newDepartment.Name;
            existinDepartment.Phone = newDepartment.Phone;
            return existinDepartment;
        }

        /// <summary>
        /// Получает идентификатор родительского подразделения
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        private Department GetParentId(Department department)
        {
            try
            {
                var parentId = this.context.Departments.First(d => d.Name == department.ParentName).Id;
                department.ParentId = parentId;
                return department;
            }
            catch (Exception)
            {
                return department;
               
            }
           
        }

        /// <summary>
        /// Получает идентификатор руководителя
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        private Department GetManagerId(Department department)
        {
            try
            {
                var manageId = this.context.Employees.First(e => e.FullName == department.ManagerName).Id;
                department.ManagerId = manageId;
                return department;
            }
            catch (Exception)
            {
                return department;
            }
        }
    }
}
