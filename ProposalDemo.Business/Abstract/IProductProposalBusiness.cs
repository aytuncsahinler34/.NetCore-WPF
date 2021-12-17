using ProposalDemo.Entities.Concrete;
using System.Collections.Generic;

namespace ProposalDemo.Business.Abstract
{
	public interface IProductProposalBusiness
	{
		ProductProposalInfo GetById(int id);
		List<ProductProposalInfo> GetAll();
		ProductProposalInfo Add(ProductProposalInfo entity);
		ProductProposalInfo Update(ProductProposalInfo entity);
		void Delete(int id);
	}
}
