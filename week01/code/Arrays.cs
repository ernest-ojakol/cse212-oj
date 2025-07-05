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
        //Initiate array with length passed in the header
        double[] multiples = new double[length];

        //populate multiples array with multiples
        for (var i = 1; i <= length; i++)
        {
            multiples[i - 1] = number * i;
        }

        //return multiples array
        return multiples; // replace this return statement with your own
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

        // Optimize amount using modulo
        // Since rotating by data.Count returns the original list, reduce amount
        amount = amount % data.Count;

        // If amount equals data.Count after modulo, the list is unchanged
        if (amount == 0)
        {
            return;
        }

        //Helper function to reverse a portion of the list from start to end
        void Reverse(int start, int end)
        {
            while (start < end)
            {
                // Swap elements at start and end
                int temp = data[start];
                data[start] = data[end];
                data[end] = temp;
                start++;
                end--;
            }
        }

        // Perform the rotation using three reversals
        // Reverse the entire list
        Reverse(0, data.Count - 1);
        // Reverse the first 'amount' elements
        Reverse(0, amount - 1);
        // Reverse the remaining elements
        Reverse(amount, data.Count - 1);
    }
}
