using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FenixAvtoZapciasty.Data.DataContext;
using FenixAvtoZapciasty.Data.Repositories;

namespace FenixAvtoZapciasty.Data.Controllers
{
	[System.Web.Http.RoutePrefix("api/details")]
	public class DetailsController : ApiController
	{
		//[System.Web.Http.Route("GetSubModels")]
		public IEnumerable<Detail> Get()
		{
			using(var details = new DetailRepository())
			{
				return details.GetAll();
			}
		}

	}
}