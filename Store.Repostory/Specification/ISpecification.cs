using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repostory.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>> Cerietria{ get;  }
       List<Expression<Func<T,object>>> Include{ get;  }

        Expression<Func<T, object>> Order { get; }
        Expression<Func<T, object>> OrderByDesc { get; }
        int Take {  get; }
        int Skip { get; }
        bool isPaginged {  get; }
    }
}
