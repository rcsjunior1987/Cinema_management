using System;
using System.Collections.Generic;

/*
    Class rental which extends IComparable,
      which allows items to be stored in a SortedLinkedList.
       a Rental is represents a bike hired by a customer.
*/
public class Screenings : IComparable
{
    private Guid id;
    public Guid Id { get => id; set => id = value; }
    private int numSeats;
    public int NumSeats { get => numSeats; set => numSeats = value; }
    //private Movie movie;
    //public Movie Movie { get => movie; set => movie = value; }
    private Seat[] seats;
    public Seat[] Seats { get => seats; set => seats = value; }

    public Screenings() {
        this.Id = Guid.NewGuid();
        this.NumSeats = 1;

        //this.Movie = new Movie();
        this.Seats = new Seat[this.NumSeats];
    }
    
    public override string ToString()
    {
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