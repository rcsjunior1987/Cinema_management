using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

/*
    This class represents a linked list, in which the elements are not stored at contiguous memory locations.
    It keeps Head, Tail, and Current elements as in Queue. However, the classes extended from LinkedList can be sorted.
     The element to be added not always goes to Head, and Tail is not always the one to be removed.
*/
public class LinkedList<T> : IEnumerable<T> where T : IComparable
    {
        private Node<T> head = null;
        public Node<T> Head { get => head; set => head = value; }         
        private Node<T> current = null;
        public Node<T> Current { get => current; set => current = value; }

        public LinkedList() { }

        /* Adds an object in the end of the list. */
        public virtual void Add(T obj)
        {
            //Create a new node  
            Node<T> newNode = new Node<T>(obj, null);

            //link new node to list
            newNode.Next = this.Head;

            //head points to new node
            this.Head = newNode;
        }

        /* Removes elements from any position of the List */
        public virtual void Remove(T obj)
        {
            Node<T> previous = null;

            // Traverse list
            foreach (T t in this)
            {
                // Finds element searched in the list
                if (t.CompareTo(obj) == 0) {

                    // If the element searched is Head   
                    if (this.Head == this.Current)
                        // It receives the first element after head
                        this.Head = this.Head.Next;                        
                    else
                        // Otherwise, the first element before the searched one
                        //  receive one after it
                        previous.Next = this.Current.Next;
                }
                
                // To keeps the element before Current
                previous = this.Current;
            }

            // Sort the list
            this.Sort();
        }

        public T Find(T obj) {

            // Traverse the list
            foreach (T t in this)
            {
                // Finds element searched in the list
                if (t.CompareTo(obj) == 0)
                    // Returns the element if It is found
                    return t;
            }

            // Returns Null if element does not exist 
            return default(T);
        }

        public void Sort()
        {
            // initially, no nodes in sorted list so its set to null 
            Node<T> current = this.Head;
            Node<T> sortedHead  = null;

            // traverse the linked list and add sorted node to sorted list
            while (current != null)
            {
                // Store current.next in next
                Node<T> currentNext = current.Next;
              
                // current node goes in sorted list 
                sortedHead = sortedInsert(sortedHead, current);

                // now next becomes current 
                current = currentNext;
            }

            // update head to point to linked list
            this.Head = sortedHead;
        }

        private Node<T> sortedInsert(Node<T> sortedHead, Node<T> newNode)
        {

            //for head node
            if(sortedHead == null
            || sortedHead.Content.CompareTo(newNode.Content) >= 0)
            {
                newNode.Next = sortedHead;
                return newNode;
            }
            else
            {
                Node<T> current = sortedHead;

                //find the node and then insert
                while(current.Next != null
                   && current.Next.Content.CompareTo(newNode.Content) < 0)
                    current = current.Next;
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            
            return sortedHead;
        }

        public IEnumerator<T> GetEnumerator()
        {
            this.Current = this.Head;

            while (this.current != null)
            {
                yield return this.Current.Content;
                this.Current = this.Current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        
        public string ToString()
        {
            string returnString = "";

            foreach (T obj in this)
            {
                returnString += obj.ToString().PadRight(15) + "\n";
            }

            return returnString;
        }

    }