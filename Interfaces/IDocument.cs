using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documents_Graf.Interfaces
{
    public interface IDocument
    {
        void Save(bool Update = false);

        List<Documents_Graf.Classes.DocumentContext> AllDocuments();
        void Delete();
    }
}
