using System;
using System.Collections.Generic;
using EnvDTE;

namespace MyAddin3
{
    public class VsClass
    {
        private VsClass()
        {
           Variables= new List<VsVariable>();
            Methods= new List<VsMethod>();
            Constructors= new List<VsConstructors>();
        }
        
        public List<VsMethod> Methods{ get; set; }
        public string Name { get; set; }

        public List<VsVariable> Variables { get; set; }

        public List<VsConstructors> Constructors { get; set; }

        public static VsClass Parse( CodeElement codeElement)
        {
            var vsClass = new VsClass();
            vsClass.Name = codeElement.Name;
            var codeClass = (CodeClass) codeElement;
            var startPoint = codeClass.StartPoint.CreateEditPoint();
            var endPoint = codeClass.EndPoint.CreateEditPoint();
            int i = 1;
            while( startPoint.LessThan(endPoint))
            {
                i++;
                startPoint.LineDown(1);
            }
            vsClass.Loc = i;
            foreach (CodeElement element in ((CodeClass)codeElement).Members)
            {

                if (element.Kind == vsCMElement.vsCMElementVariable)
                {
                    vsClass.Variables.Add(VsVariable.Parse(element));
                }
                else if (element.Kind == vsCMElement.vsCMElementFunction)
                {
                    CodeFunction function = element as CodeFunction;
                    if (function.FunctionKind == vsCMFunction.vsCMFunctionConstructor)
                        vsClass.Constructors.Add(VsConstructors.Parse(function));
                    else
                        vsClass.Methods.Add(VsMethod.Parse(function));
                }
            }
            return vsClass;
        }

        public int Loc { get; private set; }
    }
}