using ProposalDemo.Core.Models.Args;
using ProposalDemo.Core.Models.Responses;
using System.Threading.Tasks;

namespace ProposalDemo.Core.Interfaces
{
	public interface ISompoIntegrationService
	{
		Task<ProductProposalResponse> GetProductProposalAsync(FilterProductProposalArgs filterProductProposalArgs);
	}
}
