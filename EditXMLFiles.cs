using System;
using System.Xml;
using System.IO;
using System.Linq;

namespace Noteapp
{
    class EditXMLFiles
    {
        NoteFunctions noteFunctions = new NoteFunctions();

        internal void OpenXMLFile()
        {
            Console.WriteLine("Please enter the XML file name:");
            string xmlFileName = Console.ReadLine().ToLower();

            if (!File.Exists(xmlFileName))
            {
                Console.WriteLine("The file does not exist.");
                return;
            }

            Console.WriteLine("What do you want to do?\n" +
                              "'1' Show notes\n" +
                              "'2' Add notes\n" +
                              "'3' Delete a single note\n" +
                              "'4' Delete the complete file");
            char xmlEditing = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (xmlEditing)
            {
                case '1':
                    ShowAllNotes(xmlFileName);
                    break;
                case '2':
                    AddNewNotes(xmlFileName);
                    break;
                case '3':
                    noteFunctions.DeleteSingleNote();
                    break;
                case '4':
                    DeleteXMLFile(xmlFileName);
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }

        private void ShowAllNotes(string xmlFileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFileName);

            XmlNodeList notes = doc.SelectNodes("//Notes/Note");

            if (notes.Count == 0)
            {
                Console.WriteLine("No notes found.");
                return;
            }

            Console.WriteLine("Your notes:");
            int noteCounter = 1;
            foreach (XmlNode note in notes)
            {
                Console.WriteLine($"{noteCounter}. {note.InnerText}");
                noteCounter++;
            }
        }

        private void AddNewNotes(string xmlFileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFileName);

            XmlNode root = doc.SelectSingleNode("Notes");

            while (true)
            {
                Console.WriteLine("Enter a new note ('break' to stop):");
                string newNote = Console.ReadLine();
                if (newNote.ToLower() == "break")
                    break;

                XmlElement noteElement = doc.CreateElement("Note");
                noteElement.InnerText = newNote;
                root.AppendChild(noteElement);
            }

            doc.Save(xmlFileName);
            Console.WriteLine("Notes successfully added to XML.");
        }

        private void DeleteXMLFile(string xmlFileName)
        {
            Console.WriteLine("Are you sure you want to delete this file? (yes/no)");
            if (Console.ReadLine().ToLower() == "yes")
            {
                try
                {
                    File.Delete(xmlFileName);
                    Console.WriteLine("The XML file was deleted.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting file: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Operation canceled.");
            }
        }
    }
}
