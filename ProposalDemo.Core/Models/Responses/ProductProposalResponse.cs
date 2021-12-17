using System.Collections.Generic;

namespace ProposalDemo.Core.Models.Responses
{
	public class ProductProposalResponse
	{
		public List<Data> Data { get; set; }
	}

	public class Data
	{
		public string Code { get; set; }
		public string Description { get; set; }
		public Status Status { get; set; }
	}

	public class Status
	{
		public string Value { get; set; }
		public string Name { get; set; }
	}
}
