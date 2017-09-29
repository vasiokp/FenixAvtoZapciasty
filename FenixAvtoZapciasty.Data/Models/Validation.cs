using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FenixAvtoZapciasty
{
	public static class Validation
	{

		public static string GetMessage(ValidationStatus vs)
		{
			switch (vs)
			{
				case ValidationStatus.OK:
					return "OK";
				case ValidationStatus.ADDED:
					return "Object was added";
				case ValidationStatus.NOT_UNIQUE:
					return "Object is not unique";
				case ValidationStatus.NULL_ERROR:
					return "Object is null";
				default: return "Unknow error";
				}

		}
	}

	public enum ValidationStatus
	{
		OK, ADDED, NULL_ERROR,NOT_UNIQUE,UNKNOW_ERROR
	}
}