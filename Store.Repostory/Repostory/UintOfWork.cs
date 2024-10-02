using Store.Data.Context;
using Store.Data.Entities;
using Store.Repostory.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repostory.Repostory
{
    public class UintOfWork : IUintOfWork
    {
        private readonly StoreDBContext _context;
        private  Hashtable _repostory;
        public UintOfWork(StoreDBContext context)
        {
           _context = context;
        }
        public async Task<int> ComplateAsync()
            =>await _context.SaveChangesAsync();

        public IgenericRepostory<TEntity, Tkey> Repostory<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            if (_repostory == null) 
                _repostory= new Hashtable();
            var entityKey=typeof(TEntity).Name;
            if (!_repostory.ContainsKey(entityKey))
            {
                var repstoryType=typeof(GenericRepostory<,>);
                var repostoryIntance=Activator.CreateInstance(repstoryType.MakeGenericType(typeof(TEntity),typeof(Tkey)),_context);
                _repostory.Add(entityKey,repostoryIntance);
            }
            return (IgenericRepostory<TEntity, Tkey>)_repostory[entityKey];
        }
    }
}
