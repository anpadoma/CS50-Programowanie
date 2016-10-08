using System;
using System.IO;

namespace Chapter07
{
    public sealed class Logger : IDisposable
    {
        private StreamWriter _file;

        public Logger(string filePath)
        {
            _file = File.CreateText(filePath);
        }

        public void Dispose()
        {
            if (_file != null)
            {
                _file.Dispose();
                _file = null;
            }
        }
    }
}
