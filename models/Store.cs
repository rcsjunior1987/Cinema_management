using System;
using System.Collections;
using System.Collections.Generic;

public class Store
{
    private int quantityBikes;
    private AvailableBikesQueue availableBikes;
    private CustomerList customers;
    private RepairBikesStack repairBikes;
    private RentalList rentals;
    public int QuantityBikes { get => quantityBikes; set => quantityBikes = value; }
    public CustomerList Customers { get => customers; set => customers = value; }
    public RepairBikesStack RepairBikes { get => repairBikes; set => repairBikes = value; }
    public AvailableBikesQueue AvailableBikes { get => availableBikes; set => availableBikes = value; }
    public RentalList Rentals { get => rentals; set => rentals = value; }

    public Store()
        {
            this.QuantityBikes = 50;

            this.Customers = new CustomerList();
            this.AvailableBikes = new AvailableBikesQueue();
            this.RepairBikes = new RepairBikesStack();
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

                Bike bike = new Bike(description
                                   , brandDescription
                                   , yearMade
                                   );

                AvailableBikes.Add(bike);
            }
        }

        public void ListAvailableBikes() 
        {
            Console.Write("\n" + AvailableBikes.ToString());
            Console.ReadLine();
        }

        public void SetRepairBike()
        {
            Bike bike = null;

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
            Console.ReadKey();
        }

        public void PopRepairedBike()
        {
            if (this.RepairBikes.Top == 0)
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
            }

        }

        private Bike GetAvailableBike() 
        {
            Bike bike = null;

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
            
            return bike;
        }

        public void HireBike()
        {
            Customer customer = null;

            while (customer is null)
            {
                customer = this.GetCustomer();
                customer = Customers.FindCustomerByCode(customer);

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
            }    

        }

        public void ReturnBike()
        {
            Customer customer = null;

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

            }   
        }

        private Bike GetHiredBike()
        {
            string input;
            int selected = 0;

            Bike bike = new Bike();

            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the code of a bike:");
                input = Console.ReadLine();

                bool validInput = Int32.TryParse(input, out int selection);

                bike.Code = selection;
                exit = true;
            }

            return bike;
        } 

        public void SetNewCustomer()
        {
            Customer newCustomer = this.GetNewCustomer();
            this.Customers.Add(newCustomer);
        }

        public void DeleteCustomer()
        {
            Customer customer = null;

            while (customer is null)
            {
                customer = this.GetCustomer();
                customer = Customers.FindCustomerByCode(customer);

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

            bool exit = false;

            while (exit == false)
            {
                if (name.ToUpper() != "CANCEL")
                {
                    Console.WriteLine("\n Please Enter the name of the new customer or [CANCEL] to abort the operation!");

                    name = Console.ReadLine().ToUpper();
                } else
                {
                    customer = null;
                    exit = true;
                }

                if (phoneNumber.ToUpper() != "CANCEL")
                {
                    Console.WriteLine("\n Please Enter the phone number of the new customer or [CANCEL] to abort the operation!");

                    phoneNumber = Console.ReadLine().ToUpper();

                    exit = true;
                } else
                {
                    customer = null;
                    exit = true;
                }

            }

            customer.Name = name;
            customer.PhoneNumber = phoneNumber;

            return customer;
        }

        public void SetNewBike()
        {
            Bike bike = this.GetNewBike();
            this.AvailableBikes.Add(bike);
        }

        private Bike GetNewBike()
        {
            Bike bike = new Bike();

            string description = "";
            string brandDescription = "";
            string yearMade = "";

            bool exit = false;

            while (exit == false)
            {
                if (description.ToUpper() != "CANCEL")
                {
                    Console.WriteLine("\n Please Enter the description of the new bike or [CANCEL] to abort the operation!");

                    description = Console.ReadLine().ToUpper();
                } else
                {
                    description = null;
                    exit = true;
                }

                if (brandDescription.ToUpper() != "CANCEL")
                {
                    Console.WriteLine("\n Please Enter the brand of the new bike or [CANCEL] to abort the operation!");

                    brandDescription = Console.ReadLine().ToUpper();

                    exit = true;
                } else
                {
                    brandDescription = null;
                    exit = true;
                }

                if (yearMade.ToUpper() != "CANCEL")
                {
                    Console.WriteLine("\n Please Enter the year of the new bike or [CANCEL] to abort the operation!");

                    yearMade = Console.ReadLine().ToUpper();

                    exit = true;
                } else
                {
                    yearMade = null;
                    exit = true;
                }

            }

            bike.Description = description;
            bike.BrandDescription = brandDescription;
            bike.YearMade = yearMade;

            return bike;
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
            Customer customer1 = new Customer("Beto Carlos", "33 3333-3333");
            Customer customer2 = new Customer("Luan Carlos", "11 1111-1111");
            Customer customer3 = new Customer("Alexandra Ramos", "22 2222-2222");
            Customer customer4 = new Customer("Zarlos Carlos", "33 3333-3333");

            this.Customers.Add(customer1);
            this.Customers.Add(customer2);
            this.Customers.Add(customer3);
            this.Customers.Add(customer4);
        }

        public void ListAllCustomers()
        {
            LinkedList<Customer> customersOrderedByName = Customers.SortByCustomerName();

            foreach(Customer c in customersOrderedByName)
            {
                 Console.WriteLine(c.ToString());
            }

            Console.ReadLine();
        }

        public void ListAllHiredBikes()
        {
            LinkedList<Rental> bikesHired = Rentals.SortByCustomerName();

            if (bikesHired.Length == 0)
                Console.WriteLine("There are no hired Bikes!");
            else
            {
                foreach(Rental r in bikesHired)
                {
                     Console.WriteLine(r.ToString());
                }
            }

            Console.ReadLine();
        }

        public void ListAllBikeOnRepair()
        {
            if (RepairBikes.Top == 0)
                Console.WriteLine("There is no Bike being fixed in thie moment!");
            else
                Console.WriteLine(RepairBikes.ToString());

            Console.ReadLine();
        }

}