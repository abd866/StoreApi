using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.HandlleResponse
{
    public class CustomExpetions : Response
    {
        public CustomExpetions(int statusode, string? message, string? details) : base(statusode, message)
        {
            Details = details;
        }
        public string? Details { get; set; }
    }
}
