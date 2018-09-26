using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victor4Library.Util;

namespace Victor4Library.Models
{
    public class Note:IStandard
    {
        public Note()
        {
            this.NoteId = Utilities.GenerateId(7);
        }
        public string NoteId { get; private set; }
        public string NoteHeader { get; set; }
        public string NoteBody { get; set; }
        //TODO
        public string GetDocumentation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
