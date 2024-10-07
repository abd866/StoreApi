using Store.Data.Entities;
using Store.Repostory.Specification;
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
        Task<TEnity> GetWithSpecificationByIdAsync(ISpecification<TEnity> SPEC);
        Task<IReadOnlyList<TEnity>> GetWithSpecificationAllAsync(ISpecification<TEnity> SPEC);
        Task<int> GetCountSpecifcationAsync(ISpecification<TEnity> SPEC);
        Task AddAsync(TEnity entity);
        void Update(TEnity entity);
        void Delete(TEnity entity);
    }
}
