using FenixAvtoZapciasty.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FenixAvtoZapciasty.Data.Repositories
{
	public class CarModelRepository : IDisposable
	{
		private readonly AutoPartsContext _db = new AutoPartsContext();

		public List<CarModel> GetCarModels()
		{
			return (from c in _db.CarModels select c).ToList();
		}

		public void Dispose()
		{
			_db.Dispose();
		}
	}
}