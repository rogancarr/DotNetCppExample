using System.Runtime.InteropServices;
using DotNetClientUtilities;

namespace NativeLibrary
{
    // Inherit from an abstract class
    public sealed class LinuxLibrary : INativeLibrary
    {        
        private const string CPP_LIBRARY = "../CppLibrary/CppLibrary/x64/linux/libCppLibrary.so";

        // Native implementation of GetOne() for Linux
        [DllImport(CPP_LIBRARY)]
        private static extern int get_one();

        // Native implementation of AddTwoNumbers() for Linux
        [DllImport(CPP_LIBRARY)]
        private static extern int add_two_numbers(int i, int j);

        // Native implementation of ExternalCall() for Linux
        [DllImport(CPP_LIBRARY)]
        private static extern int external_call(Functions.AddTwoIntsDelegate func, int i, int j);

        // Native implementation of ExternalReduce() for Linux
        [DllImport(CPP_LIBRARY)]
        private static extern int external_reduce(Functions.ReduceIntArrayDelegate reduceFunc, int[] array, int arraySize);

        // Native implementation of ExternalReduceWithCallback() for Linux
        [DllImport(CPP_LIBRARY)]
        private static extern int external_reduce_with_callback(
            Functions.ReduceNativeIntArrayWithFuncDelegate reduceFunc, int[] array, int arraySize);

        /// <summary>
        /// Return the number 1
        /// </summary>
        /// <returns>The number 1</returns>
        public int GetOne()
        {
            return get_one();
        }

        /// <summary>
        /// Sum two numbers
        /// </summary>
        /// <param name="i">An integer</param>
        /// <param name="j">An integer</param>
        /// <returns>The sum of <paramref name="i"/> and <paramref name="j"/></returns>
        public int AddTwoNumbers(int i, int j)
        {
            return add_two_numbers(i, j);
        }

        /// <summary>
        /// Evaluate a function with integer inputs
        /// </summary>
        /// <param name="func">A delegate to a function taking two ints as input and returning an int</param>
        /// <param name="i">An integer</param>
        /// <param name="j">An integer</param>
        /// <returns>The result of the function</returns>
        public int ExternalCall(Functions.AddTwoIntsDelegate func, int i, int j)
        {
            return external_call(func, i, j);
        }

        /// <summary>
        /// Evaluate a reduce function
        /// </summary>
        /// <param name="reduceFunc">A delegate to a reduce function taking an integer array</param>
        /// <param name="array">The integer array</param>
        /// <param name="arraySize">The size of the integer array</param>
        /// <returns>The result of the reduce function</returns>
        public int ExternalReduce(Functions.ReduceIntArrayDelegate reduceFunc, int[] array, int arraySize)
        {
            return external_reduce(reduceFunc, array, arraySize);
        }

        /// <summary>
        /// Evaluate a reduce function taking a callback to a custom reducer
        /// </summary>
        /// <param name="reduceFunc">A delegate to a reducer function taking an integer array, the integer array size, and a pointer to a reducing function over the integer array</param>
        /// <param name="array">The integer array</param>
        /// <param name="arraySize">The size of the integer array</param>
        public int ExternalReduceWithCallback(Functions.ReduceNativeIntArrayWithFuncDelegate reduceFunc, int[] array, int arraySize)
        {
            return external_reduce_with_callback(reduceFunc, array, arraySize);
        }
    }
}
