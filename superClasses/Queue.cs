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
       Among the Head and Tail are stored elements gathered by Nodes elements next that represent
        which element lies in a one afet position.        
       To conclude, Queue has the methods Enqueue to add new object always in Tail,
         DeQueue to Exclude an element from Head, And Peek that returns the Head of the Queue 
          without remove it.
*/ 
public class Queue<T> : IEnumerable<T>
{
    /* Attributes Head */
    private Node<T> head = null;
    public Node<T> Head { get => head; set => head = value; }

    /* Attributes Tail */
    private Node<T> tail = null;
    public Node<T> Tail { get => tail; set => tail = value; } 

    /* Attributes Current */
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

        // Check if head is not null
        if (this.Head != null) {
            // If not so, obj received the content in Head
            obj = this.Head.Content;

            // Head Received the next element of Head
            this.Head = this.Head.Next;

            // If Head is null
            if (this.Head == null)
                // Tail also receives null
                this.Tail = null;

            return obj;
        }

        return default(T);
    }

    public T Peek() {

        T obj;

        // Check if head is not null
        if (this.Head != null) {

            // If not so, obj received the content in Head
            obj = this.Head.Content;

            // Returns obj
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