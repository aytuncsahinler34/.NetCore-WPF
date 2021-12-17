using Microsoft.Extensions.DependencyInjection;
using ProposalDemo.Business.Abstract;
using ProposalDemo.Business.Concrete;
using ProposalDemo.Core.Interfaces;
using ProposalDemo.Core.Services;
using ProposalDemo.DataAccess.Abstract;
using ProposalDemo.DataAccess.Concrete.Ef;
using System.Windows;

namespace ProposalDemo
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private readonly ServiceProvider _serviceProvider;

		public App() {
			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);
			_serviceProvider = serviceCollection.BuildServiceProvider();
		}
		private void Application_Startup(object sender, StartupEventArgs e) {
			var mainWindow = _serviceProvider.GetService<MainWindow>();
			mainWindow.Show();
		}

		private static void ConfigureServices(ServiceCollection services) {
			services.AddScoped<IProductProposalBusiness, ProductProposalBusiness>();
			services.AddScoped<IProductProposalDal, ProductProposalDal>();
			services.AddScoped<ISompoIntegrationService, SompoIntegrationService>();
			services.AddScoped<MainWindow>();
		}
	}
}
