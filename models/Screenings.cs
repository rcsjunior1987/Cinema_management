using System;
using System.Collections.Generic;

/*
    Class Screenings which extends IComparable,
      which allows items to be stored in Queues.
       It represents screenings of movies.
*/
public class Screenings : IComparable
{
    /* Id of Screenings */
    private Guid id;
    public Guid Id { get => id; set => id = value; }

    /* Quantity of seats */
    private int numSeats;
    public int NumSeats { get => numSeats; set => numSeats = value; }

    /* Quantity of seats available */
    private int numSeatsAvailable;
    public int NumSeatsAvailable { get => numSeatsAvailable; set => numSeatsAvailable = value; }

    /* Array of seats */
    private Seat[] seats;
    public Seat[] Seats { get => seats; set => seats = value; }

    public Screenings() {

        // Generates an unique Id
        this.Id = Guid.NewGuid();

        // Definies the quantity of seat
        this.NumSeats = 2;

        // Quantity of seats available
        //  starts with the same number of seats
        this.NumSeatsAvailable = this.NumSeats;

        // Creates the seats
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