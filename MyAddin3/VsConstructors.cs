using System;
using EnvDTE;

namespace MyAddin3
{
    public class VsConstructors
    {
        private VsConstructors()
        {
            
        }
        public static VsConstructors Parse(CodeFunction function)
        {
            return new VsConstructors();
        }
    }
}