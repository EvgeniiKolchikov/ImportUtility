using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.Models.DatabaseModels
{
    /// <summary>
    /// Класс модели данных для подразделения
    /// </summary>
    public class Department
    {

        /// <summary>
        /// Получает или задает идентификатор
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Получает или задает родительское подразделение
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Получает или задает идентификатор руководителя
        /// </summary>
        public int? ManagerId { get; set; }

        /// <summary>
        /// Получает или задает имя родительского подразделения
        /// </summary>
        public string? ParentName { get; set; }

        /// <summary>
        /// Получает или задает имя руководителя
        /// </summary>
        public string? ManagerName { get; set; }

        /// <summary>
        /// Получает или задает название подразделения
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Получает или задает телефон
        /// </summary>
        public string? Phone { get; set; }
    }
}
