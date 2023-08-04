using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.github.olmoplanio.CeFCall.CeFEmulator
{
    interface IServer
    {
        void Listen();
        void Close();
        string LastMessage {
            get;
        } 
    }
}
