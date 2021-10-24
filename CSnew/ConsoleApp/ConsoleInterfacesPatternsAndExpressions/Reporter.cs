﻿using ConsolePatternsIntroduction.Exceptions;
using System;

namespace ConsolePatternsIntroduction
{
    public class Reporter : IReporter
    {
        public void Report(Exception ex,string description, SeverityLevel level)
        {
            switch (level)
            {
                case SeverityLevel.Trace:
                    WriteLine(ex, ConsoleColor.Cyan, $"Trace: {description}");
                    break;
                case SeverityLevel.Info:
                    WriteLine(ex, ConsoleColor.DarkBlue, $"Info: {description}");
                    break;
                case SeverityLevel.Warning:
                    WriteLine(ex, ConsoleColor.DarkYellow, $"Warning: {description}");
                    break;
                case SeverityLevel.Error:
                    WriteLine(ex, ConsoleColor.Red, $"Error: {description}");
                    break;
                case SeverityLevel.Critical:
                    WriteLine(ex, ConsoleColor.Magenta, $"Critical: {description}");
                    break;
                default:
                    break;
            }
        }

        private void WriteLine(Exception ex, ConsoleColor color, string text)
        {
            switch(ex)
            {
                case DatabaseException dbex:
                    text = $"[Database - {dbex.DbName}]: " + text;
                    break;
                case FileSystemException fsex:
                    text = $"[FS]: " + fsex.Message + " " + text;
                    break;
                case HttpException httpEx:
                    text = $"[HTTP Error]{httpEx.StatusCode} - {httpEx.Url}: " + text;
                    break;
                default:
                    break;
            }
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = currentColor;
        }
    }
}
