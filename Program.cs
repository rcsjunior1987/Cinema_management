using System;

namespace Cinema_management
{ 
    class Program
    {
            
        static void Main(string[] args)
        {
            Program program = new Program();
            program.manageMainMenu();
        }

        private void manageMainMenu()
        {
            Store bikeStore = getStore();

            bool exit = false;

            while (exit == false)
            {

                int selectedOption = GetMainOption();

                switch (selectedOption)
                {
                    /*
                        It is the menu UI of the project to execute the requirements of the project.
                    */
                    case 1:
                        // Add Customers
                        bikeStore.SetNewCustomer();
                        continue;
                        // List Available Bikes
                        //bikeStore.ListAvailableBikes();
                    case 2:
                        // Add Customers
                        //bikeStore.ListAllHiredBikes();
                        bikeStore.DeleteCustomer();
                        continue;
                    case 3:
                        // List Bikes Fixing
                        //bikeStore.ListAllBikeOnRepair();

                        // List all Customers
                        bikeStore.ListAllCustomers();
                        Console.ReadLine();
                        continue;   
                    case 4:
                        // Hire an Bike
                        //bikeStore.HireBike();

                        // Insert a new Movie
                        bikeStore.SetNewMovie();
                        continue;
                    case 5:
                        // Return an Bike 
                        //bikeStore.ReturnBike();
                        bikeStore.ListAllMovies();
                        continue;
                    case 6:
                        // Insert a new Bike
                        //bikeStore.SetNewMovie();
                        continue;
                    case 7:
                        // Insert a new Movie
                        //bikeStore.SetNewMovie();;
                        continue;
                    case 8:
                        // Return a fixed bike
                        //bikeStore.PopRepairedBike();
                        continue;
                    case 9:
                        // List all Customers
                        //bikeStore.ListAllCustomers();
                        //Console.ReadLine();
                        continue;
                    case 10: 
                        // Add Customers
                        //bikeStore.SetNewCustomer();
                        continue;
                    case 11:
                        // Delete Customers
                        //bikeStore.DeleteCustomer();
                        continue;
                    case 0:
                        exit = true;
                        continue;
                }
            }
        }

        private int GetMainOption()
        {
            string input;
            int selected = 0;

            bool exit = false;

            while (exit == false)
            { 
                Console.WriteLine();
                Console.WriteLine("Please select from the following options:");

                Console.WriteLine("1. Add Customers");
                Console.WriteLine("2. Delete Customers");
                Console.WriteLine("3. List all Customers");
                Console.WriteLine("4. Insert a new movie");
                Console.WriteLine("5. List all movies");

                //Console.WriteLine("1. List Available Bike");
                //Console.WriteLine("2. List hired bikes");
                //Console.WriteLine("3. List Bikes being fixed");
                //Console.WriteLine("4. Hire a Bike");
                //Console.WriteLine("5. Return a Bike");
                //Console.WriteLine("7. Send a bike to repair");
                //Console.WriteLine("8. Return a fixed bike");

                //Console.WriteLine("8. List all movies");
                
                Console.WriteLine("0. Quit");
                Console.WriteLine();

                Console.WriteLine("Selection > ");
                input = Console.ReadLine();

                bool validInput = Int32.TryParse(input, out int selection);

                if (!validInput || selection < 0 || selection > 11)
                {
                    Console.WriteLine("Please enter a valid option");
                    continue;
                }

                selected = selection;
                exit = true;
            }

            return selected;
        }

        private Store getStore()
        {   
            Store store = new Store();

            return store;
        }

    }
}
