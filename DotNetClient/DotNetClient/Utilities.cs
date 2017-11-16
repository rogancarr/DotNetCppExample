using System;
using System.IO;
using System.Reflection;

namespace DotNetClientUtilities
{
    public static class Utilities
    {
        public static string GetPathToExecutingAssembly()
        {
            return Path.GetDirectoryName(
               new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
        }
    }
}
