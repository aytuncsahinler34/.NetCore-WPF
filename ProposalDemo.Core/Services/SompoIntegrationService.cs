using ProposalDemo.Core.Enums;
using ProposalDemo.Core.Helpers;
using ProposalDemo.Core.Interfaces;
using ProposalDemo.Core.Models.Args;
using ProposalDemo.Core.Models.Requests;
using ProposalDemo.Core.Models.Responses;
using System.Threading.Tasks;

namespace ProposalDemo.Core.Services
{
	public class SompoIntegrationService : ISompoIntegrationService
	{
		public  ProductProposalResponse GetProductProposal(FilterProductProposalArgs filterProductProposalArgs) 
		{

			ProductProposalRequest productProposalRequest = new ProductProposalRequest() 
			{
				Authentication = new Authentication() 
				{
					Source = filterProductProposalArgs.Source,
					Key = filterProductProposalArgs.Key
				},
				Object = new Object() {
					EndorsNo = filterProductProposalArgs.EndorsNo,
					ProposalNo = filterProductProposalArgs.ProposalNo,
					ProductNo = filterProductProposalArgs.ProductNo,
					RenewalNo = filterProductProposalArgs.RenewalNo
				}
			};

			return  HttpHelper.HttpRequest<ProductProposalResponse>(filterProductProposalArgs.BaseUrl, "sample/engine", HttpMethodEnum.POST, productProposalRequest, null, null);

		}
	}
}
