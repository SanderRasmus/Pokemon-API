using Microsoft.EntityFrameworkCore;
using Pokemon.Models;

namespace Pokemon.Data
{
	public class Datakontekst : DbContext
	{
		public Datakontekst(DbContextOptions<Datakontekst> options) : base(options)
		{

		}

		public DbSet<Kategori> Kategorier { get; set; }
		public DbSet<Land> Land { get; set; }
		public DbSet<Eier> Eiere { get; set; }
		public DbSet<Pokemons> Pokemon { get; set; }
		public DbSet<PokemonEier> PokemonEiere { get; set; }
		public DbSet<PokemonKategori> PokemonKategorier { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<PokemonKategori>()
				.HasKey(pc => new {pc.PokemonId, pc.KategoriId });
			modelBuilder.Entity<PokemonKategori>()
				.HasOne(p => p.Pokemon)
				.WithMany(pc => pc.PokemonKategori)
				.HasForeignKey(p => p.PokemonId);
			modelBuilder.Entity<PokemonKategori>()
				.HasOne(p => p.Kategori)
				.WithMany(pc => pc.PokemonKategori)
				.HasForeignKey(c => c.KategoriId);


			modelBuilder.Entity<PokemonEier>()
				.HasKey(po => new { po.PokemonId, po.EierId });
			modelBuilder.Entity<PokemonEier>()
				.HasOne(p => p.Pokemon)
				.WithMany(pc => pc.PokemonEiere)
				.HasForeignKey(p => p.PokemonId);
			modelBuilder.Entity<PokemonEier>()
				.HasOne(p => p.Eier)
				.WithMany(pc => pc.PokemonEier)
				.HasForeignKey(c => c.EierId);

        }
    }
}

