# DotNetCppExample

This is an example project showing how to pass data and functions back and forth across .NET and C++ on Linux and Windows with one cross-platform .NET build using the new .NET Core 2.0 framework. This is useful if you are using a cross-platform .NET framework, but want to let various components be composed of native code, built for the specific OS.

## Prerequisites

.NET Core 2.0 ([download](https://www.microsoft.com/net/download/core))

Visual Studio ([download](https://www.visualstudio.com/downloads/)) or your preferred method for compiling C++ on Windows

The GNU C++ compiler (g++) or your preferred C++ compiler for Linux

## Building

1. Build the C++ Library

For Linux:

```
cd CppLibrary/CppLibrary/
make all
```

For Windows

  - Open the `CppLibrary.sln` solution in Visual Studio
  - Click `Build`

2. Build the .NET solution

Build on the command line (Linux or Windows)

```
cd DotNetClient/
dotnet build DotNetClient.sln
```

*or*

  - Open the `DotNetClient/DotNetClient.sln` solution in Visual Studio
  - Build

## Running

To run the DotNet Core 2.0 example program, you will use the `dotnet` application:

```
cd DotNetClient
dotnet DotNetClient/bin/x64/Debug/netcoreapp2.0/DotNetClient.dll
```

This example code works on both Linux and Windows (although on Windows, `s/\//\\/g`).

** Note that at this point, the program will only run from this directory, as the library locations have been hardcoded. See [Issue #3](https://github.com/rogancarr/DotNetCppExample/issues/3).