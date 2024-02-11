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
    public class JobTitleRepository
    {
        private Context context;

        /// <summary>
        /// Выполняет инициализацию экземпляра класса <see cref="JobTitleRepository"/>
        /// </summary>
        public JobTitleRepository()
        {
            this.context = new Context();
        }

        /// <summary>
        /// Добавляет в базу данных должность
        /// </summary>
        /// <param name="department">Объект подразделения</param>
        /// <returns></returns>
        public async Task AddAsync(JobTitleImportModel jobTitleImportModel)
        {
            var isDuplicate = this.context.JobTitles.Any(d => d.Name == jobTitleImportModel.Name);
            if (!isDuplicate)
            {
                var jobTitle = new JobTitle()
                {
                    Name = jobTitleImportModel.Name
                };
                this.context.JobTitles.Add(jobTitle);
                await this.context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Получает все должности
        /// </summary>
        /// <returns></returns>
        public IQueryable<JobTitle> GetAll()
        {
            return this.context.JobTitles;
        }

    }
}

