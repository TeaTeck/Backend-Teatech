﻿using WebApplication1.Models;
using WebApplication1.Repositories;

namespace Interfaces.Repositories
{
    public interface IResponsibleRepository
    {
        Responsible Add(Responsible responsible);

        List<Responsible> GetAll();
    }
}
