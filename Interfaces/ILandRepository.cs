using System;
using Pokemon.Data;
using Pokemon.Models;
using Pokemon.Repository;
namespace Pokemon.Interfaces
{
	public interface ILandRepository
	{
		ICollection<Land> GetLand();

		Land GetLand(int id);

		Land GetLandFraEier(int eierId);

		ICollection<Eier> GetEiereFraLand(int landId);

		bool CountryExists(int id);

	}
}

