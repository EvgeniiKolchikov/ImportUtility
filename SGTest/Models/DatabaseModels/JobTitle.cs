using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.Models.DatabaseModels
{
    /// <summary>
    /// Модель данных для должности
    /// </summary>
    public class JobTitle
    {
        /// <summary>
        /// Получает или задает идентификатор
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Получает или задает должность
        /// </summary>
        public string Name { get; set; }
    }
}
