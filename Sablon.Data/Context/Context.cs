using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
    }
}
