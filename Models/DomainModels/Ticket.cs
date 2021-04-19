using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoProject.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }

        //[Range(1, 1000, ErrorMessage = "Sprint Numbers are between 1 and 1000.")]
        public int SprintNumber { get; set; }

        //[Range(1, 10, ErrorMessage = "Point Values are between 1 and 10.")]
        public int PointValue { get; set; }

        //[Required(ErrorMessage = "Please enter a due date.")]
        public DateTime? DueDate { get; set; }

        //[Required(ErrorMessage = "Please select a category.")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }

       //[Required(ErrorMessage = "Please select a status.")]
        public string StatusId { get; set; }
        public Status Status { get; set; }

        public bool Overdue =>
            StatusId == "open" && DueDate < DateTime.Today;


    }
}
