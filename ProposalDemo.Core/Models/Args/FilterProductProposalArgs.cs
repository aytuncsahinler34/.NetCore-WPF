namespace ProposalDemo.Core.Models.Args
{
	public class FilterProductProposalArgs
	{
		public long ProposalNo { get; set; }
		public int EndorsNo { get; set; }
		public string ProductNo { get; set; }
		public int RenewalNo { get; set; }
		public string Source { get; set; }
		public string BaseUrl { get; set; }
		public string Key { get; set; }
	}
}
