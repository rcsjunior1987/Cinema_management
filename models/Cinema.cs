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
        this.SetMovies();
        this.setTickets();

        Console.ReadKey();
    }                    

    public void BuyTicket() {
        bool exit = false;

        while (exit == false) {

            // Gets movie at the Head of the Stack
            Movie movie = this.moviesCollection.PeepTop();

            if (movie == null) {
                Console.WriteLine("\n There is no movie to be shown!");
                break;
            }

            Customer customer = new Customer();

            Console.WriteLine("\n Please Enter an existed Customer Name or [CANCEL] to abort the operation!");

            string customerName = Console.ReadLine();

            if (customerName.ToUpper() != "CANCEL") {
                customer.Name = customerName;
                customer = this.Customers.Find(customer);
            } else
                exit = true;

            if(exit == false
            && customer != null) {

                Screenings screeningsHead = null;

                // Gets the screen at the Head of the queue
                screeningsHead = movie.Screenings.Peek();

                int indexTicket = this.GetLastTicketAvailable(screeningsHead);

                if(indexTicket > -1) {
                    Ticket newTicket = new Ticket(customer);

                    // Check if the quantity of tickets bought by a customer is multiple of 10
                    if (
                        (newTicket.Customer.HowManyScreenings >0)
                     & ((newTicket.Customer.HowManyScreenings % 10) == 0)
                        )
                        // Check so, marks the ticket payment method as courtesy
                        newTicket.PaymentMethod = "courtesy";
                    else
                        // Otherwise the customer pays for it
                        newTicket.PaymentMethod = customer.PaymentMethod;

                    // Sets the first seat available
                    screeningsHead.Seats[indexTicket] = new Seat(newTicket);

                    // Decrease quantity of seats available
                    screeningsHead.NumSeatsAvailable--;

                    // Adds one to Customer HowManyScreenings
                    newTicket.Customer.HowManyScreenings++;

                    // Counts number of Available seats after reservation
                    indexTicket = this.GetLastTicketAvailable(screeningsHead);

                    // If the Screening is full 
                    if (indexTicket == -1) {

                        // It deleted the actual Screenings
                        screeningsHead = movie.Screenings.DeQueue();

                        // Check if there is no more screenings for its movie
                        if(movie.Screenings.Peek() == null)
                            // If so, the head movie is Poped from the Stack
                            moviesCollection.Pop();
                    }

                    Console.WriteLine("\n" + newTicket.ToString());
                    Console.WriteLine(movie.ToString());
                    Console.ReadLine();
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
        this.ListAllCustomers();
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
                this.ListAllCustomers();
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
                name = Console.ReadLine();
            } else
            {
                customer = null;
                exit = true;
            }

            if (phoneNumber.ToUpper() != "CANCEL")
            {
                Console.WriteLine("\n Please Enter the PHONE NUMBER or [CANCEL] to abort the operation!");
                phoneNumber = Console.ReadLine();
                exit = true;
            } else
            {
                customer = null;
                exit = true;
            }
            if (paymentMethod.ToUpper() != "CANCEL")
            {
                Console.WriteLine("\n Please Enter the PAYMENT METHOD or [CANCEL] to abort the operation!");
                paymentMethod = Console.ReadLine();
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
        Movie movie = this.GetNewMovie();
        this.MoviesCollection.Push(movie);
        this.SetNewScreenings(movie);
        Console.Write(this.MoviesCollection.ToString());
        Console.ReadLine();
    }
    public void SetCustomers()
    {           
        // Start the clock to get the inicial time
        CustomStopwatch sw = new CustomStopwatch();
        sw.Start();

        int numberOfCustomers = 1;

        for (int i = 1; i<= numberOfCustomers; i++) {
            Customer newCustomer = new Customer("Customer" + i.ToString(), "phoneNumber" + i.ToString(), "card", 0);
            this.Customers.Add(newCustomer);
        }

        // Stop the clock to get the time spent
        sw.Stop();
        Console.WriteLine("Stopwatch elapsed s: {0} ", sw.Elapsed.TotalSeconds);
    }
    public void SetMovies()
    {   
        // Start the clock to get the inicial time
        CustomStopwatch sw = new CustomStopwatch();
        sw.Start();

        int numberOfMovies = 100;

        for (int i = 1; i<= numberOfMovies; i++) {
            Movie movie = new Movie("Movie" + Convert.ToString(i));
            this.MoviesCollection.Push(movie);
            this.SetNewScreenings(movie);
        }

        // Stop the clock to get the time spent
        sw.Stop();
        Console.WriteLine("Stopwatch elapsed s: {0} ", sw.Elapsed.TotalSeconds);
    }

    public void setTickets() {

        // Start the clock to get the inicial time
        CustomStopwatch sw = new CustomStopwatch();
        sw.Start();

        int numberOfTicket = 150;

        //------------------------

        bool exit = false;

        for(int i=0; i<= numberOfTicket; i++) {

            // Gets movie at the Head of the Stack
            Movie movie = this.moviesCollection.PeepTop();

            Customer customer = new Customer("Customer1");
            customer = this.Customers.Find(customer);
            
            if(exit == false
            && customer != null
            && movie != null) {

                Screenings screeningsHead = null;

                // Gets the screen at the Head of the queue
                screeningsHead = movie.Screenings.Peek();

                int indexTicket = this.GetLastTicketAvailable(screeningsHead);

                if(indexTicket > -1) {
                    Ticket newTicket = new Ticket(customer);

                    // Check if the quantity of tickets bought by a customer is multiple of 10
                    if (
                        (newTicket.Customer.HowManyScreenings >0)
                     & ((newTicket.Customer.HowManyScreenings % 10) == 0)
                        )
                        // Check so, marks the ticket payment method as courtesy
                        newTicket.PaymentMethod = "courtesy";
                    else
                        // Otherwise the customer pays for it
                        newTicket.PaymentMethod = customer.PaymentMethod;

                    // Sets the first seat available
                    screeningsHead.Seats[indexTicket] = new Seat(newTicket);

                    // Decrease quantity of seats available
                    screeningsHead.NumSeatsAvailable--;

                    // Adds one to Customer HowManyScreenings
                    newTicket.Customer.HowManyScreenings++;

                    // Counts number of Available seats after reservation
                    indexTicket = this.GetLastTicketAvailable(screeningsHead);

                    // If the Screening is full 
                    if (indexTicket == -1) {

                        // It deleted the actual Screenings
                        screeningsHead = movie.Screenings.DeQueue();

                        // Check if there is no more screenings for its movie
                        if(movie.Screenings.Peek() == null)
                            // If so, the head movie is Poped from the Stack
                            moviesCollection.Pop();
                    }
                   
                }
            }
        }

        //------------------------

        // Stop the clock to get the time spent
        sw.Stop();
        Console.WriteLine("Stopwatch elapsed s: {0} ", sw.Elapsed.TotalSeconds);
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
    public void ListAllCustomers()
    {
        Console.WriteLine("\n" + this.Customers.ToString());
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