using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Infrastructure;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ChildAssistedRepository : IChildAssistedRepository
    {
        private readonly ConnectionContext _connectionContext;

        public ChildAssistedRepository(ConnectionContext context)
        {
            _connectionContext = context;
        }
        public ChildAssisted Add(ChildAssisted childAssisted)
        {
            try
            {
                var childAdd = _connectionContext.ChildAssisteds.Add(childAssisted).Entity;
                _connectionContext.SaveChanges();
                return childAdd;
            }
            catch (Exception ex)
            {
                throw new Exception("Internal database error - Message: " + ex.Message);
            }
            
        }
        public List<ChildAssisted> GetAll()
        {
            try
            {
                return _connectionContext.ChildAssisteds.Include(c => c.Responsible).Include(c => c.Responsible.User).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Internal database error - Message: " + ex.Message);
            }
        }
        public void DeleteById(Guid id)
        {
            try
            {
                ChildAssisted? childAssisted = this.GetById(id);
                if (childAssisted != null)
                {
                    try
                    {
                        _connectionContext.ChildAssisteds.Remove(childAssisted);
                        _connectionContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Internal database error - Message: " + ex.Message);
                    }

                }
                else
                {
                    throw new Exception("Assisted was not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ChildAssisted? GetById(Guid id)
        {
            try
            {
                try
                {
                    ChildAssisted? childAssisted = _connectionContext.ChildAssisteds.Include(c => c.Responsible)
                                                                                     .ThenInclude(r => r.User)
                                                                                    .FirstOrDefault(c => c.Id.Equals(id));
                    if (childAssisted != null)
                    {
                         return childAssisted;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Internal database error - Message: " + ex.Message);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        public ChildAssisted Update(ChildAssisted childAssisted)
        {
            try
            {
                if (this.GetById(childAssisted.Id) != null)
                {
                    try
                    {
                        ChildAssisted childAssistedUpdated = _connectionContext.ChildAssisteds.Update(childAssisted).Entity;
                        _connectionContext.SaveChanges();
                        return childAssistedUpdated;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Internal database error - Message: " + ex.Message);
                    }
                
                }
                else
                {
                    throw new Exception("Assisted was not found");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ChildAssisted> GetByData(string data)
        {
            try
            {
                data = data.ToLower();
                return _connectionContext.ChildAssisteds.Include(c => c.Responsible)
                                                        .Include(c => c.Responsible.User)
                                                        .Where(c => c.Name.ToLower().Contains(data) || 
                                                                    c.Responsible.NameResponsibleOne.ToLower().Contains(data) || 
                                                                    c.Responsible.NameResponsibleTwo.ToLower().Contains(data) || 
                                                                    c.Responsible.ResponsibleCpfOne.ToLower().Contains(data) || 
                                                                    c.Responsible.ResponsibleCpfTwo.ToLower().Contains(data) ||
                                                                    c.Responsible.ContactOne.ToLower().Contains(data) ||
                                                                    c.Responsible.ContactTwo.ToLower().Contains(data) ||
                                                                    c.Responsible.User.Email.ToLower().Contains(data))
                                                        .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Data not found.", ex);
            }
        }
    }
}
