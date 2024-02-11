using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.Models.DatabaseModels
{
    /// <summary>
    /// Модель данных для сотрудника
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Получает или задает идентификатор
        /// </summary>
        [Key]
        public int Id { get; set; }

        public int? DepartmentId { get; set; }

        /// <summary>
        /// Получает или задает департамент
        /// </summary>
        public string? DepartmentName { get; set; }

        /// <summary>
        /// Получает или задает ФИО
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Получает или задает Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Получает или задает пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Получает или задает должность
        /// </summary>
        public string JobTitle { get; set; }
        /// <summary>
        /// Получает или задает должность
        /// </summary>
        public int? JobTitleId { get; set; }
    }
}
