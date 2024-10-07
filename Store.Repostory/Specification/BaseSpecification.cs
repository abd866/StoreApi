using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repostory.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> cretria)
        {
            Cerietria=cretria;
        }
        public Expression<Func<T, bool>> Cerietria{ get; }

        public List<Expression<Func<T, object>>> Include { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> Order { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool isPaginged { get; private set; }

        protected void AddIncluded(Expression<Func<T, object>> includeExpression) 
            => Include.Add(includeExpression);

        protected void AddOrderBy(Expression<Func<T, object>> OrderExpression)
            => Order = OrderExpression;

        protected void AddOrderByDes(Expression<Func<T, object>> OrderDesExpression)
          => OrderByDesc = OrderDesExpression;
        protected void ApplyPaginaging(int take ,int skip)
        {
            Take = take;
            Skip = skip;
            isPaginged = true;
        }
    }
}
