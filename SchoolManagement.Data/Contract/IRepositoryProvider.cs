using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Data
{
    public interface IRepositoryProvider
    {
        IRepository<T> GetRepositoryByEntity<T>() where T : class;
        T GetRepositoryByRepository<T>(Func<DbContext, object> factory = null) where T : class;
    }
}
