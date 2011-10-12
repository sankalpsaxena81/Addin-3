using System;
using EnvDTE;

namespace MyAddin3
{
    public class VsVariable
    {
        private VsVariable()
        {
            
        }
        public string Name { get; set; }

        public static VsVariable Parse(CodeElement element)
        {
            return new VsVariable { Name = element.Name };
        }
    }
}