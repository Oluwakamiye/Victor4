using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victor4Library.Models;

namespace Victor4Library.Engines
{
    class NoteEngine
    {
        //logic to create, update and delete a note
        //logic to create, update and delete a notebook
        public NoteEngine()
        {
        }
        public void CreateNote(string title)
        {
            Note note = new Note();
            note.NoteHeader = title;
        }
        public void addToNote(string noteId, string title, string body)
        {
            Note note = GetNoteFromId(noteId);
            note.NoteHeader = title;
            note.NoteBody = body;
        }
        //Lets add a comment here to see the wonders of git
        public void deleteNote(string noteId)
        {
            Note note = GetNoteFromId(noteId);
            //logic to remove a note from a location
        }
        public Note GetNoteFromId(string noteId)
        {
            return new Note();
        }
        public void SaveNote(string noteId)
        {
            Note note = GetNoteFromId(noteId);
            //Logic to save a note to a location
        }
    }
}
