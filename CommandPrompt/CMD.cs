using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CommandPrompt
{
    class CMD
    {
        int height;
        int width;
        string[] screenText;
        ConsoleColor backgroundColor;
        ConsoleColor foregroundColor;
        public CMD(int height, int width)
        {
            backgroundColor = ConsoleColor.Blue;   // or whatever you like
            foregroundColor = ConsoleColor.Red; // or whatever you like
            screenText = new string[height];
            Console.SetWindowSize(width, height + 7);
            for (int i = 0; i < screenText.Length; i++)
            {
                screenText[i] = "";
            }
        }
        public void Display()
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            // set the foreground and background colors
            Console.Clear();             //  the Console object is available to us to control aspects of our terminal window. The Clear method will blank our window
                                         // The Clear method has blanked the screen and left the cursor at the top of the window.
                                         // We will now loop through the screenText array to put out text on the screen.
            for (int i = 0; i < screenText.Length; i++)
            {
                Console.WriteLine(screenText[i]);
            }

        }   // end of Display method
        public void SetScreenText(int lineNumber, string lineOfText)
        {
            screenText[lineNumber] = lineOfText;
        }   // end of SetScreenText method
        public void SetBackgroundColor(string color)
        {
            backgroundColor = ConvertColor(color);
        }   // end of SetBackgroundColor

        public void SetForegroundColor(string color)
        {
            foregroundColor = ConvertColor(color);
        }   // end of SetForegroundColor
        public static ConsoleColor ConvertColor(string strColor)
        {
            ConsoleColor color;
            switch (strColor.ToLower())
            {
                case "black": color = ConsoleColor.Black; break;
                case "red": color = ConsoleColor.Red; break;
                case "green": color = ConsoleColor.Green; break;
                case "yellow": color = ConsoleColor.Yellow; break;
                case "white": color = ConsoleColor.White; break;
                case "magenta": color = ConsoleColor.Magenta; break;
                case "cyan": color = ConsoleColor.Cyan; break;
                case "darkblue": color = ConsoleColor.DarkBlue; break;
                case "darkcyan": color = ConsoleColor.DarkCyan; break;
                case "darkred": color = ConsoleColor.DarkRed; break;
                case "darkyellow": color = ConsoleColor.DarkYellow; break;
                case "gray": color = ConsoleColor.Gray; break;


                default: color = ConsoleColor.DarkGray; break;
            }
            return color;
        }   // end of ConvertColor method
        public void SaveScreen(string fileName)
        {
            StreamWriter textOut = null;
            try
            {
                fileName = "../../../" + fileName;
                textOut = new StreamWriter(fileName);
                foreach (var line in screenText)
                {
                    textOut.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Creating file: ");
                Console.WriteLine(ex.ToString());
                return;
            }
            finally
            {
                if (textOut != null)
                    textOut.Close();
            }
        }   // End of SaveScreen method
        public void ReloadScreen(string fileName)
        {
            string line;
            int lineNumber = 0;
            StreamReader textIn;
            fileName = "../../../" + fileName;
            textIn = new StreamReader(fileName);
            while (true)
            {
                line = textIn.ReadLine();
                if(line == null)
                {
                    break;
                }
                screenText[lineNumber] = line;
                lineNumber++;
            }
            textIn.Close();
        }
    }
}
