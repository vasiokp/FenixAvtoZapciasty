﻿using FenixAvtoZapciasty.Data.DataContext;
using FenixAvtoZapciasty.Data.Repositories;
using System.Collections.Generic;
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
		public RequestStatus<CarModel> Add(CarModel model)
		{
			RequestStatus<CarModel> request = new RequestStatus<CarModel>();
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
						request.Data = model;
					}
				}

			return request;
		}

		[Route("Update")]
		public RequestStatus<CarModel> Update(CarModel model)
		{
			RequestStatus<CarModel> request = new RequestStatus<CarModel>();
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
		public RequestStatus<CarModel> Delete(int id)
		{
			RequestStatus<CarModel> request = new RequestStatus<CarModel>();
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