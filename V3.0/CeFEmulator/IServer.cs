using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.github.olmoplanio.CeFCall.CeFEmulator
{
    public interface IServer
    {
        void Start();
        void Close();
        string History {
            get;
        } 
    }
}
