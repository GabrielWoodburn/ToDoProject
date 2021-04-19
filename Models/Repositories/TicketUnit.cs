using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoProject.Models
{
    public class TicketUnit : ITicketUnit
    {
        private TicketContext context { get; set; }
        public TicketUnit(TicketContext ctx) => context = ctx;

        private IRepository<Ticket> ticketData;
        public IRepository<Ticket> Tickets
        {
            get
            {
                if (ticketData == null)
                    ticketData = new Repository<Ticket>(context);
                return ticketData;
            }
        }

        private IRepository<Category> categoryData;
        public IRepository<Category> Categories
        {
            get
            {
                if (categoryData == null)
                    categoryData = new Repository<Category>(context);
                return categoryData;
            }
        }

        private IRepository<Status> statusData;
        public IRepository<Status> Statuses
        {
            get
            {
                if (statusData == null)
                    statusData = new Repository<Status>(context);
                return statusData;
            }
        }

        public void Save() => context.SaveChanges();
    }
}
