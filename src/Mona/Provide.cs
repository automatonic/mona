using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Mona
{
    public static class Provide
    {
        public static Input Default()
        {
            return new Input();
        }

        public static bool Single(Uri uri, out Input input)
        {
            switch (uri)
            {
                case Uri _ when uri.IsFile && File.Exists(uri.LocalPath):
                    return AllText(uri.LocalPath, out input);
                default:
                    input = new Input();
                    return false;
            }
            bool AllText(string path, out Input result)
            {
               var buffer = File.ReadAllText(path);
               result = new Input(uri, buffer.AsSpan());
               return true;
            }
        }
    }
}
