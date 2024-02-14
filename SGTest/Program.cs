using SGTest.Contexts;
using SGTest.Controllers;
using SGTest.Repoitories;
using SGTest.Services;
using SGTest.Views;
using Unity;

var unityContainer = new UnityContainer();

unityContainer.RegisterType<Context>();

unityContainer.RegisterType<IDepartmentImportService, DepartmentsImportService>();
unityContainer.RegisterType<IEmployeesImportService, EmployeesImportService>();
unityContainer.RegisterType<IJobTitleImportService, JobTitleImportService>();

unityContainer.RegisterType<IDepartmentRepository, DepartmentRepository>();
unityContainer.RegisterType<IEmployeeRepository, EmployeeRepository>();
unityContainer.RegisterType<IJobTitleRepository, JobTitleRepository>();

unityContainer.RegisterType<IDepartmentsController, DepartmentsController>();
unityContainer.RegisterType<IEmployeesController, EmployeesController>();
unityContainer.RegisterType<IJobTitleController, JobTitleController>();

var view = unityContainer.Resolve<ConsoleView>();
await view.RunAsync();