using ProposalDemo.Core.Entities;

namespace ProposalDemo.Entities.Concrete
{
	public class ProductProposalInfo : DbObjectBase, IEntity
	{
		public string ProductNo { get; set; }
		public int EndorsNo { get; set; }
		public int RenewalNo { get; set; }
		public long ProposalNo { get; set; }
		public string Response { get; set; }
	}
}
