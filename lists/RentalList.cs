using System;

/*
    Extends GenericList for a doubly-linked list of Rental objects
      sorted by the Customer Name, when it is requested to list all rentals.
*/
public class RentalList : GenericList<Rental>
{
        public RentalList() : base() { }

        public override string ToString()
        {
            string returnString = "";

            foreach (Rental rental in this)
            {
                returnString += rental.Customer.ToString().PadRight(15) + "\n";
            }

            return returnString;
        }

        public void Add(Rental rental) {

            int code = 0;

            if (this.Length > 0) {

                foreach (Rental r in this)
                {
                    if (code < r.Code || code == 0)
                        code = r.Code;
                }

            }

            rental.Code = ++code;

            base.Add(rental);
        }

        public Rental GetRental(Rental obj)
        {
            foreach (Rental rental in this)
            {
                if (rental.Customer.Code.Equals(obj.Customer.Code))
                {
                    if (rental.Bike.Code.Equals(obj.Bike.Code))
                        return rental;
                }
                
            }
            return null;
        }

        public LinkedList<Rental> SortByCustomerName()
        {
            LinkedList<Rental> rentalList = new LinkedList<Rental>();

            foreach(Rental newObj in this)
            {    
                Node<Rental> newNode = null;

                if (rentalList.Length == 0)
                {
                    newNode = new Node<Rental>(newObj, null, null);
                    
                    rentalList.head = newNode;
                    rentalList.tail = newNode;
                    ++rentalList.Length;
                }
                else
                {
                    if (newObj.Customer.Name.CompareTo(rentalList.head.NodeObject.Customer.Name) < 0)
                    {
                        newNode = new Node<Rental>(newObj, null, rentalList.head);
                        rentalList.head.previous = newNode;
                        rentalList.head = newNode;

                        ++rentalList.Length;
                    }
                    else
                    {
                        newNode = new Node<Rental>(newObj, rentalList.tail, null);
                        rentalList.tail.next = newNode;
                        rentalList.tail = newNode;

                        ++rentalList.Length;
                    }
                }
            }

            return rentalList;
        }

    }