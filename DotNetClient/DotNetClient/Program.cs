using System;
using System.Linq;
using NativeLibrary;

namespace DotNetClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get an instance of the appropriate native library
            INativeLibrary mathLibrary = NativeLibraryFactory.GetNativeLibrary();

            Console.WriteLine("Asking C++ for an int!");
            int one = mathLibrary.GetOne();
            Console.WriteLine($"I found {one}!");

            int two = 2;
            int three = 3;

            Console.WriteLine($"Adding {two} to {three} in C++.");
            int result = mathLibrary.AddTwoNumbers(two, three);
            Console.WriteLine($"{two} + {three} = {result}");

            Console.WriteLine($"Adding {two} to {three} in C++ via a .NET delegate");
            int resultDotNet = mathLibrary.ExternalCall(Functions.AddTwoInts, two, three);
            Console.WriteLine($"{two} + {three} = {resultDotNet}");

            Console.WriteLine($"Reducing array in C++ via a .NET delegate");
            int[] array = new int[3] { 6, 1, 3 };
            int reducedArray = mathLibrary.ExternalReduce(Functions.ReduceIntArray, array, array.Length);
            Console.WriteLine($"Reduced {string.Join(" + ", array.Select(i => $"{i}"))} to {reducedArray}");

            Console.WriteLine($"Reducing array in C++ via a .NET delegate taking a C++ reducer");
            int cReducedArray = mathLibrary.ExternalReduceWithCallback(Functions.ReduceNativeIntArrayWithNativeFunc, array, array.Length);
            Console.WriteLine($"Reduced {string.Join(" + ", array.Select(i => $"{i}"))} to {cReducedArray}");
        }
    }
}
