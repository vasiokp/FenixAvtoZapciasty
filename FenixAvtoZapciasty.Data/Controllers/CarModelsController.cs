using FenixAvtoZapciasty.Data.DataContext;
using FenixAvtoZapciasty.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FenixAvtoZapciasty.Data.Controllers
{
	[RoutePrefix("api/carmodels")]
	public class CarModelsController : ApiController
	{
		public IEnumerable<CarModel> Get()
		{
			using (var repo = new CarModelRepository()) {
				return repo.GetAll();
			}
		}

		public CarModel Get(int id)
		{
			using (var model = new CarModelRepository())
			{
				return model.GetById(id);
			}
		}

		[Route("Add")]
		public RequestStatus Add(CarModel model)
		{
			RequestStatus request = new RequestStatus();
			if (model == null)
			{
				request.IsSucces = false;
				request.Message = Validation.GetMessage(ValidationStatus.NULL_ERROR);
			}
			else
				using (var repo = new CarModelRepository())
				{
					repo.Add(model);
					if (model.Id > 0)
					{
						request.IsSucces = true;
						request.Message = Validation.GetMessage(ValidationStatus.ADDED);
					}
				}

			return request;
		}

		[Route("Update")]
		public RequestStatus Update(CarModel model)
		{
			RequestStatus request = new RequestStatus();
			if (model == null)
			{
				request.IsSucces = false;
				request.Message = Validation.GetMessage(ValidationStatus.NULL_ERROR);
			}
			else
				using (var repo = new CarModelRepository())
				{
					repo.Update(model);
					if (model.Id > 0)
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
			using (var repo = new CarModelRepository())
			{
				repo.Delete(id);
				request.IsSucces = true;
				request.Message = Validation.GetMessage(ValidationStatus.OK);
			}
			return request;
		}
	}
}