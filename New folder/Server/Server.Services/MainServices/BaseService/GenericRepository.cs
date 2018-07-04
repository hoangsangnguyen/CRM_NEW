using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Falcon.Web.Core.Data;
using Falcon.Web.Core.Helpers;
using Vino.Server.Services.Database;

namespace Vino.Server.Services.MainServices.BaseService
{
    public class GenericRepository<TEntity, TDto, TCreationDto> : IGenericRepository<TEntity, TDto, TCreationDto>
        where TDto : BaseDto where TCreationDto : class where TEntity : BaseEntity
    {
        private readonly DataContext _context;
        private DbSet<TEntity> _entities;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            IQueryable<TEntity> query = _entities;

            var items = await query.AsNoTracking().Where(x => !x.Deleted).ToListAsync();
            if (query.Count() == 0)
            {
                return new List<TDto>();
            }

            return items.MapTo<TDto>();
        }

        public async Task<TDto> GetSingleAsync(int id)
        {
            var entity = await _entities.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);

            if (entity == null)
            {
                return null;
            }

            return Mapper.Map<TDto>(entity);
        }

        public async Task<int> CreateAsync(TCreationDto creationDto)
        {
            var entity = creationDto.MapTo<TEntity>();

            _entities.Add(entity);
            var created = await _context.SaveChangesAsync();
            if (created < 1)
            {
                throw new InvalidOperationException("Database context could not create data.");
            }
            
            return entity.Id;
        }

        public async Task<int> EditAsync(int id, TCreationDto creationDto)
        {
            var entity = await _entities.SingleOrDefaultAsync(r => r.Id == id);
            if (entity == null)
            {
                throw new InvalidOperationException("Can not find object with this Id.");
            }

            //foreach (PropertyInfo propertyInfo in creationDto.GetType().GetProperties())
            //{
            //    string key = propertyInfo.Name;
            //    if (key != "Id" && entity.GetType().GetProperty(key) != null)
            //    {
            //        entity.GetType().GetProperty(key).SetValue(entity, propertyInfo.GetValue(creationDto, null));
            //    }
            //}
            creationDto.MapTo<TEntity>(entity);

            var updated = await _context.SaveChangesAsync();
            if (updated < 1)
            {
                return 0;
            }

            return id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _entities.SingleOrDefaultAsync(r => r.Id == id);
            if (entity == null)
            {
                throw new InvalidOperationException("Can not find object with this Id.");
            }

            entity.Deleted = true;
            _entities.AddOrUpdate(entity);
            var deleted = await _context.SaveChangesAsync();
            if (deleted < 1)
            {
                throw new InvalidOperationException("Database context could not delete data.");
            }

            return id;
        }

        public Task<int> GetNumberEntry()
        {
            var count = _entities.CountAsync();
            return count;
        }

      
    }
}
