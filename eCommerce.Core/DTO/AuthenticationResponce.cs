using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.DTO;

    public record AuthenticationResponce(Guid UserID, 
        string? Email,
        string? PersonName,
        string? Gender,
        string? Token,
        bool Sucess)
{
    // Defult Constructore
    public AuthenticationResponce() : this(default, default, default, default,default,default)
        { }
}
    

