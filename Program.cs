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
            Cinema cinema = GetCinema();

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
                        cinema.SetNewCustomer();
                        continue;
                    case 2:
                        // Delete Customers
                        cinema.DeleteCustomer();
                        continue;
                    case 3:
                        // Insert a new Movie
                        cinema.SetNewMovie();
                        continue;
                    case 4:
                        // Buy Ticket
                        cinema.BuyTicket();
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
                Console.WriteLine("3. Insert a new movie");
                Console.WriteLine("4. Buy ticket");
                Console.WriteLine("0. Quit");
                Console.WriteLine();

                Console.WriteLine("Selection > ");
                input = Console.ReadLine();

                bool validInput = Int32.TryParse(input, out int selection);

                if (!validInput || selection < 0 || selection > 4)
                {
                    Console.WriteLine("Please enter a valid option");
                    continue;
                }

                selected = selection;
                exit = true;
            }

            return selected;
        }

        private Cinema GetCinema()
        {   
            Cinema store = new Cinema();

            return store;
        }

    }
}
