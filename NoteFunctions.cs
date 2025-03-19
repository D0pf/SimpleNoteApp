using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;

namespace Noteapp
{
    class NoteFunctions
    {
        public List<string> notes = new List<string>();

        internal void ShowAllNotes()
        {
            if (notes.Count == 0)
            {
                Console.WriteLine("You haven't added any notes yet.");
                return;
            }

            Console.WriteLine("Your notes:");
            int noteCounter = 1;
            foreach (string note in notes)
            {
                Console.WriteLine($"{noteCounter}. {note}");
                noteCounter++;
            }
        }

        internal void AddNote()
        {
            while (true)
            {
                Console.WriteLine("Please type in your note ('break' to stop):");
                string userNote = Console.ReadLine();

                if (userNote.ToLower() == "break")
                    break;

                notes.Add(userNote);
            }
        }

        internal void DeleteSingleNote()
        {
            Console.WriteLine("Please type in the note you want to delete:");
            string singleNoteToDelete = Console.ReadLine();

            if (notes.Remove(singleNoteToDelete))
                Console.WriteLine("Note was successfully removed.");
            else
                Console.WriteLine("Note not found!");
        }

        internal void DeleteCompleteNotes()
        {
            Console.WriteLine("Are you sure you want to delete all notes? (yes/no)");
            if (Console.ReadLine().ToLower() == "yes")
            {
                notes.Clear();
                Console.WriteLine("All notes have been deleted.");
            }
            else
                Console.WriteLine("Operation canceled.");
        }

        internal void SaveNoteToXML()
        {
            Console.WriteLine("Please enter the name of the XML file:");
            string xmlName = Console.ReadLine().ToLower();

            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };

            using (XmlWriter writer = XmlWriter.Create(xmlName, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Notes");

                foreach (string note in notes)
                {
                    writer.WriteElementString("Note", note);
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            Console.WriteLine("Notes successfully saved!");
        }
    }
}
