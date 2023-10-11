using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleHub.Api.Contracts
{
    public class ValidationError
    {
        public string Field { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}