using System.Collections.Generic;
using System.Linq;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class MetricService
    {
        private readonly ApplicationDbContext _db;

        public MetricService(ApplicationDbContext db)
        {
            _db = db;
        }

        
    }
}