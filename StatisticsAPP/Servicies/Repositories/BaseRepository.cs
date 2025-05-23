﻿using Microsoft.EntityFrameworkCore;
using StatisticsAPP.Data;
using StatisticsAPP.Servicies.AuthServicies;
using StatisticsAPP.Servicies.Interfaces;
using StatisticsAPP.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static StatisticsAPP.Utility.MyTypes;

namespace StatisticsAPP.Servicies.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
            //if (!CheckPermission(MyTypes.PermissionsType.View, out var message))
            //{
            //    MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            //}
            
        public IEnumerable<T> GetAll()
        {

            if (!CheckPermission(MyTypes.PermissionsType.View, out var message))
            {
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Enumerable.Empty<T>();
            }
            return _context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (!CheckPermission(MyTypes.PermissionsType.View, out var message))
            {

                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Enumerable.Empty<T>();
            }

            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {

            if (!CheckPermission(MyTypes.PermissionsType.View, out var message))
            {
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return default;
            }
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            if (!CheckPermission(MyTypes.PermissionsType.View, out var message))
            {
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return default;
            }
            return await _context.Set<T>().FindAsync(id);
        }

        public T Find(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            if (!CheckPermission(MyTypes.PermissionsType.View, out var message))
            {
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return default;
            }
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            return query.SingleOrDefault(criteria!);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            if (!CheckPermission(MyTypes.PermissionsType.View, out var message))
            {
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return default;
            }
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            return await query.SingleOrDefaultAsync(criteria);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            if (!CheckPermission(MyTypes.PermissionsType.View, out var message))
            {
               
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Enumerable.Empty<T>();
            }

            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.Where(criteria).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int skip, int take)
        {
            if (!CheckPermission(MyTypes.PermissionsType.View, out var message))
            {
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Enumerable.Empty<T>();
            }

            return _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? skip, int? take,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            if (!CheckPermission(MyTypes.PermissionsType.View, out var message))
            {
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Enumerable.Empty<T>();
            }

            IQueryable<T> query = _context.Set<T>().Where(criteria);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            if (!CheckPermission(MyTypes.PermissionsType.View, out var message))
            {
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Enumerable.Empty<T>();
            }

            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.Where(criteria).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip)
        {
            if (!CheckPermission(MyTypes.PermissionsType.View, out var message))
            {
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Enumerable.Empty<T>();
            }

            return await _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            if (!CheckPermission(MyTypes.PermissionsType.View, out var message))
            {
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Enumerable.Empty<T>();
            }

            IQueryable<T> query = _context.Set<T>().Where(criteria);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
        }

        public T Add(T entity)
        {
            if (!CheckPermission(MyTypes.PermissionsType.Create, out var message))
            {
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return default;
            }
            _context.Set<T>().Add(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            if (!CheckPermission(MyTypes.PermissionsType.Create, out var message))
            {
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return default;
            }
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            if (!CheckPermission(MyTypes.PermissionsType.Create, out var message))
            {
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Enumerable.Empty<T>();
            }
            _context.Set<T>().AddRange(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            if (!CheckPermission(MyTypes.PermissionsType.Create, out var message))
            {
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return Enumerable.Empty<T>();
            }
            await _context.Set<T>().AddRangeAsync(entities);
            return entities;
        }

        public T Update(T entity)
        {
            if (!CheckPermission(MyTypes.PermissionsType.Edit, out var message))
            {
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return default;
            }
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
        public void Delete(int Id)
        {
            if (!CheckPermission(MyTypes.PermissionsType.Delete, out var message))
            {
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var entity = _context.Set<T>().Find(Id);

                if (entity != null)
                    _context.Set<T>().Remove(entity);
                else  
                    MessageBox.Show("Entity not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        public void Delete(T entity)
        {
            if (!CheckPermission(MyTypes.PermissionsType.Delete, out var message))
            {
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
            }else
            {
                _context.Set<T>().Remove(entity);
            }
           
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            if (!CheckPermission(MyTypes.PermissionsType.Delete, out var message))
            {
                MessageBox.Show(message, "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _context.Set<T>().RemoveRange(entities);
        }

        public void Attach(T entity)
        {

            _context.Set<T>().Attach(entity);
        }

        public void AttachRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AttachRange(entities);
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Count(criteria);
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
        {
            return await _context.Set<T>().CountAsync(criteria);
        }
        private string[]? GetUserIclude()
        {
            var includse = new string[1];
            includse[0] = "User";
            return includse;    
        }
        private string GetModelName()
        {
            return  typeof(T).Name;
        }
        private bool CheckPermission(PermissionsType permissionType, out string message)
        {
            string className = GetModelName();
            var permissionResult = MyCervicies.checkPermissionsManager.CheckPermissionByCode(className, permissionType);

            if (!permissionResult.Permission)
            {
                message = permissionResult.Message!;
                return false;
            }

            message = string.Empty;
            return true;
        }

     
    }


}
