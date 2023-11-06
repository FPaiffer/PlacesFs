using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesFS.Models.Dtos
{
    public class PlaceTips
    {
        public string id { get; set; }
        public DateTime created_at { get; set; }
        public string text { get; set; }

    }
}
