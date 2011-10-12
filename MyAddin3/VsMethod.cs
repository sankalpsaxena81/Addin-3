using System;
using EnvDTE;

namespace MyAddin3
{
    ///<summary>
    ///</summary>
    public class VsMethod
    {
        private VsMethod()
        {
            
        }
        public string Name { get; set; }

        public static VsMethod Parse(CodeFunction function)
        {
            var startPoint = function.StartPoint.CreateEditPoint();
            var endPoint = function.EndPoint.CreateEditPoint();
            int i = 1;
            while (startPoint.LessThan(endPoint))
            {
                i++;
                startPoint.LineDown(1);
            }
             
            return new VsMethod { Name = function.Name,Loc=i };
        }

        public int Loc { get; private set; }
    }
}