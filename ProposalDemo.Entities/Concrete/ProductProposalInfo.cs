using ProposalDemo.Core.Entities;

namespace ProposalDemo.Entities.Concrete
{
	public class ProductProposalInfo : DbObjectBase, IEntity
	{
		public string ProductNo { get; set; }
		public int EndorsNo { get; set; }
		public int RenewalNo { get; set; }
		public long ProposalNo { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public string Value { get; set; }
		public string Name { get; set; }
	}
}
