using ProposalDemo.Core.DataAccess.Ef;
using ProposalDemo.DataAccess.Abstract;
using ProposalDemo.Entities.Concrete;

namespace ProposalDemo.DataAccess.Concrete.Ef
{
	public class ProductProposalDal : EfEntityRepositoryBase<ProductProposalInfo, EntityContext>, IProductProposalDal
	{

	}
}
