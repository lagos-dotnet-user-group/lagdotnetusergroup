using WebApplication.Models;
using System.Collections.Generic;

namespace WebApplication.Models.AdminViewModels
{
    
    public class DashBoardViewModel
    {
        public IEnumerable<Subscriber> Subscribers { get; set; }
    }

}