using System.Collections.Generic;
using EnvDTE;

namespace MyAddin3
{
    public class VsInterfaces
    {
        public static VsInterfaces Parse(CodeElement codeElement)
        {
            var vsInterface = new VsInterfaces();
            vsInterface.Name = codeElement.Name;
            foreach (CodeElement element in ((CodeInterface)codeElement).Members)
            {
                if (element.Kind == vsCMElement.vsCMElementFunction)
                {
                    CodeFunction function = element as CodeFunction;
                    vsInterface.Methods.Add(VsMethod.Parse(function));
                }
            }
            return vsInterface;
        }

        public List<VsMethod> Methods { get; set; }

        public string Name { get; set; }
    }
}