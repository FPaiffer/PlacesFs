using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesFS.Domain.Entities
{
    public class FavoritePlace : EntityBase
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
