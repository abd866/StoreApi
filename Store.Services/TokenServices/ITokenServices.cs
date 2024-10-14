using Store.Data.Entities.IdentityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.TokenServices
{
    public interface ITokenServices
    {
        public string GnerateToken(AppUser appUser);
    }
}
