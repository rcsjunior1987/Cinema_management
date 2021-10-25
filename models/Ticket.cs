using System;

public class Ticket
    {
        private Guid id;
        public Guid Id { get => id; set => id = value; }

        private Customer customer;
        public Customer Customer { get => customer; set => customer = value; }           
        
        public Ticket() { }

        public Ticket(Customer customer)
        {
            this.Customer = customer;
            this.Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return " Customer: " + this.Customer.Name;
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
