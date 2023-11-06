using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesFS.Models.Dtos
{
    public class FavoritePlaceDto : BaseDto
    {
        public string fsq_id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float? rating { get; set; }
        public string CategorysName { get; set; }
        public string ImagesSeparatedByPipes { get; set; }
        public string TipsSeparatedByPipes { get; set; }
    }
}
