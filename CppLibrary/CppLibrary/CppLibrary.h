// CppLibrary.h - Contains declarations of functions and delegates
#pragma once

#ifndef _WINDOWS
#define __declspec(dllexport)
#endif
#ifdef CPPLIBRARY_EXPORTS  
#define CPPLIBRARY_API __declspec(dllexport)   
#else  
#define CPPLIBRARY_API __declspec(dllimport)   
#endif  

// Get the number 1
extern "C" CPPLIBRARY_API int get_one();

// Add two numbers
extern "C" CPPLIBRARY_API int add_two_numbers(int i, int j);

// Call a function with two integers
typedef int(*TwoIntReduceDelegate)(int a, int b);
extern "C" CPPLIBRARY_API int external_call(TwoIntReduceDelegate addTwoNumbers, int i, int j);

// Call a function that reduces an array
typedef int(*ReduceIntArrayDelegate)(int v[], int v_size);
extern "C" CPPLIBRARY_API int external_reduce(ReduceIntArrayDelegate reduceFunc, int i[], int i_size);

// Call a function that reduces an array using a supplied C++ function
typedef int(*ReduceIntArrayWithFuncDelegate)(int v[], int v_size, int(*ReduceIntArray)(int v[], int v_size));
extern "C" CPPLIBRARY_API int external_reduce_with_callback(ReduceIntArrayWithFuncDelegate reduceHostFunc, int i[], int i_size);
