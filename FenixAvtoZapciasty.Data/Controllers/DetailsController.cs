using System.Collections.Generic;
using System.Web.Http;
using FenixAvtoZapciasty.Data.DataContext;
using FenixAvtoZapciasty.Data.Repositories;

namespace FenixAvtoZapciasty.Data.Controllers
{
	[RoutePrefix("api/details")]
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
		public RequestStatus<Detail> Add(Detail detail)
		{
			RequestStatus<Detail> request = new RequestStatus<Detail>();
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
		public RequestStatus<Detail> Update(Detail detail)
		{
			RequestStatus<Detail> request = new RequestStatus<Detail>();
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
		public RequestStatus<Detail> Delete(int id)
		{
			RequestStatus<Detail> request = new RequestStatus<Detail>();
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