using ProposalDemo.Business.Abstract;
using ProposalDemo.Core.Interfaces;
using ProposalDemo.Core.Models.Args;
using ProposalDemo.Core.Models.Responses;
using ProposalDemo.Entities.Concrete;
using System;
using System.Linq;
using System.Windows;

namespace ProposalDemo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly ISompoIntegrationService _sompoIntegrationService;
		private readonly IProductProposalBusiness _productProposalBusiness;
		private readonly string baseUrl = "https://apitest.sompojapan.com.tr/";
		private readonly string source = "SOMPO";
		private readonly string key = "77lTCSn41w";
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
				//string baseUrl = ConfigurationManager.AppSettings["baseUrl"].ToString();
				//string source = ConfigurationManager.AppSettings["source"].ToString();
				//string key = ConfigurationManager.AppSettings["key"].ToString();
				//yukarıdaki şekilde de veriler alınabilir.
				
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

			    var insertItem =_productProposalBusiness.Add(productProposalInfo);
				#endregion

				#region Update Entity
				var productProposalResponse = _sompoIntegrationService.GetProductProposal(filterProductProposalArgs);
				
				if (productProposalResponse.Results.Any()) 
				{
					dataGridPositive.ItemsSource = productProposalResponse.Results.Where(x => x.Status.Value == "1").Select(x => new Data { Description = x.Description }).ToList();
					dataGridInfo.ItemsSource = productProposalResponse.Results.Where(x => x.Status.Value == "2").Select(x => new Data { Description = x.Description }).ToList();
					dataGridNegative.ItemsSource = productProposalResponse.Results.Where(x => x.Status.Value == "3").Select(x => new Data { Description = x.Description }).ToList();
					insertItem.Response = Newtonsoft.Json.JsonConvert.SerializeObject(productProposalResponse.Results);
					_productProposalBusiness.Update(insertItem);
				}
				#endregion
			}

		}
	}
}
