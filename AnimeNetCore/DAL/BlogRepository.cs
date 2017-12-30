using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AnimeNetCore.Data;

namespace AnimeNetCore.DAL
{
    public class BlogRepository : IBlogRepository, IDisposable
    {
        private BlogDbContext _context;

        public BlogRepository(BlogDbContext context)
        {
            _context = context;
        }





        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
   
}
