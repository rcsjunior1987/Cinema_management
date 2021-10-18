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
                        // List Available Bikes
                        bikeStore.ListAvailableBikes();
                        continue;
                    case 2:
                        // List hired Bikes
                        bikeStore.ListAllHiredBikes();
                        continue;
                    case 3:
                        // List Bikes Fixing
                        bikeStore.ListAllBikeOnRepair();
                        continue;    
                    case 4:
                        // Hire an Bike
                        bikeStore.HireBike();
                        continue;
                    case 5:
                        // Return an Bike
                        bikeStore.ReturnBike();
                        continue;
                    case 6:
                        // Insert a new Bike
                        bikeStore.SetNewBike();
                        continue;
                    case 7:
                        // Send a bike to be fixed
                        bikeStore.SetRepairBike();
                        continue;
                    case 8:
                        // Return a fixed bike
                        bikeStore.PopRepairedBike();
                        continue;
                    case 9:
                        // List all Customers
                        bikeStore.ListAllCustomers();
                        continue;
                    case 10:
                        // Add Customers
                        bikeStore.SetNewCustomer();
                        continue;
                    case 11:
                        // Delete Customers
                        bikeStore.DeleteCustomer();
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
                Console.WriteLine("1. List Available Bike");
                Console.WriteLine("2. List hired bikes");
                Console.WriteLine("3. List Bikes being fixed");
                Console.WriteLine("4. Hire a Bike");
                Console.WriteLine("5. Return a Bike");
                Console.WriteLine("6. Insert a new Bike");
                Console.WriteLine("7. Send a bike to repair");
                Console.WriteLine("8. Return a fixed bike");
                Console.WriteLine("9. List all Customers");
                Console.WriteLine("10. Add Customers");
                Console.WriteLine("11. Delete Customers");
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
