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
                return _connectionContext.ChildAssisteds.ToList();
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
                    ChildAssisted? childAssisted = _connectionContext.ChildAssisteds.Find(id);

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
                return _connectionContext.ChildAssisteds.Where(c => c.Name.Contains(data) || 
                                                                    c.Responsible.NameResponsibleOne.Contains(data) || 
                                                                    c.Responsible.NameResponsibleTwo.Contains(data) || 
                                                                    c.Responsible.ResponsibleCpfOne.Contains(data) || 
                                                                    c.Responsible.ResponsibleCpfTwo.Contains(data) ||
                                                                    c.Responsible.ContactOne.Contains(data) ||
                                                                    c.Responsible.ContactTwo.Contains(data) 
                                                                ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Data not found.", ex);
            }
        }
    }
}
