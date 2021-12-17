using ProposalDemo.Business.Abstract;
using ProposalDemo.DataAccess.Abstract;
using ProposalDemo.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace ProposalDemo.Business.Concrete
{
	public class ProductProposalBusiness : IProductProposalBusiness
	{
		private IProductProposalDal _productProposalDal;

		public ProductProposalBusiness(IProductProposalDal productProposalDal) {
			_productProposalDal = productProposalDal;
		}

		public ProductProposalInfo GetById(int id) {
			return _productProposalDal.GetById(id);
		}

		public List<ProductProposalInfo> GetAll() {
			return _productProposalDal.GetAll().ToList();
		}

		public ProductProposalInfo Add(ProductProposalInfo entity) {
			return _productProposalDal.Add(entity);
		}

		public void Delete(int id) {
			_productProposalDal.Delete(id);
		}

		public ProductProposalInfo Update(ProductProposalInfo entity) {
			return _productProposalDal.Update(entity);
		}
	}
}
