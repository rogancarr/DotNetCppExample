using System;
using System.Runtime.InteropServices;

namespace NativeLibrary
{
    /// <summary>
    /// A factory for producing INativeLibraries compatible with the underlying Operating System
    /// </summary>
    public static class NativeLibraryFactory
    {
        /// <summary>
        /// Produce an INativeLibrary compatible with the current runtime
        /// </summary>
        /// <returns>An INativeLibrary instance</returns>
        public static INativeLibrary GetNativeLibrary()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.WriteLine("Running Windows!");
                return new WindowsLibrary();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Console.WriteLine("Running Linux!");
                return new LinuxLibrary();
            }
            else
            {
                throw new NotImplementedException($"OS {RuntimeInformation.OSDescription} not supported");
            }
        }
    }
}
