using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    abstract class Tools
    {
        public static Tools MakeTool(string type)
        {
            switch (type)
            {
                case "Pencil":
                    return new Pencil();
                default:
                    throw new InvalidOperationException();
            }
        }

        public void UseToolAt(int x, int y)
        {
            throw new NotImplementedException();
        }

        protected abstract void ApplyTool(int x, int y);
    }
}
