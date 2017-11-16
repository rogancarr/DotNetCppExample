namespace NativeLibrary
{
    public interface INativeLibrary
    {
        /// <summary>
        /// Return the number 1
        /// </summary>
        /// <returns>The number 1</returns>
        int GetOne();

        /// <summary>
        /// Sum two numbers
        /// </summary>
        /// <param name="i">An integer</param>
        /// <param name="j">An integer</param>
        /// <returns>The sum of <paramref name="i"/> and <paramref name="j"/></returns>
        int AddTwoNumbers(int i, int j);

        /// <summary>
        /// Evaluate a function with integer inputs
        /// </summary>
        /// <param name="func">A delegate to a function taking two ints as input and returning an int</param>
        /// <param name="i">An integer</param>
        /// <param name="j">An integer</param>
        /// <returns>The result of the function</returns>
        int ExternalCall(Functions.AddTwoIntsDelegate func, int i, int j);

        /// <summary>
        /// Evaluate a reduce function
        /// </summary>
        /// <param name="reduceFunc">A delegate to a reduce function taking an integer array</param>
        /// <param name="array">The integer array</param>
        /// <param name="arraySize">The size of the integer array</param>
        /// <returns>The result of the reduce function</returns>
        int ExternalReduce(Functions.ReduceIntArrayDelegate reduceFunc, int[] array, int arraySize);

        /// <summary>
        /// Evaluate a reduce function taking a callback to a custom reducer
        /// </summary>
        /// <param name="reduceFunc">A delegate to a reducer function taking an integer array, the integer array size, and a pointer to a reducing function over the integer array</param>
        /// <param name="array">The integer array</param>
        /// <param name="arraySize">The size of the integer array</param>
        /// <returns></returns>
        int ExternalReduceWithCallback(Functions.ReduceNativeIntArrayWithFuncDelegate reduceFunc, int[] array, int arraySize);
    }
}
