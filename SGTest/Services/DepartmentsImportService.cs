using SGTest.Models.ImportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.Services
{
    /// <summary>
    /// Класс сервиса извлечения данных из TSV файла
    /// </summary>
    public class DepartmentsImportService
    {

        /// <summary>
        /// Выполняет импорт данных из Tsv файла
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Импортированные данные</returns>
        public List<DepartmentImportModel> ImportTSVDepartments(string filePath)
        {

            var tsvDataList = File.ReadAllLines(filePath).Skip(1).Select(x => x.Split("\t")).ToList();

            var departmentsList = new List<DepartmentImportModel>();

            foreach (var row in tsvDataList)
            {
                if (TextFormatService.IsRowEmpty(row))
                {
                    continue;
                }

                var department = new DepartmentImportModel()
                {
                    Name = row[0].Trim(),
                    ParentDepartment = row[1].Trim(),
                    Manager = row[2].Trim(),
                    Phone = row[3].Trim()
                };

                FormatDepartmentData(department);

                departmentsList.Add(department);
            }

            return departmentsList;
        }

        /// <summary>
        /// Выполняет форматирование полей подразделения
        /// </summary>
        /// <param name="departmentImportModel">Подразделение</param>
        private void FormatDepartmentData(DepartmentImportModel departmentImportModel)
        {
            departmentImportModel.Phone = TextFormatService.RemoveSpaces(departmentImportModel.Phone);
        }
    }
}
