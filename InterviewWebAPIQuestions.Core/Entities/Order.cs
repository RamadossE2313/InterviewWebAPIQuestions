namespace InterviewWebAPIQuestions.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulFilled { get; set; }
        
        // represents foreign key relationship with the customer table
        // if we didn't add customer id property, ef core will create shadow property for it.
        public int CustomerId { get; set; }

        // Nagivation propertities
        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = null!;
    }
}
