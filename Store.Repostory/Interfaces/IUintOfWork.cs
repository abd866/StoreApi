using Store.Data.Entities;
using Store.Repostory.Repostory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repostory.Interfaces
{
    public interface IUintOfWork
    {
        IgenericRepostory<TEntity,Tkey>Repostory<TEntity,Tkey >() where TEntity : BaseEntity<Tkey>;
        Task<int> ComplateAsync();
    }
}
