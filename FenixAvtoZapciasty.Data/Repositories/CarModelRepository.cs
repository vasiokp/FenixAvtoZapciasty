using FenixAvtoZapciasty.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FenixAvtoZapciasty.Data.Repositories
{
	public class CarModelRepository : IDisposable
	{
		private readonly AutoPartsModel _db = new AutoPartsModel();

		public List<CarModel> GetCarModels()
		{
			return (from c in _db.CarModel select c).ToList();
		}

		public void Dispose()
		{
			_db.Dispose();
		}
	}
}