namespace ProposalDemo.Core.Models.Requests
{
	public class ProductProposalRequest
	{
		public Authentication Authentication { get; set; }
		public Object Object { get; set; }
	}

	public class Authentication
	{
		public string Source { get; set; }
		public string Key { get; set; }
	}

	public class Object
	{
		public long ProposalNo { get; set; }
		public int EndorsNo { get; set; }
		public int RenewalNo { get; set; }
		public string ProductNo { get; set; }
	}
}
