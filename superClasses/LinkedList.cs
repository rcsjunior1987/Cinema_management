using System;
using System.Collections;
using System.Collections.Generic;

/*
    This class represents a linked list, in which the elements are not stored at contiguous memory locations.
    It keeps Head, Tail, and Current elements as in Queue. However, the classes extended from LinkedList can be sorted.
     The element to be added not always goes to Head, and Tail is not always the one to be removed.
*/
public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head = null;
        public Node<T> Head { get => head; set => head = value; } 

        private Node<T> current = null;
        public Node<T> Current { get => current; set => current = value; }

        public LinkedList() { }

        /*public Node<T> Previous()
        {
            return current.Previous;
        }

        public Node<T> Next()
        {
            return current.Next;
        }*/

        /* Adds an object in the end of the list. */
        public virtual void Add(T obj)
        {
            //Create a new node  
            //Node<T> newNode = new Node<T>(obj, previous, next);
            Node<T> newNode = new Node<T>(obj, null);

            //link new node to list
            newNode.Next = this.Head;

            //head points to new node
            this.Head = newNode;
        }

        /* Removes elements from any position of the List */
        public virtual void Remove()
        {

            if (this.Current == this.Head)
            {
                //this.Current.Next.Previous = null;
                this.Head = this.Current.Next;
            }
            // Remove from any position of the List 
            else{
                //this.Current.Next.Previous = this.Current.Previous;
                //this.Current.Previous.Next = this.Current.Next;
            }


            /*if (this.Length > 0)
            {
                 Check whether the obj to be removed lies in Tail 
                if (this.current == this.tail)
                {                    

                    if (this.Length > 1)
                    {
                        this.tail = this.current.Previous;
                        this.current.Previous.Next = null;
                        this.current.Previous = null;
                    } 
                    else
                    {
                        this.head = null;    
                        this.tail = null;
                    }
                        
                }
                else
                {
                     Check whether the obj to be removed lies in Head 
                    if (this.current == this.head)
                    {
                        this.current.Next.Previous = null;
                        this.head = this.current.Next;
                    }
                     Remove from any position of the List 
                    else{
                        this.current.Next.Previous = this.current.Previous;
                        this.current.Previous.Next = this.current.Next;
                    }
                }

                --this.Length;
            }*/
        }

        public virtual bool Contains(T obj)
        {
            foreach (T element in this)
            {
                if (element.Equals(obj))
                    return true;
            }
            return false;
        }

        public virtual Node<T> Find(T obj)
        {
            if (this.Contains(obj))
                return this.current;
            return null;
        }

        public virtual int GetQuantity(T obj)
        {
            Node<T> testObject = this.Find(obj);
            if (testObject != null)
                return testObject.quantity;
            return 0;
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
        
    }