using System;

namespace ExcelApp
{
    internal class Application
    {
        public object Workbooks { get; internal set; }

        internal void Quit()
        {
            throw new NotImplementedException();
        }
    }
}