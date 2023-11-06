using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesFS.Models.Dtos
{
	public class LanguageDto : BaseDto
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public string Icon { get; set; }
		public string Demonym { get; set; }
	}
}
