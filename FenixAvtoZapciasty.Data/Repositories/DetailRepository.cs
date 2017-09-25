using FenixAvtoZapciasty.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FenixAvtoZapciasty.Data.Repositories
{
	public class DetailRepository : IRepository<Detail>, IDisposable
	{

		private readonly AutoPartsModel _db = new AutoPartsModel();

		public void Add(Detail obj)
		{
			if(obj != null)
			{
				_db.Detail.Add(obj);
				_db.SaveChanges();
			}
		}

		public void Delete(int id)
		{
			if(id > 0)
			{
				var detail = _db.Detail.Where(d => d.Id == id).SingleOrDefault();
				if (detail != null)
				{
					_db.Detail.Remove(detail);
					_db.SaveChanges();
				}
			}
		}

		public void Dispose()
		{
			_db.Dispose();
		}

		public IEnumerable<Detail> GetAll()
		{
			return _db.Detail.ToList();
		}

		public Detail GetById(int id)
		{
			if (id > 0)
			{
				var detail = from d in _db.Detail
							 where d.Id == id
							 select d;
				return detail.SingleOrDefault();
			}
			return null;
		}

		public void Update(Detail obj)
		{
			if (obj != null)
			{
				var detailToUpdate = _db.Detail.SingleOrDefault(d => d.Id == obj.Id);
				if (detailToUpdate != null)
				{
					detailToUpdate.Name = obj.Name;
					detailToUpdate.Price = obj.Price;
					detailToUpdate.Description = obj.Description;
					detailToUpdate.CategoryId = obj.CategoryId;
					detailToUpdate.CarSubmodelId = obj.CarSubmodelId;
					_db.SaveChanges();
				}
			}
		}
	}
}