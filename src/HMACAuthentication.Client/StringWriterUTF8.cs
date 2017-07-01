using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HMACAuthentication.Client
{
    public class StringWriterUTF8 : StringWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}
