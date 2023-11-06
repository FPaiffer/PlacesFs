using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesFS.Models.Dtos
{
    public class GetPlacesRequest
    {

        public string query { get; set; }
        public float longitude { get; set; }
        public float latitude { get; set; }


    }
}
