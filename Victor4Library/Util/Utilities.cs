using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victor4Library.Models;

namespace Victor4Library.Util
{
    public class Utilities
    {
        static string homePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RossRecords\\";
        static Random random = new Random();

        public static string GenerateId(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //Write operations
        public static void WriteToNote(string fileTitle, string text)
        {
            string fullPath = homePath + fileTitle;
            if (File.Exists(homePath))
            {
                using (var tw = new StreamWriter(fullPath, true))
                {
                    tw.WriteLine(text);
                }
            }
            else
            {
                File.Create(fullPath);
                using (var tw = new StreamWriter(fullPath, true))
                {
                    tw.WriteLine(text);
                }
            }
        }
        public static void WriteToNote(string fileTitle, Note note)
        {
            //TODO
        }
        public static void WriteToJson(string fileTitle, string text)
        {
            //TODO;
            //Find out if the file has been created before
            //Write or append to the file
        }
        public static void WriteToJson(string fileTitle, Note note)
        {
            //TODO
        }
        public List<TaskToDo> GetTasks(string fileTitle)
        {
            //TODO
            return new List<TaskToDo>();
        }

        //File Operations (Moving, Retrieving and Storing)
        public void MoveFile(string originPath, string destinationPath)
        {
            //TODO
            //Logic to move files
            //Should throw an exception
        }
        private static Note GetNote(string noteId)
        {
            //TODO
            return new Note();
        }
        private static NoteBook GetNoteBook(String noteBookId)
        {
            //TODO
            return new NoteBook();
        }

        private String RetrieveDocumentation(IStandard standard)
        {
            return standard.GetDocumentation;
        }
    }
}
