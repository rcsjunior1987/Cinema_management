using System;
using System.Collections;
using System.Collections.Generic;

public class Store
{ 
    private int quantityBikes;
    public int QuantityBikes { get => quantityBikes; set => quantityBikes = value; }

    private MoviesStack moviesCollection;
    public MoviesStack MoviesCollection { get => moviesCollection; set => moviesCollection = value; }

    private CustomerList customers;
    public CustomerList Customers { get => customers; set => customers = value; }

    private RentalList rentals;
    
    public RentalList Rentals { get => rentals; set => rentals = value; }
 
    public Store()
        {
            this.QuantityBikes = 50;

            this.Customers = new CustomerList();
            this.MoviesCollection = new MoviesStack();
            //this.RepairBikes = new RepairBikesStack();
            this.Rentals = new RentalList();

            this.SetAvailableBikes();
            this.SetCustomers();
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

        public void SetAvailableBikes()
        {
            string description;
            string brandDescription;
            string yearMade;

            for(int i = 0; i<= QuantityBikes-1; i++) {
                description = "Description" + (i+1);
                brandDescription = "bikebrand";
                yearMade = "2021";

                /*Bike bike = new Bike(description
                                   , brandDescription
                                   , yearMade
                                   );

                AvailableBikes.Add(bike);*/
            }
        }

        public void ListAllMovies() {
            Console.Write(this.MoviesCollection.ToString());
            Console.ReadLine();
        }

        public void ListAvailableBikes() 
        {
            //Console.Write("\n" + AvailableBikes.ToString());
            Console.ReadLine();
        }

        public void SetRepairBike()
        {
            /*Bike bike = null;

            while (bike is null)
            {
                int i = this.RepairBikes.GetRandomCode(1, AvailableBikes.Length);

                Bike bikeSearch = new Bike();
                bikeSearch.Code = i;

                bike = this.AvailableBikes.FindByCode(bikeSearch);
            }

            this.RepairBikes.Push(bike);
            this.AvailableBikes.Remove(bike);

            Console.WriteLine("Bike: " + bike.ToString() + " is being repaired!");
            Console.ReadKey();*/
        }

        public void PopRepairedBike()
        {
            /*if (this.RepairBikes.Top == 0)
            {
                Console.WriteLine("There are no bikes being fixed in this moment!");
                Console.ReadKey();
            }
            else
            {
                Bike bikeFixed = this.RepairBikes.Pop();
                this.AvailableBikes.Add(bikeFixed);

                Console.WriteLine("Bike: " + bikeFixed.ToString() + " is now available!");
                Console.ReadKey();
            }*/

        }

        private Movie GetAvailableBike() 
        {
            /*Movie bike = null;

            if (AvailableBikes is not null)
            {
                bike = this.AvailableBikes.GetHeadElement();

                if (bike is not null)
                {
                    Console.WriteLine("\n Bike" + bike.ToString() + " hired!");
                    return bike;                  
                }
            }
            else
            {
                Console.WriteLine("\n There is no bike available in this moment!");
                Console.ReadLine().ToUpper();
            }
            
            return bike;*/
            return null;
        }

        public void HireBike()
        {
            Customer customer = null;

            /*while (customer is null)
            {
                customer = this.GetCustomer();
                customer = Customers.Search(customer);

                if(customer is not null)
                {
                    Bike bike = GetAvailableBike();

                    if (customer is not null &&  bike is not null)
                    {
                        Rental rental = new Rental();
                        rental.Bike = bike;
                        rental.Customer = customer;

                        Rentals.Add(rental);
                    }
                    
                    Console.ReadLine();
                }
                else
                    Console.WriteLine("\n Customer does not exist!");
            }*/    

        }

        public void ReturnBike()
        {
            /*Customer customer = null;

            while (customer is null)
            {
                customer = this.GetCustomer();

                if(customer is not null)
                {
                    Bike bike = this.GetHiredBike();

                    if (customer is not null &&  bike is not null)
                    {
                        Rental rentalSearch = new Rental(customer, bike);
                        Rental rental = Rentals.GetRental(rentalSearch);

                        if(rental is null)
                        {
                            Console.WriteLine("Bike not hired to this customer!");
                            customer = null;
                        }
                        else
                        {
                            Bike bikeHired = rental.Bike;
                            this.AvailableBikes.Add(bikeHired);
                            this.Rentals.Remove(rental);

                            Console.WriteLine("Bike returned!");
                        }
                    }
                    
                    Console.ReadLine();
                }
                else
                    Console.WriteLine("\n Customer does not exist!");

            }*/   
        }

        private Movie GetHiredBike()
        {
            string input;
            int selected = 0;

            Movie bike = new Movie();

            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the code of a bike:");
                input = Console.ReadLine();

                bool validInput = Int32.TryParse(input, out int selection);

                exit = true;
            }

            return bike;
        } 

        public void SetNewCustomer()
        {
            Customer newCustomer = this.GetNewCustomer();

            this.Customers.Add(newCustomer);
            this.Customers.Sort();
        }

        public void DeleteCustomer()
        {
            this.ListAllCustomers();    

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
            Movie movie = this.GetNewMovie();
            this.MoviesCollection.Push(movie);

            Console.WriteLine(this.MoviesCollection.ToString());

            Console.ReadLine().ToUpper();
        }

        private Movie GetNewMovie()
        {
            Movie movie = new Movie();

            string description = "";
            string year = "";

            bool exit = false;

            while (exit == false)
            {
                if (description.ToUpper() != "CANCEL")
                {
                    Console.WriteLine("\n Please Enter the description of the movie or [CANCEL] to abort the operation!");

                    description = Console.ReadLine().ToUpper();
                } else
                {
                    description = null;
                    exit = true;
                }

                if (year.ToUpper() != "CANCEL")
                {
                    Console.WriteLine("\n Please Enter the year of the movie or [CANCEL] to abort the operation!");

                    year = Console.ReadLine().ToUpper();

                    exit = true;
                } else
                {
                    year = null;
                    exit = true;
                }

            }

            movie.Description = description;
            movie.Year = year;

            return movie;
        }

        private Customer GetCustomer()
        {
            Customer customer = new Customer();

            if (this.Customers is not null)
            {
                Console.WriteLine("\n Please Enter the code of the Customer !");
                string code = Console.ReadLine().ToUpper();
                customer.Code = Int32.Parse(code);
            }
            else
            {
                Console.WriteLine("\n There is Customer registered!");
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
            foreach(Customer c in this.Customers)
            {
                 Console.WriteLine(c.ToString());
            }
            
        }

        public void ListAllHiredBikes()
        {
            /*DoublyLinkedList<Rental> bikesHired = Rentals.SortByCustomerName();

            if (bikesHired.Length == 0)
                Console.WriteLine("There are no hired Bikes!");
            else
            {
                foreach(Rental r in bikesHired)
                {
                     Console.WriteLine(r.ToString());
                }
            }

            Console.ReadLine();*/
        }

        public void ListAllBikeOnRepair()
        {
            /*if (RepairBikes.Top == 0)
                Console.WriteLine("There is no Bike being fixed in thie moment!");
            else
                Console.WriteLine(RepairBikes.ToString());*/

            Console.ReadLine();
        }

}