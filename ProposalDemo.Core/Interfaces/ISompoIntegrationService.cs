using ProposalDemo.Core.Models.Args;
using ProposalDemo.Core.Models.Responses;

namespace ProposalDemo.Core.Interfaces
{
	public interface ISompoIntegrationService
	{
		ProductProposalResponse GetProductProposal(FilterProductProposalArgs filterProductProposalArgs);
	}
}
