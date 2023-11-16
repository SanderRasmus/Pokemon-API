using System;
namespace Pokemon.Models
{
	public class Land
	{
		public int Id { get; set; }

		public string Navn { get; set; }

		public ICollection<Eier> Eiere { get; set; }


	}
}

