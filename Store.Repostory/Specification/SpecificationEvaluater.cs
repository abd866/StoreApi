using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repostory.Specification
{
    public class SpecificationEvaluater<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        public static IQueryable<TEntity> GetQeury(IQueryable<TEntity> Inputquery, ISpecification<TEntity> spesc) {

            var qurey = Inputquery;
            if (spesc.Cerietria is not null)
                qurey = qurey.Where(spesc.Cerietria);

            if(spesc.Order is not null)
                qurey= qurey.OrderBy(spesc.Order);

            if (spesc.OrderByDesc is not null)
                qurey = qurey.OrderByDescending(spesc.OrderByDesc);

            if(spesc.isPaginged)
                qurey = qurey.Skip(spesc.Skip).Take(spesc.Take);
            qurey = spesc.Include.Aggregate(qurey, (current, IncludeExpression) => current.Include(IncludeExpression));
            return qurey;
        
        
        
        
        }
    }
}
