using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2Q.Application.Contracts.Services.Models
{
    public class TripData
    {
        public List<TripDataItem> Items { get; set; } = new List<TripDataItem>();
    }
}
