﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FenixAvtoZapciasty.Data.Repositories
{
	public interface IRepository<T> where T: class
	{
		IEnumerable<T> GetAll();
		T GetById(int id);
		void Add(T obj);
		void Update(T obj);
		void Delete(int id);
	}
}