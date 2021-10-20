using System;
using System.Collections;
using System.Collections.Generic;

/*
    It is a generic implimentation of a sorted LinkedList class.
     It is extended from IComparable. That is, any object that can be
       compared to another with the CompareTo() method, which is used
        to compare elements to be able to sort them.
*/     
 
public class GenericLinkedList<T> : LinkedList<T> where T : IComparable
    {
        public GenericLinkedList() : base() {}

        public override void Add(T obj)
        {
            base.Add(obj);
        }

        public virtual void Sort() { }

        public virtual void Remove(T obj) {
            base.Remove();
        }

        public virtual Node<T> Search(T obj) {
             return null;
        }

    }