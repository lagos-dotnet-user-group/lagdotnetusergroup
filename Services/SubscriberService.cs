using System.Collections.Generic;
using System.Linq;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class SubscriberService
    {
        private readonly ApplicationDbContext _db;

        public SubscriberService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Subscriber> GetAllSubscribers()
        {
            var _subscribers = _db.Subscribers.ToArray();
            if (_subscribers == null)
            {
                return null;
            }
            return _subscribers;
        }
    }
}