using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2Q.Application.Dtos.Vendor
{
    public class VendorDto
    {
        public string Name { get; set; }

        public static implicit operator VendorDto(ResponseDto<VendorDto> v)
        {
            throw new NotImplementedException();
        }
    }
}
