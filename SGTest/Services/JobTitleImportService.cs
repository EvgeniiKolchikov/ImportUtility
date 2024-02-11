using SGTest.Models.ImportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.Services
{
    /// <summary>
    /// Класс сервиса для импорте данных должностей из TSV файла
    /// </summary>
    public class JobTitleImportService
    {

        /// <summary>
        /// Выполняет импорт данных из Tsv файла
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Импортированные данные</returns>
        public List<JobTitleImportModel> ImportTSVJobTitles(string filePath)
        {
            var tsvDataList = File.ReadAllLines(filePath).Skip(1).Select(x => x.Split("\t")).ToList();

            var jobTitleList = new List<JobTitleImportModel>();

            foreach (var row in tsvDataList)
            {
                if (TextFormatService.IsRowEmpty(row))
                {
                    continue;
                }

                var jobTitle = new JobTitleImportModel();
                jobTitle.Name = row[0];

                jobTitleList.Add(jobTitle);
            }
            return jobTitleList;
        }
    }
}
