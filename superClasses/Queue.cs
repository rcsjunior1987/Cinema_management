using System;
using System.Collections;
using System.Collections.Generic;

/*
    This class is a linear structure that follows the order First In First Out (FIFO).
     That means, the first element to get in the queue is the first to be manipulated.
      This class the attibutes Head, Tail, and Current that are instances from Node<T>.
       The object Head contains instances of any (T) type objects,
        and it represents the element located in the first position of the Queue.
       The object Tail stores the element in the last position of the Queue,
        whereas Current is the actual element being manipulated.
       Among the Head and Tail are stored elements gathered by Nodes elements previous
        and next that represent which element lies in a one before position,
        and next is the element that lies in one after position.
       To conclude, Queue has the methods Add to add new object always in Tail,
        Remove to Exclude an element from Head, GetHeadElement that returns the Head element,
         Contains to check whether an object is stored in the queue
          and Find that finds an object located in the queue.
*/ 
public class Queue<T> : IEnumerable<T>
{
    private Node<T> head = null;
    public Node<T> Head { get => head; set => head = value; }

    private Node<T> tail = null;
    public Node<T> Tail { get => tail; set => tail = value; } 

    private Node<T> current = null;
    public Node<T> Current { get => current; set => current = value; }

    public Queue()
    {
        this.Head = null;
        this.Current = null;
    }

    public void Enqueue(T obj)
    {
        Node<T> newNode = new Node<T>(obj, null);

        // Check if It is the first element to be inserted
        if (this.Head == null
         && this.Tail == null)
            // If so, this elements becomes the Head and Tail
            this.Head = this.Tail = newNode;
        else {
            // If there is already an element in the queue
            if (this.Head.Next == null)
                // This elements is inserted in the first position after Head
                this.Head.Next = newNode;
            else
                // If there is already more than one an element in the queue, 
                // The new element is inserted in the first position after Tail
                this.Tail.Next = newNode;
            // New element becomes Tail
            this.Tail = newNode;
        }
        
    }

    public T DeQueue() {

        T obj;

        if (this.Head != null) {
            obj = this.Head.Content;
            this.Head = this.Head.Next;

            if (this.Head == null)
                this.Tail = null;

            return obj;
        }

        return default(T);
    }

    public T Peek() {

        T obj;

        if (this.Head != null) {
            obj = this.Head.Content;

            return obj;
        }

        return default(T);
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        this.Current = this.Head;

        while (this.Current != null)
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