using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repostory.Interfaces
{
    public interface IgenericRepostory<TEnity,Tkey> where TEnity : BaseEntity< Tkey>  
    {
        Task<TEnity> GetByIdAsync(Tkey? Id );   
        Task<IReadOnlyList<TEnity>> GetAllAsync();
        Task AddAsync(TEnity entity);
        void Update(TEnity entity);
        void Delete(TEnity entity);
    }
}
