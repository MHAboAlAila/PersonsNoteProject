using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonsNoteBook.Core.Entities;
using PersonsNoteBook.Core.Interfaces;
using PersonsNoteBook.Infrastructure.Models;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace PersonsNoteBook.Infrastructure.Repositories
{
    public abstract class GenericRepository<TEntity, TModel> : IGenericRepository<TEntity> where TEntity : BaseEntity where TModel : BaseModel
    {
        protected readonly DBContextClass _dbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        protected GenericRepository(DBContextClass Context, IMapper mapper, IMediator mediator)
        {
            _dbContext = Context;
            _mapper = mapper;
            _mediator = mediator;
        }

        private async Task DispatchDomainEventsAsync(TEntity entity)
        {
            if (entity.DomainEvents != null)
            {
                var events = entity.DomainEvents.ToArray();
                entity.ClearDomainEvents();
                foreach (var entityDomainEvent in events)
                    await _mediator.Publish(entityDomainEvent);
            }
        }

        public virtual async Task Add(TEntity entity)
        {
            var model = _mapper.Map<TModel>(entity);
            await _dbContext.Set<TModel>().AddAsync(model);
            await DispatchDomainEventsAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            var model = _mapper.Map<TModel>(entity);
            _dbContext.Set<TModel>().Remove(model);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var models = await _dbContext.Set<TModel>().ToListAsync();
            List<TEntity> entities = new List<TEntity>();
            foreach(var model in models)
            {
                var entity = _mapper.Map<TEntity>(model);
                entities.Add(entity);
            }
            return entities;
        }

        public async Task<TEntity> GetById(int id)
        {
            var model = await _dbContext.Set<TModel>().FindAsync(id);
            var entity = _mapper.Map<TEntity>(model);
            return entity;
        }

        public void update(TEntity entity)
        {
            var Existmodel = _dbContext.Set<TModel>().Find(entity.Id);
            _dbContext.Entry(Existmodel).State = EntityState.Detached;

            var model = _mapper.Map<TModel>(entity);
            _dbContext.Set<TModel>().Update(model);
        }
    }
}
