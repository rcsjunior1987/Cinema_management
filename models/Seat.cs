using System;

public class Seat
    {
        private Guid id;
        public Guid Id { get => id; set => id = value; }
        private Ticket ticket;
        public Ticket Ticket { get => ticket; set => ticket = value; }           
        public Seat() { }

        public Seat(Ticket ticket)
        {            
            this.Id = Guid.NewGuid();
            this.Ticket = ticket;
        }

        public override string ToString()
        {
            return " Ticket: " + this.Ticket.Id;
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
