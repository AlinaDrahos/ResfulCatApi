using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulCatApi.Models
{
    public class Owner
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Cat> MyCats { get; set; }
        public int Id { get; set; }
    }
}
