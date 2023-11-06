using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesFS.Infrastructure.Data.Context
{

	public class DbInitializer
	{
		private readonly ModelBuilder modelBuilder;
		public DbInitializer(ModelBuilder modelBuilder)
		{
			this.modelBuilder = modelBuilder;
		}
		public void Seed()
		{
			//modelBuilder.Entity<ExampleModel>().HasData(
			//	   new ExampleModel() { Id = 1, Name = "Example Name 1" },
			//	   new ExampleModel() { Id = 2, Name = "Example Name 2" },
			//	   new ExampleModel() { Id = 3, Name = "Example Name 3" }
			//);

		}
	}
}
