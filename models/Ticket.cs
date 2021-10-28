using System;

public class Ticket
    {
        /* Unique Id of Ticket */
        private Guid id;
        public Guid Id { get => id; set => id = value; }

        /* Custumer who bouth the ticket */
        private Customer customer;
        public Customer Customer { get => customer; set => customer = value; }

        /* Payment method used by customer */
        private string paymentMethod;
        public string PaymentMethod { get => paymentMethod; set => paymentMethod = value; }
        
        public Ticket() { }

        public Ticket(Customer customer)
        {
            this.Customer = customer;
            this.Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return "Customer name: " + customer.Name
                 + ", Quantity of Ticket bought: " + customer.HowManyScreenings
                 + ", Ticket Payment Method: " + this.PaymentMethod;
        }

        public override bool Equals(object other)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
