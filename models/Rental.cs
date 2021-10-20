using System;
using System.Collections.Generic;

/*
    Class rental which extends IComparable,
      which allows items to be stored in a SortedLinkedList.
       a Rental is represents a bike hired by a customer.
*/
public class Rental : IComparable
{
    /*
    private Bike bike;
    private Customer customer;
    private int code;
    public Customer Customer { get => customer; set => customer = value; }
    public Bike Bike { get => bike; set => bike = value; }
    public int Code { get => code; set => code = value; }

    private Guid id;
    public Guid Id { get => id; set => id = value; }

    public Rental() {
        this.Id = Guid.NewGuid();
    }

    public Rental(Customer customer, Bike bike) {
        this.Customer = customer;
        this.Bike = bike;
    }
*/
    public override string ToString()
    {
        /*return "Bike: "  + this.Bike.Code
             + " - " +  this.Bike.Description
             + " is hired to "
             + this.Customer.Name;*/
        return null;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public int CompareTo(object other)
    {
        return 0;
    }
    

}