using FenixAvtoZapciasty.Data.DataContext;
using FenixAvtoZapciasty.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Http.Results;

namespace FenixAvtoZapciasty.Data.Controllers
{
	[System.Web.Http.RoutePrefix("api/values")]
	public class ValuesController : ApiController
	{
		// GET api/values
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		public List<CarModel> Get(int id)
		{
			using (var carRepository = new CarModelRepository())
			{
				var models = carRepository.GetCarModels();
				var result = new JsonResult();
				result.Data = models;
				result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
				return models;
			}
		}
		[System.Web.Http.Route("GetSubModels")]
		public IEnumerable<CarSubmodel> GetSubModels()
		{
			using (var carRepository = new CarSubmodelRepository())
			{
				var models = carRepository.GetAll();
				var result = new JsonResult();
				result.Data = models;
				result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
				return models;
			}
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
