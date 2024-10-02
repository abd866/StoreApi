using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Data.Entities;
using Store.Repostory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repostory.Repostory
{
    public class GenericRepostory<TEntity, TKey> : IgenericRepostory<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDBContext _context;

        public GenericRepostory(StoreDBContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity)
          => await _context.Set<TEntity>().AddAsync(entity);

        public void Delete(TEntity entity)
           =>  _context.Set<TEntity>().Remove(entity);

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
          => await _context.Set<TEntity>().ToListAsync();
        public async Task<TEntity> GetByIdAsync(TKey? Id)
             => await _context.Set<TEntity>().FindAsync(Id);


        public void Update(TEntity entity)
              => _context.Set<TEntity>().Update(entity);

    }
}
