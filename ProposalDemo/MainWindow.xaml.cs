using ProposalDemo.Business.Abstract;
using ProposalDemo.Core.Enums;
using ProposalDemo.Core.Interfaces;
using ProposalDemo.Core.Models.Args;
using ProposalDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProposalDemo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly ISompoIntegrationService _sompoIntegrationService;
		private readonly IProductProposalBusiness _productProposalBusiness;
		public MainWindow(ISompoIntegrationService sompoIntegrationService, IProductProposalBusiness productProposalBusiness) {
			_sompoIntegrationService = sompoIntegrationService;
			_productProposalBusiness = productProposalBusiness;
			InitializeComponent();
		}

		private void button_Click(object sender, RoutedEventArgs e) 
		{
			if ( string.IsNullOrEmpty(textBoxProductNo.Text) || string.IsNullOrEmpty(textBoxEndorsNo.Text) || string.IsNullOrEmpty(textBoxProposalNo.Text) || string.IsNullOrEmpty(textBoxRenewalNo.Text))
			{
				MessageBox.Show("Tüm alanları doldurunuz!");
			}
			else 
			{
				#region GetFilterData
				string baseUrl = ConfigurationManager.AppSettings["baseUrl"].ToString();
				string source = ConfigurationManager.AppSettings["source"].ToString();
				string key = ConfigurationManager.AppSettings["key"].ToString();
				FilterProductProposalArgs filterProductProposalArgs = new FilterProductProposalArgs() {
					ProposalNo = Convert.ToInt64(textBoxProposalNo.Text),
					ProductNo = textBoxProductNo.Text,
					EndorsNo = Convert.ToInt32(textBoxEndorsNo.Text),
					RenewalNo = Convert.ToInt32(textBoxRenewalNo.Text),
					Source = source,
					BaseUrl = baseUrl,
					Key = key
				};
				#endregion

				#region AddEntity
				ProductProposalInfo productProposalInfo = new ProductProposalInfo() 
				{
					ProposalNo = filterProductProposalArgs.ProposalNo,
					ProductNo = filterProductProposalArgs.ProductNo,
					EndorsNo = filterProductProposalArgs.EndorsNo,
					RenewalNo = filterProductProposalArgs.RenewalNo,
					CreatedDate = DateTimeOffset.Now,
					Creator = 0
			    };

			    _productProposalBusiness.Add(productProposalInfo);
				#endregion

				var productProposalResponse = _sompoIntegrationService.GetProductProposalAsync(filterProductProposalArgs).Result;
				//entity update işlemi eklenmesi lazım sadece.
				if (productProposalResponse.Data.Any()) 
				{
					dataGridPositive.ItemsSource = productProposalResponse.Data.Where(x => x.Status.Name == ProductProposalStatusEnum.Positive.ToString()).Select(x => x.Description).ToList();
					dataGridInfo.ItemsSource = productProposalResponse.Data.Where(x => x.Status.Name == ProductProposalStatusEnum.Info.ToString()).Select(x => x.Description).ToList();
					dataGridNegative.ItemsSource = productProposalResponse.Data.Where(x => x.Status.Name == ProductProposalStatusEnum.Negative.ToString()).Select(x => x.Description).ToList();
				}
			}
			
		}
	}
}
