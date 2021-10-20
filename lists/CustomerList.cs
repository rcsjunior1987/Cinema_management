using System;

/*
 Extends GenericList for a doubly-linked list of Customer objects
   sorted by name, when it is requested to list all customers.
*/ 
public class CustomerList : GenericLinkedList<Customer>
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

        public override void Add(Customer customer) {

            int code = 0;

            if (this.Head != null) {

                foreach (Customer c in this)
                {
                    if (code < c.Code || code == 0)
                        code = c.Code;
                }
            }

            customer.Code = ++code;
    
            base.Add(customer);
        }

        public override void Sort()
        {
            // initially, no nodes in sorted list so its set to null 
            Node<Customer> current = this.Head;
            Node<Customer> sortedHead  = null;

            // traverse the linked list and add sorted node to sorted list
            while (current != null)
            {
                // Store current.next in next
                Node<Customer> currentNext = current.Next;
              
                // current node goes in sorted list 
                sortedHead = sortedInsert(sortedHead, current);

                // now next becomes current 
                current = currentNext;
            }

            // update head to point to linked list
            this.Head = sortedHead;
        }

        public override Node<Customer> Search(Customer obj)
        {
            // Traverse the doubly linked list
            foreach (Customer customer in this)
            {
                // Returns Customer found
                if (customer.Code.Equals(obj.Code)) {
                    return this.Current;
                }
            }
            // otherwise returns null whether not found the object searched
            return null;
        }

        public override void Remove(Customer obj) {

            Node<Customer> previous = null;

            // Traverse the doubly linked list
            foreach (Customer customer in this)
            {
                // Finds element searched in the list
                if (customer.Code.Equals(obj.Code)) {

                    // If the element searched is Head   
                    if (this.Head == this.Current)
                        // It receives the first element after head
                        this.Head = this.Head.Next;                        
                    else
                        // Otherwise, the first element before the searched one
                        //  receive one after it
                        previous.Next = this.Current.Next;
                }
                
                // To keeps the lement before Current
                previous = this.Current;
            }

            // Sort the list
            this.Sort();
        }

        private Node<Customer> sortedInsert(Node<Customer> sortedHead, Node<Customer> newNode)
        {

            //for head node
            if(sortedHead == null
            || sortedHead.Content.Code >= newNode.Content.Code)
            {
                newNode.Next = sortedHead;
                return newNode;
            }
            else
            {
                Node<Customer> current = sortedHead;

                //find the node and then insert
                while(current.Next != null
                   && current.Next.Content.Code < newNode.Content.Code)
                    current = current.Next;
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            
            return sortedHead;
        } 

    }