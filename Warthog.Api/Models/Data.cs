using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warthog.Api.Models
{
    public class Data
    {
        public List<string> FirstNames { get; set; }
        public List<string> LastNames { get; set; }
        public List<int> Gpas { get; set; }
        public List<string> Houses { get; set; }
    }
}
