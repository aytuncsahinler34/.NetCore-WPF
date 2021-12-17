using Microsoft.EntityFrameworkCore;
using ProposalDemo.Entities.Concrete;

namespace ProposalDemo.DataAccess.Concrete.Ef
{
	public class EntityContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlServer("server=AYTUNC-PC\\SQLEXPRESS;database=ProductProposalDemo;integrated security=true;TrustServerCertificate=True");
		}

		public DbSet<ProductProposalInfo> ProductProposalInfo { get; set; }
	}
}
