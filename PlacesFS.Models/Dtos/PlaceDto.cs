using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesFS.Models.Dtos
{
    public class PlaceDto
    {

        public string fsq_id { get; set; }
        public string link { get; set; }
        public Location location { get; set; }
        public Geocodes geocodes { get; set; }
        public List<Categories> categories { get; set; }
        public string name { get; set; }
        public float? rating { get; set; }

        public class Location
        {
            public string address { get; set; }
            public string country { get; set; }
            public string cross_street { get; set; }
            public string formatted_address { get; set; }
            public string locality { get; set; }
            public string postcode { get; set; }
            public string region { get; set; }
        }

    }

    public class Categories
    {
        public string short_name { get; set; }
        public Icon icon { get; set; }
    }

    public class Icon
    {
        public string prefix { get; set; }
        public string suffix { get; set; }
    }

    public class Geocodes
    {
        public Main main { get; set; }
    }

    public class Main
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}
