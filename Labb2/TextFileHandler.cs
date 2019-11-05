using System;
namespace Labb2
{
    public abstract class TextFileHandler
    {
        static public void WriteToFile(string path, string text, bool replace)
        {
            // Example #2: Write one string to a text file.
            //string text = "boo. ";
            //WriteAllText creates a file, writes the specified string to the file,
            //and then closes the file.    You do NOT need to call Flush() or Close().
            if (replace)
            {
                System.IO.File.WriteAllText(path, text);
            }
            else
            {
                //    // Example #4: Append new text to an existing file.
                //    // The using statement automatically flushes AND CLOSES the stream and calls 
                //    // IDisposable.Dispose on the stream object.
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    //file.WriteLine();
                    file.WriteLine(text);
                }
            }
        }

        static public string[] ReadFromFile(string path)
        {
            
            // Read the file as one string.
            //string text = System.IO.File.ReadAllText(path);

            // Display the file contents to the console. Variable text is a string.
            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            // Example #2
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(path);
            return lines;
        }
    }
}
       
