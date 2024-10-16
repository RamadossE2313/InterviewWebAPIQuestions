using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewWebAPIQuestions.Core.Entities
{
    // intersection table to faciliated many to many relationship
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        // foreign key relationship
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        // Nagivation property
        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
