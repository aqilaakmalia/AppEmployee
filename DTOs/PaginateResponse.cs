using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppEmployee.DTOs
{
    public class PaginatedResponse<T>
    {
        public IEnumerable<T>? Items { get; set; }
        public int TotalData { get; set; } 
        public int CurrentPage { get; set; } 
        public int TotalPages { get; set; }
    }

}