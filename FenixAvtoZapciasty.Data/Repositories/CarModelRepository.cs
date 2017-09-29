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

		public IEnumerable<CarModel> GetAll()
		{
			return _db.CarModels.ToList();
		}

		public CarModel GetById(int id)
		{
			if (id > 0)
			{
				var model = from d in _db.CarModels
							 where d.Id == id
							 select d;
				return model.SingleOrDefault();
			}
			return null;
		}

		public void Add(CarModel obj)
		{
			if (obj != null)
			{
				_db.CarModels.Add(obj);
				_db.SaveChanges();
			}
		}

		public void Update(CarModel obj)
		{
			if (obj != null)
			{
				var modelToUpdate = _db.CarModels.SingleOrDefault(d => d.Id == obj.Id);
				if (modelToUpdate != null)
				{
					modelToUpdate.Name = obj.Name;
					modelToUpdate.Description = obj.Description;
					_db.SaveChanges();
				}
			}
		}

		public void Delete(int id)
		{
			if (id > 0)
			{
				var model = _db.CarModels.Where(d => d.Id == id).SingleOrDefault();
				if (model != null)
				{
					_db.CarModels.Remove(model);
					_db.SaveChanges();
				}
			}
		}

		public void Dispose()
		{
			_db.Dispose();
		}
	}
}