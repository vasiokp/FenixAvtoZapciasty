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
		public IEnumerable<Detail> Get()
		{
			using(var details = new DetailRepository())
			{
				return details.GetAll();
			}
		}

		public Detail Get(int id)
		{
			using(var detailt = new DetailRepository())
			{
				return detailt.GetById(id);
			}
		}

		[Route("Add")]
		public RequestStatus Add(Detail detail)
		{
			RequestStatus request = new RequestStatus();
			if (detail == null) {
				request.IsSucces = false;
				request.Message = Validation.GetMessage(ValidationStatus.NULL_ERROR);
			}
			else
				using (var repo = new DetailRepository())
				{
					repo.Add(detail);
					if (detail.Id > 0)
					{
						request.IsSucces = true;
						request.Message = Validation.GetMessage(ValidationStatus.ADDED);
					}
				}

			return request;
		}

		[Route("Update")]
		public RequestStatus Update(Detail detail)
		{
			RequestStatus request = new RequestStatus();
			if (detail == null) {
				request.IsSucces = false;
				request.Message = Validation.GetMessage(ValidationStatus.NULL_ERROR);
			}
			else
				using (var repo = new DetailRepository())
				{
					repo.Update(detail);
					if (detail.Id > 0)
					{
						request.IsSucces = true;
						request.Message = Validation.GetMessage(ValidationStatus.OK);
					}
				}

			return request;
		}

		[Route("Delete/{id}")]
		[HttpPost]
		public RequestStatus Delete(int id)
		{
			RequestStatus request = new RequestStatus();
			using (var repo = new DetailRepository())
			{
				repo.Delete(id);
				request.IsSucces = true;
				request.Message = Validation.GetMessage(ValidationStatus.OK);
			}
			return request;
		}
	}
}