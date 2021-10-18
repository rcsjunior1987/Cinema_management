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
        public Node<T> head = null;
        public Node<T> tail = null;
        public Node<T> current = null;
        public int Length = 0;

        public LinkedList() { }

        public Node<T> Previous()
        {
            return current.previous;
        }

        public Node<T> Next()
        {
            return current.next;
        }

        /* Adds an object in the end of the list. */
        public virtual void Add(T obj)
        {
            Node<T> previous = null;
            if (this.tail != null)
                previous = this.tail;

            Node<T> newNode = new Node<T>(obj, previous, null);

            if (this.Length == 0)
            {
                this.head = newNode;
                this.tail = newNode;
                this.current = newNode;
            }
            else
            {
                Node<T> testObject = this.Find(obj);
                if (testObject != null)
                {
                    testObject.quantity += 1;
                }
                else
                {
                    newNode.previous = this.tail;
                    this.tail.next = newNode;
                    this.tail = newNode;
                }
            }

            this.Length += 1;
        }

        /* Removes elements from any position of the List */
        public virtual void Remove()
        {
            if (this.Length > 0)
            {
                /* Check whether the obj to be removed lies in Tail */
                if (this.current == this.tail)
                {                    

                    if (this.Length > 1)
                    {
                        this.tail = this.current.previous;
                        this.current.previous.next = null;
                        this.current.previous = null;
                    } 
                    else
                    {
                        this.head = null;    
                        this.tail = null;
                    }
                        
                }
                else
                {
                    /* Check whether the obj to be removed lies in Head */
                    if (this.current == this.head)
                    {
                        this.current.next.previous = null;
                        this.head = this.current.next;
                    }
                    /* Remove from any position of the List */
                    else{
                        this.current.next.previous = this.current.previous;
                        this.current.previous.next = this.current.next;
                    }
                }

                --this.Length;
            }
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
            this.current = this.head;

            while (this.current != null)
            {
                yield return this.current.NodeObject;
                this.current = this.current.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        
    }