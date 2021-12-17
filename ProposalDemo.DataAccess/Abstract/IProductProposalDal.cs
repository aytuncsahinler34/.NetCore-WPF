using ProposalDemo.Core.DataAccess;
using ProposalDemo.Entities.Concrete;

namespace ProposalDemo.DataAccess.Abstract
{
	public interface IProductProposalDal : IBaseRepository<ProductProposalInfo>
	{
	}
}
