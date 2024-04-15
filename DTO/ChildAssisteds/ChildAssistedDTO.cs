﻿using Backend_TeaTech.Models;

namespace Backend_TeaTech.DTO.ChildAssisteds
{
    public class ChildAssistedDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }

        public ChildAssistedDTO()
        {
        }
        public ChildAssistedDTO(Guid id, string name, string email, string contact)
        {
            Id = id;
            Name = name;
            Email = email;
            Contact = contact;
        }
        public ChildAssistedDTO(ChildAssisted childAssisted)
        {
            Name = childAssisted.Name;
        }
    }
}