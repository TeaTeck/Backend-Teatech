using System;
using System.Reflection.Metadata.Ecma335;
using WebApplication1.Infrastructure;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ChildAssistedRepository : IChildAssisted
    {
        private readonly ConnectionContext _connectionContext;

        public ChildAssistedRepository(ConnectionContext context)
        {
            _connectionContext = context;
        }
        public ChildAssistedDTO Add(ChildAssisted childAssisted)
        {

            var childAdd =  _connectionContext.ChildAssisteds.Add(childAssisted).Entity;
            _connectionContext.SaveChanges();
            
            ChildAssistedDTO childAssistedDTO = new ChildAssistedDTO
            {
                Id = childAdd.Id,
                Name = childAdd.Name,
                BirthDate = childAdd.BirthDate,
                FoodSelectivity = childAdd.FoodSelectivity,
                Aversions = childAdd.Aversions,
                Preferences = childAdd.Preferences,
                MedicalRecord = childAdd.MedicalRecord,
                Responsible = childAdd.Responsible,
                Photo = childAdd.Photo,
            };

            return childAssistedDTO;
        }
        public List<ChildAssisted> GetAll()
        {
            return _connectionContext.ChildAssisteds.ToList();
        }
    }
}
