﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(object id);
        Task Update(T entity);
        Task Delete(object id);
        Task Save();
    }
}
