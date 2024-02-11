using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.Models.ImportModels
{
    /// <summary>
    /// Класс модели данных для подразделения
    /// </summary>
    public class DepartmentImportModel
    {
        /// <summary>
        /// Получает или задает название подразделения
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Получает или задает родительское подразделение
        /// </summary>
        public string? ParentDepartment { get; set; }

        /// <summary>
        /// Получает или задает руководителя
        /// </summary>
        public string? Manager { get; set; }

        /// <summary>
        /// Получает или задает телефон
        /// </summary>
        public string? Phone { get; set; }
    }
}
