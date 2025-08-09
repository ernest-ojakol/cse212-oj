public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Skip if value already exists (ensuring unique values)
        if (value == Data)
            return;

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // Check if current node's data matches the value
        if (value == Data)
            return true;

        // Search left subtree if value is less than current node's data
        if (value < Data)
        {
            if (Left is null)
                return false;
            return Left.Contains(value);
        }
        // Search right subtree if value is greater than or equal to current node's data
        else
        {
            if (Right is null)
                return false;
            return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // Initialize heights of left and right subtrees
        int leftHeight = 0;
        int rightHeight = 0;

        // Recursively get the height of the left subtree if it exists
        if (Left is not null)
            leftHeight = Left.GetHeight();

        // Recursively get the height of the right subtree if it exists
        if (Right is not null)
            rightHeight = Right.GetHeight();

        // Return 1 plus the maximum height of the left or right subtree
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}