using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Data.Entities;
using Store.Repostory.Interfaces;
using Store.Repostory.Specification;
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
        public async Task<IReadOnlyList<TEntity>> GetWithSpecificationAllAsync(ISpecification<TEntity> SPEC)
            =>await SpecificationEvaluater<TEntity,TKey>.GetQeury(_context.Set<TEntity>(), SPEC).ToListAsync();

        public async Task<TEntity> GetWithSpecificationByIdAsync(ISpecification<TEntity> SPEC)
           => await SpecificationEvaluater<TEntity, TKey>.GetQeury(_context.Set<TEntity>(), SPEC).FirstOrDefaultAsync();
        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> SPEC)
            => SpecificationEvaluater<TEntity, TKey>.GetQeury(_context.Set<TEntity>(), SPEC);

        public async  Task<int> GetCountSpecifcationAsync(ISpecification<TEntity> SPEC)
        => await ApplySpecification(SPEC).CountAsync();
    }
}
