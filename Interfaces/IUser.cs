using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documents_Graf.Interfaces
{
    public interface IUser
    {
        void Save(bool Update = false);
        List<Classes.UserContext> AllUsers();
        void Delete();
    }
}
