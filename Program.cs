using System;

namespace Noteapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool noteAppIsRunning = true;
            NoteFunctions notes = new NoteFunctions();
            EditXMLFiles xmlFiles = new EditXMLFiles();

            while (noteAppIsRunning)
            {
                Console.WriteLine("\nPlease choose an operation:\n" +
                                  "'1' Show all notes\n" +
                                  "'2' Add a new note\n" +
                                  "'3' Delete a single note\n" +
                                  "'4' Delete all notes\n" +
                                  "'5' Save notes to XML file\n" +
                                  "'6' Open existing note (XML file)\n" +
                                  "'7' Quit program");

                char userOperation = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (userOperation)
                {
                    case '1': notes.ShowAllNotes(); break;
                    case '2': notes.AddNote(); break;
                    case '3': notes.DeleteSingleNote(); break;
                    case '4': notes.DeleteCompleteNotes(); break;
                    case '5': notes.SaveNoteToXML(); break;
                    case '6': xmlFiles.OpenXMLFile(); break;
                    case '7': noteAppIsRunning = false; break;
                    default: Console.WriteLine("Invalid input. Use 1-7."); break;
                }
            }
        }
    }
}
