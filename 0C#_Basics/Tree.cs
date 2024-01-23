//-------------------// Binary Tree Operations: //------------------------//
class BinaryTree
{
    class Node
    {
        public int Data;
        public Node Left, Right;

        public Node(int item)
        {
            Data = item;
            Left = Right = null;
        }
    }

    //Data: An integer variable representing the data or value stored in the node.
    //Left: A reference to the left child node.
    //Right: A reference to the right child node.

    Node root;

    // Constructor
    public BinaryTree()
    {
        root = null;
    }

    // Inorder traversal of the tree
    void Inorder(Node node)
    {
        if (node != null)
        {
            Inorder(node.Left);
            Console.Write(node.Data + " ");
            Inorder(node.Right);
        }
    }

    // Public method to perform Inorder traversal
    public void Inorder()
    {
        Inorder(root);
    }
}

//----------------// Binary Search Tree (BST) Operations: //------------------------//
class BinarySearchTree
{
    class Node
    {
        public int Data;
        public Node Left, Right;

        public Node(int item)
        {
            Data = item;
            Left = Right = null;
        }
    }

    Node root;

    // Constructor
    public BinarySearchTree()
    {
        root = null;
    }

    // Insert a value into the BST
    Node Insert(Node root, int data)
    {
        if (root == null)
        {
            root = new Node(data);
            return root;
        }

        if (data < root.Data)
            root.Left = Insert(root.Left, data);
        else if (data > root.Data)
            root.Right = Insert(root.Right, data);

        return root;
    }

    // Public method to insert a value
    public void Insert(int data)
    {
        root = Insert(root, data);
    }

    // Inorder traversal of the BST
    void Inorder(Node node)
    {
        if (node != null)
        {
            Inorder(node.Left);
            Console.Write(node.Data + " ");
            Inorder(node.Right);
        }
    }

    // Public method to perform Inorder traversal
    public void Inorder()
    {
        Inorder(root);
    }
}

//----------------// Trie (Prefix Tree) Operations: //------------------------//
class Trie
{
    class TrieNode
    {
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public bool IsEndOfWord;
    }

    TrieNode root;

    // Constructor
    public Trie()
    {
        root = new TrieNode();
    }

    // Insert a word into the trie
    public void Insert(string word)
    {
        TrieNode node = root;
        foreach (char c in word)
        {
            if (!node.Children.ContainsKey(c))
                node.Children[c] = new TrieNode();

            node = node.Children[c];
        }
        node.IsEndOfWord = true;
    }

    // Search for a word in the trie
    public bool Search(string word)
    {
        TrieNode node = root;
        foreach (char c in word)
        {
            if (!node.Children.ContainsKey(c))
                return false;

            node = node.Children[c];
        }
        return node.IsEndOfWord;
    }
}
