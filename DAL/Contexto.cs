using Microsoft.EntityFrameworkCore;
using PeopleApp.Models;

namespace PeopleApp.DAL;

public class Contexto : DbContext
{
	public Contexto(DbContextOptions<Contexto> options) : base(options)
	{

	}

	public DbSet<Personas> Personas { get; set; }
}
