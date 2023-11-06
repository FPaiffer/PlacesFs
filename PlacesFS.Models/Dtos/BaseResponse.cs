using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesFS.Models.Dtos
{
	public class BaseResponse
	{
		public object? results { get; set; }
		public Context context { get; set; }

		public class Context
		{
			public Geo_Bounds geo_bounds { get; set; }
		}

		public class Geo_Bounds
		{
			public Circle circle { get; set; }
		}

		public class Circle
		{
			public Center center { get; set; }
			public int radius { get; set; }
		}

		public class Center
		{
			public float latitude { get; set; }
			public float longitude { get; set; }
		}
	}
}
