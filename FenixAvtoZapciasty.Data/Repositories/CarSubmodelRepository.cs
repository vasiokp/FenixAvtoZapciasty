﻿using FenixAvtoZapciasty.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FenixAvtoZapciasty.Data.Repositories
{
	public class CarSubmodelRepository : IRepository<CarSubmodel>, IDisposable
	{
		private readonly AutoPartsModel _db = new AutoPartsModel();
		

		public void Add(CarSubmodel obj)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			_db.Dispose();
		}

		public IEnumerable<CarSubmodel> GetAll()
		{
			return _db.CarSubmodel.ToList();
		}

		public CarSubmodel GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(CarSubmodel obj)
		{
			throw new NotImplementedException();
		}
	}
}