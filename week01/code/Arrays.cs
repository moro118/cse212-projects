public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // 1. Create an array of doubles with the size of 'length'.
        // 2. Use a for loop to iterate from 0 to length - 1
        // 3. In each iteration, calculate the multiple by multiplying 'number' with (i + 1)
        // 4. Assign the calculated multiple to the array at index i
        // 5. Return the array
        double[] multiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // 1. Create a new empty list to hold the rotated values.
        // 2. Add the last 'amount' elements from the original list to the new list.
        // 3. Add the remaining elements from the original list to the new list.
        // 4. Clear the original list.
        // 5. Add the elements from the new list to the original list.
        // 6. Return.
        List<int> newList = new();
        newList.AddRange(data.GetRange(data.Count - amount, amount));
        newList.AddRange(data.GetRange(0, data.Count - amount));
        data.Clear();
        data.AddRange(newList);
        return; 
    }
}
