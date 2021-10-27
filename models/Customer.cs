using System;
using System.Collections.Generic;

/*
    Customer class extended by Person, which extends IComparable,
      which allows items to be stored in a LinkedList.
*/ 
public class Customer : Person
    {

        /* Phone number of the customer */
        private string phoneNumber;
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        /* Payment method used by customer */
        private string paymentMethod;
        public string PaymentMethod { get => paymentMethod; set => paymentMethod = value; }

        /* How many screens have the customer watched */
        private int howManyScreenings;
        public int HowManyScreenings { get => howManyScreenings; set => howManyScreenings = value; }

        public Customer() : base() { }
        
        public Customer(string name
                      , string phoneNumber
                      , string paymentMethod
                      , int howManyScreenings) : base(name)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.PaymentMethod = paymentMethod;
            this.HowManyScreenings = howManyScreenings;
        }

        /* Returns the string with the costumers attributes */
        public override string ToString()
        {
            return base.ToString()
                 + ", Phone Number: " + this.PhoneNumber
                 + ", Payment Method: " + this.PaymentMethod
                 + ", Quantity of movies watched: " + this.HowManyScreenings;
        }

        public override bool Equals(object other)
        {
            return base.Equals(other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

}