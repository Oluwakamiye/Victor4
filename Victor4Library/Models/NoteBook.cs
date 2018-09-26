using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victor4Library.Util;

namespace Victor4Library.Models
{
    public class NoteBook:IStandard
    {
        public NoteBook()
        {
            this.NoteBookId = Utilities.GenerateId(5);
        }
        public string NoteBookId { get; set; }
        public string NoteBookName { get; set; }
        public Dictionary<string, Note> Notes { get; set; }
        //TODO
        public string GetDocumentation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
