using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Daily.Planner.with.God.Persistance.Repositories
{
    public class TemporalPermissionRepository : ITemporalPermissionRepository
    {
        private readonly ApplicationDbContext _context;

        public TemporalPermissionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseMessage<List<TemporalPermission>>> GetAllAsync()
        {
            var response = new ResponseMessage<List<TemporalPermission>>();
            try
            {
                var entities = await _context.TemporalPermissions.ToListAsync();
                response = new ResponseMessage<List<TemporalPermission>>
                {
                    Data = entities,
                    Message = $"{typeof(TemporalPermission).Name} found",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                response.Message = $"Error getting {typeof(TemporalPermission).Name}s, Error: {ex.Message}";
                response.Success = false;

                Exception inner = ex.InnerException;
                while (inner != null)
                {
                    response.Message += $" | InnerError: {inner.Message}";
                    inner = inner.InnerException;
                }
            }

            return response;
        }

        public async Task<ResponseMessage<TemporalPermission>> CreateAsync(TemporalPermission entity)
        {
            var response = new ResponseMessage<TemporalPermission>
            {
                Data = entity
            };

            try
            {
                _context.TemporalPermissions.Add(entity);
                await _context.SaveChangesAsync();
                response.Message = $"{typeof(TemporalPermission).Name} created";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = $"Error creating {typeof(TemporalPermission).Name}, Error: {ex.Message}";
                response.Success = false;

                Exception inner = ex.InnerException;
                while (inner != null)
                {
                    response.Message += $" | InnerError: {inner.Message}";
                    inner = inner.InnerException;
                }
            }
            return response;
        }

        public async Task<ResponseMessage<bool>> DeleteAsync(Guid id)
        {
            var response = new ResponseMessage<bool>();
            try
            {
                var entity = await _context.TemporalPermissions.FindAsync(id);
                if (entity == null)
                {
                    response.Data = false;
                    response.Success = true;
                    response.Message = $"{typeof(TemporalPermission).Name} not found";
                }
                else
                {
                    _context.TemporalPermissions.Remove(entity);
                    await _context.SaveChangesAsync();
                    response.Data = true;
                    response.Success = true;
                    response.Message = $"{typeof(TemporalPermission).Name} deleted";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error deleting {typeof(TemporalPermission).Name}: {id}, Error: {ex.Message}";

                Exception inner = ex.InnerException;
                while (inner != null)
                {
                    response.Message += $" | InnerError: {inner.Message}";
                    inner = inner.InnerException;
                }
            }

            return response;
        }

        public async Task<ResponseMessage<List<TemporalPermission>>> GetByRoleIdAsync(Guid roleId)
        {
            var response = new ResponseMessage<List<TemporalPermission>>();
            try
            {
                var entities = await _context.TemporalPermissions.Where(r => r.RoleId == roleId).ToListAsync();
                response = new ResponseMessage<List<TemporalPermission>>
                {
                    Data = entities,
                    Message = $"{typeof(TemporalPermission).Name} found",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                response.Message = $"Error getting {typeof(TemporalPermission).Name}s, Error: {ex.Message}";
                response.Success = false;

                Exception inner = ex.InnerException;
                while (inner != null)
                {
                    response.Message += $" | InnerError: {inner.Message}";
                    inner = inner.InnerException;
                }
            }

            return response;
        }
    }
}
