using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.HandlleResponse
{
    public class ValditionErrorRespons : CustomExpetions
    {
        public ValditionErrorRespons() : base(400,null,null)
        {
        }
        public IEnumerable<string> Errors { get; set; }
    }
}
