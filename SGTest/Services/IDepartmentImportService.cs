using SGTest.Models.ImportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.Services
{
    /// <summary>
    /// Интерфейс сервиса извлечения данных депертаментов из TSV файла 
    /// </summary>
    public interface IDepartmentImportService
    {
        /// <summary>
        /// Выполняет импорт данных из Tsv файла
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Импортированные данные</returns>
        List<DepartmentImportModel> ImportFromTSVDepartments(string filePath);
    }
}
