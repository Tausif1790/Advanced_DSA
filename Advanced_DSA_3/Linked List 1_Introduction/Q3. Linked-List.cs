Design and implement a Linked List data structure.
A node in a linked list should have the following attributes - an integer value and a pointer to the next node.

It should support the following operations:
insert_node(position, value) - To insert the input value at the given position in the linked list.
delete_node(position) - Delete the value at the given position from the linked list.
print_ll() - Print the entire linked list, such that each element is followed by a single space (no trailing spaces).

//---------------// Consider position as a idx (like List) //-------------------//
using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        // Example Usage:
        insert_node(1, 10);
        insert_node(2, 20);
        insert_node(3, 30);

        Console.WriteLine("Original Linked List:");
        print_ll();
    }
    
    public class Node
{
    public int data;
    public Node next;

    public Node(int x)
    {
        data = x;
        next = null;
    }
}
    // Head of the linked list
    static Node head = null;
    
    // Method to insert a node at a specific position
    public static void insert_node(int position, int value) {
        Node newNode = new Node(value);
        if (position == 1)
        {
            // Insert at the beginning of the list
            newNode.next = head;
            head = newNode;
        }
        else
        {
            // Traverse to the position-1 in the list
            Node temp = head;
            for (int i = 1; i < position - 1 && temp != null; i++)
            {
                temp = temp.next;
            }
            // Insert the new node at the specified position
            if (temp != null)
            {
                newNode.next = temp.next;
                temp.next = newNode;
            }
        }
    }

    // Method to delete a node at a specific position
    public static void delete_node(int position) {
        if (position == 1)
        {
            head = head.next;                   // Delete the node at the beginning of the list
        }
        else
        {
            // Traverse to the position-1 in the list
            Node temp = head;
            for (int i = 1; i < position - 1 && temp != null; i++)
            {
                temp = temp.next;
            }
            if (temp != null && temp.next != null)              // Delete the node at the specified position
                temp.next = temp.next.next;
        }
    }

    // Method to print the linked list elements
    public static void print_ll() {
        // Output each element followed by a space
        Node temp = head;
        if (temp == null) return;
        // Traverse the list and print each element followed by a space
        while (temp.next != null)
        {
            Console.Write(temp.data + " ");
            temp = temp.next;
        }
        Console.Write(temp.data);
    }
}

/*
The use of static in the declaration static Node head = null; means that the head variable belongs
 to the class rather than an instance of the class. In other words, there is only one head variable 
 shared among all instances of the class.

In the context of a linked list, having a static head is a common approach to maintain 
a single reference to the beginning of the list throughout the program.
 It allows all methods in the class to access and modify the same head reference, ensuring consistency across different operations.

If you were to create multiple instances of the LinkedList class,
 they would all share the same head reference. This is because the static keyword associates
  the variable with the class itself rather than with instances of the class.
*/