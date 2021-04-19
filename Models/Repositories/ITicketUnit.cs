using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoProject.Models
{
    public interface ITicketUnit
    {
        public IRepository<Ticket> Tickets { get; }
        public IRepository<Category> Categories { get; }
        public IRepository<Status> Statuses { get; }

        public void Save();

    }
}
