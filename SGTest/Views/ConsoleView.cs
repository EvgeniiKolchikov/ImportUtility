using SGTest.Controllers;
using SGTest.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.Views
{
    /// <summary>
    /// Класс консольного представления
    /// </summary>
    public class ConsoleView
    {

        private DepartmentsController departmentsController;
        private EmployeesController employeesController;
        private JobTitleController jobTitleController;

        /// <summary>
        /// Выполняет инициализацию жкземпляра класса <see cref="ConsoleView"/>
        /// </summary>
        public ConsoleView()
        {
            departmentsController = new DepartmentsController();
            employeesController = new EmployeesController();
            jobTitleController = new JobTitleController();
        }

        /// <summary>
        /// Запускает представление
        /// </summary>
        /// <returns></returns>
        public async Task RunAsync()
        {
            while (true)
            {
                Console.WriteLine("\n\n" + ViewMessages.HelloMessage);
                await View();
                
            }
        }

        /// <summary>
        /// Представление для пользователя
        /// </summary>
        /// <returns></returns>
        private async Task View()
        {
            Console.WriteLine("1. Выполнить импорт из файла в Базу данных");
            Console.WriteLine("2. Вывести текущую структуру данных");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":

                    Console.WriteLine("1. Импорт подразделений");
                    Console.WriteLine("2. Импорт сотрудников");
                    Console.WriteLine("3. Импорт должностей");

                    var inputImport = Console.ReadLine();

                    switch (inputImport)
                    {
                        case "1":
                            await ImportDepartments();
                            break;
                        case "2":
                            await ImportEmployees();
                            break;
                        case "3":
                            await ImportJobTitles();
                            break;
                        default:
                            Console.WriteLine(ViewMessages.UnknownCommand);
                            break;
                    }

                    break;
                case "2":
                    Console.WriteLine("1. Вывести текущую структуру данных");
                    Console.WriteLine("2. Вывести структуру для подразделения с идентификатором");

                    var inputDisplay = Console.ReadLine();

                    switch (inputDisplay)
                    {
                        case "1":
                            departmentsController.DisplayDepartmentsIerarchy();
                            break;
                        case "2":
                            Console.WriteLine("Введите идентификатор подразделения");

                            var inputId = Console.ReadLine();
                            if (inputId != null)
                            {
                                try
                                {
                                    departmentsController.DisplayDepartmentsIerarchy(int.Parse(inputId));
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine(ViewMessages.UnknownCommand);
                                }
                            }
                            break;
                        default:
                            Console.WriteLine(ViewMessages.UnknownCommand);
                            break;
                    }
                    break;
                default:
                    Console.WriteLine(ViewMessages.UnknownCommand);
                    break;
            }


        }

        /// <summary>
        /// Импорт департаментов
        /// </summary>
        /// <returns></returns>
        private async Task ImportDepartments()
        {
            Console.WriteLine("Введите путь к TSV файлу");
            var input = Console.ReadLine();

            if (input != null)
            {
                try
                {
                    await departmentsController.ImportDepartmentsAsync(input);
                }
                catch (Exception)
                {
                    throw;
                }
                
            }

        }

        /// <summary>
        /// Импорт сотрудников
        /// </summary>
        /// <returns></returns>
        private async Task ImportEmployees()
        {
            Console.WriteLine("Введите путь к TSV файлу");
            var input = Console.ReadLine();

            if (input != null)
            {
                try
                {
                    await employeesController.ImportEmployeesAsync(input);
                }
                catch (Exception)
                {
                    throw;
                }

            }

        }

        /// <summary>
        /// Импорт должностей
        /// </summary>
        /// <returns></returns>
        private async Task ImportJobTitles()
        {
            Console.WriteLine("Введите путь к TSV файлу JobTitles");
            var input = Console.ReadLine();

            if (input != null)
            {
                try
                {
                    await jobTitleController.ImportJobTitlesAsync(input);
                }
                catch (Exception)
                {
                    throw;
                }

            }

        }

    }
}
