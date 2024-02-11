using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.Models.ImportModels
{
    /// <summary>
    /// Модель данных для сотрудника
    /// </summary>
    public class EmployeeImportModel
    {

        /// <summary>
        /// Получает или задает департамент
        /// </summary>
        public string Department { get; set; }

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
    }
}
