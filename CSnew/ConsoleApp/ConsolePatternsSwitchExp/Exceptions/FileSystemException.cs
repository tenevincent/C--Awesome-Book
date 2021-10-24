using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolePatternsSwitchExp.Exceptions
{
    public class FileSystemException : Exception
    {
        public FileSystemException(string message) : base(message)
        {
        }
    }
}
