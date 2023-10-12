using R2Q.Application.Contracts.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2Q.Application.Contracts.Services
{
    public interface ITripService
    {
        Task UpdateAsync(TripData trip, string accessToken);
    }
}
