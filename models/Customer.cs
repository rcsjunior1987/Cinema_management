using System;
using System.Collections.Generic;

/*
    Customer class extended by  Person, which extends IComparable,
      which allows items to be stored in a SortedLinkedList.
*/ 
public class Customer : Person
    {
        private int code;
        public int Code { get => code; set => code = value; }
        private string phoneNumber;
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        private string paymentMethod;
        public string PaymentMethod { get => paymentMethod; set => paymentMethod = value; }
        private int howManyScreenings;
        public int HowManyScreenings { get => howManyScreenings; set => howManyScreenings = value; }

        public Customer() : base() { }
        
        public Customer(string name) : base(name) { }

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

        public override string ToString()
        {
            return "Code: " + this.Code 
                 + ", " + base.ToString()
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