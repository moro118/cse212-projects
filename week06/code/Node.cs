using System;

public class Node
{
    public int Data { get; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public Node(int value)
    {
        Data = value;
    }

    // Problem 1: Insert Unique Values Only
    public void Insert(int value)
    {
        if (value < Data)
        {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // if value == Data do nothing (no duplicates)
    }

    // Problem 2: Contains
    public bool Contains(int value)
    {
        if (value == Data) return true;
        if (value < Data)
            return Left != null && Left.Contains(value);
        return Right != null && Right.Contains(value);
    }

    // Problem 4: GetHeight
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}