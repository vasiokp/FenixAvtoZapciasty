﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FenixAvtoZapciasty
{
	public class RequestStatus<T> where T:class

	{
		public bool IsSucces { get; set; }
		public string Message { get; set; }
		public T Data { get; set; }
	}
}