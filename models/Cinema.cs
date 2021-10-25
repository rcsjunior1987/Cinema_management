using System;
using System.Collections;
using System.Collections.Generic;

public class Cinema
{ 
    private Stack<Movie> moviesCollection;
    public Stack<Movie> MoviesCollection { get => moviesCollection; set => moviesCollection = value; }
    private LinkedList<Customer> customers;
    public LinkedList<Customer> Customers { get => customers; set => customers = value; }

    public Cinema()
    {
        this.Customers = new LinkedList<Customer>();
        this.MoviesCollection = new Stack<Movie>();
        this.SetCustomers();
        this.SetMovie();
    }                    

    public void BuyTicket() {

        bool exit = false;
        Customer customer = new Customer();

        Movie movie = this.moviesCollection.PeepTop();

        if (movie == null)
            Console.WriteLine("There is no movie to be shown!");
        else {

            while (exit == false) {
                Console.WriteLine("\n Please Enter an existed Customer Name or [CANCEL] to abort the operation!");
                customer = this.GetCustomer();

                if (customer.Name != "CANCEL")
                    customer = this.Customers.Find(customer);
                else
                    exit = true;

                if(exit == false
                && customer != null) {

                    Screenings screeningsHead = null;

                    while(movie.Screenings != null && exit == false) {

                        screeningsHead = movie.Screenings.Peek();

                        int indexTicket = this.GetLastTicketAvailable(screeningsHead);

                        if(indexTicket > -1) {
                            Ticket newTicket = new Ticket(customer);
                            screeningsHead.Seats[indexTicket] = new Seat(newTicket);

                            // Adds one to Customer HowManyScreenings
                            newTicket.Customer.HowManyScreenings++;

                            // Counts number of Free seats after reservation
                            indexTicket = this.GetLastTicketAvailable(screeningsHead);

                            // If the Screening is full 
                            if (indexTicket == -1) {

                                // It deleted the actual Screenings
                                screeningsHead = movie.Screenings.DeQueue();

                                // Check if there is no more screenings for its movie
                                if(movie.Screenings.Peek() == null) {
                                    // If so, the head movie is Poped from the Stack
                                    moviesCollection.Pop();
                                }

                                exit = true;
                            }
                        }
                    }
                }

            }

        }

    }

    private int GetLastTicketAvailable(Screenings screenings) {

        for(int i = 0; i <= screenings.Seats.Length- 1; i++) {
            if (screenings.Seats[i] == null) {
                return i;
            }
        }

        return -1;
    }
    public void ListAllMovies() {
        Console.Write(this.MoviesCollection.ToString());
        Console.ReadLine();
    }
    public void SetNewCustomer()        
    {
        Customer newCustomer = this.GetNewCustomer();
        this.Customers.Add(newCustomer);
        this.Customers.Sort();
    }
    public void DeleteCustomer()
    {                
        Console.WriteLine(this.Customers.ToString());
            
        Customer customer = null;

        while (customer is null)
        {
            customer  = this.GetCustomer();

            if(customer is not null)
            {
                Customers.Remove(customer);
                Console.WriteLine("Customer Deleted");
                Console.ReadLine();
            }
            else
                Console.WriteLine("\n Customer does not exist!");
        }
    }

    private Customer GetNewCustomer()
    {
        Customer customer = new Customer();

        string name = "";
        string phoneNumber = "";
        string paymentMethod = "";

        bool exit = false;

        while (exit == false)
        {
            if (name.ToUpper() != "CANCEL")
            {
                Console.WriteLine("\n Please Enter the NAME of the new customer or [CANCEL] to abort the operation!");
                name = Console.ReadLine().ToUpper();
            } else
            {
                customer = null;
                exit = true;
            }

            if (phoneNumber.ToUpper() != "CANCEL")
            {
                Console.WriteLine("\n Please Enter the PHONE NUMBER or [CANCEL] to abort the operation!");
                phoneNumber = Console.ReadLine().ToUpper();
                exit = true;
            } else
            {
                customer = null;
                exit = true;
            }
            if (paymentMethod.ToUpper() != "CANCEL")
            {
                Console.WriteLine("\n Please Enter the PAYMENT METHOD or [CANCEL] to abort the operation!");
                paymentMethod = Console.ReadLine().ToUpper();
                exit = true;
            } else
            {
                customer = null;
                exit = true;
            }

        }

        customer.Name = name;
        customer.PhoneNumber = phoneNumber;
        customer.PaymentMethod = paymentMethod;

        return customer;
    } 

    public void SetNewMovie()
    {
        if (this.MoviesCollection.IsEmpty()) {
            Movie movie = this.GetNewMovie();
            this.MoviesCollection.Push(movie);
            this.SetNewScreenings(movie);
            Console.Write(this.MoviesCollection.ToString());
        } else {
            Console.WriteLine("A new movie can be added just the actual one finishes!");
        }
        Console.ReadLine().ToUpper();

    }

    public void SetMovie()
    {   
        Movie movie = new Movie();
        movie.Description = "Movie1";
        
        this.MoviesCollection.Push(movie);
        this.SetNewScreenings(movie);
    }

    private void SetNewScreenings(Movie movie) {
        for (int i = 0; i<=2; i++) {
            Screenings screenings = this.GetNewScreenings(movie);    
            movie.Screenings.Enqueue(screenings);
        }
    }
    private Screenings GetNewScreenings(Movie movie) {
        Screenings newScreenings = new Screenings();
        return newScreenings;
    }
    private Movie GetNewMovie()
    {
        Movie movie = new Movie();

        string description = "";

        bool exit = false;

        while (exit == false)
        {
            if (description.ToUpper() != "CANCEL")
            {
                Console.WriteLine("\n Please Enter the description of the movie or [CANCEL] to abort the operation!");
                description = Console.ReadLine();
                exit = true;
            } else
            {
                description = null;
                exit = true;
            }

        }

        movie.Description = description;
        return movie;
    }
    private Customer GetCustomer()
    {
        Customer customer = new Customer();

        if (this.Customers is not null)
        {
            Console.WriteLine("\n Please Enter the NAME of the Customer !");
            customer.Name = Console.ReadLine().ToUpper();
        }
        else
        {
            Console.WriteLine("\n There is no Customer registered!");
            Console.ReadLine().ToUpper();
        }

        return customer;
    }
    public void SetCustomers()
    {   

        for (int i = 1; i<= 5; i++) {
            Customer newCustomer = new Customer("Customer" + i.ToString(), "phoneNumber" + i.ToString(), "card", 0);
            this.Customers.Add(newCustomer);
        }

        this.Customers.Sort();
    }
    public void ListAllCustomers()
    {
        Console.WriteLine(this.Customers.ToString());
        Console.ReadLine();
            
    }

    public override string ToString()
    {
        return base.ToString();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }  
}