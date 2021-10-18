using System;

/*
 Extends GenericList for a doubly-linked list of Customer objects
   sorted by name, when it is requested to list all customers.
*/
public class CustomerList : GenericList<Customer>
    {
        public CustomerList() : base() { }

        public override string ToString()
        {
            string returnString = "";

            foreach (Customer customer in this)
            {
                returnString += customer.ToString().PadRight(15) + "\n";
            }

            return returnString;
        }

        public void Add(Customer customer) {

            int code = 0;

            if (this.Length > 0) {

                foreach (Customer c in this)
                {
                    if (code < c.Code || code == 0)
                        code = c.Code;
                    
                }

            }

            customer.Code = ++code;

            base.Add(customer);
        }

        public Customer FindCustomerByCode(Customer obj)
        {
            foreach (Customer customer in this)
            {
                if (customer.Code.Equals(obj.Code))
                    return customer;
            }
            return null;
        }

        public LinkedList<Customer> SortByCustomerName()
        {
            LinkedList<Customer> orderedListByname = new LinkedList<Customer>();

            foreach(Customer newObj in this)
            {    
                Node<Customer> newNode = null;

                if (orderedListByname.Length == 0)
                {
                    newNode = new Node<Customer>(newObj, null, null);
                    
                    orderedListByname.head = newNode;
                    orderedListByname.tail = newNode;
                    ++orderedListByname.Length;
                }
                else
                {
                    if (newObj.Name.CompareTo(orderedListByname.head.NodeObject.Name) < 0)
                    {
                        newNode = new Node<Customer>(newObj, null, orderedListByname.head);
                        orderedListByname.head.previous = newNode;
                        orderedListByname.head = newNode;

                        ++orderedListByname.Length;
                    }
                    else
                    {
                        newNode = new Node<Customer>(newObj, orderedListByname.tail, null);
                        orderedListByname.tail.next = newNode;
                        orderedListByname.tail = newNode;

                        ++orderedListByname.Length;
                    }
                }
            }

            return orderedListByname;
        }

    }