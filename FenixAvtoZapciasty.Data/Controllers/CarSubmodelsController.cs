using FenixAvtoZapciasty.Data.DataContext;
using FenixAvtoZapciasty.Data.Repositories;
using System.Collections.Generic;
using System.Web.Http;

namespace FenixAvtoZapciasty.Data.Controllers
{
	[RoutePrefix("api/carsubmodels")]
	public class CarSubmodelsController : ApiController
	{
		public IEnumerable<CarSubmodel> Get()
		{
			using (var repo = new CarSubmodelRepository())
			{
				return repo.GetAll();
			}
		}

		public CarSubmodel Get(int id)
		{
			using (var model = new CarSubmodelRepository())
			{
				return model.GetById(id);
			}
		}

		[Route("Add")]
		public RequestStatus<CarSubmodel> Add(CarSubmodel model)
		{
			RequestStatus<CarSubmodel> request = new RequestStatus<CarSubmodel>();
			if (model == null)
			{
				request.IsSucces = false;
				request.Message = Validation.GetMessage(ValidationStatus.NULL_ERROR);
			}
			else
				using (var repo = new CarSubmodelRepository())
				{
					repo.Add(model);
					if (model.Id > 0)
					{
						request.IsSucces = true;
						request.Message = Validation.GetMessage(ValidationStatus.ADDED);
						request.Data = model;
					}
				}

			return request;
		}

		[Route("Update")]
		public RequestStatus<CarSubmodel> Update(CarSubmodel model)
		{
			RequestStatus<CarSubmodel> request = new RequestStatus<CarSubmodel>();
			if (model == null)
			{
				request.IsSucces = false;
				request.Message = Validation.GetMessage(ValidationStatus.NULL_ERROR);
			}
			else
				using (var repo = new CarSubmodelRepository())
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
		public RequestStatus<CarSubmodel> Delete(int id)
		{
			RequestStatus<CarSubmodel> request = new RequestStatus<CarSubmodel>();
			using (var repo = new CarSubmodelRepository())
			{
				repo.Delete(id);
				request.IsSucces = true;
				request.Message = Validation.GetMessage(ValidationStatus.OK);
			}
			return request;
		}
	}
}
