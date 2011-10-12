using System;
using System.Collections.Generic;
using EnvDTE;

namespace MyAddin3
{
    public class VsFile
    {
        public VsFile()
        {
            Classes= new List<VsClass>();
        }
        public string Namespaces { get; set; }

        public List<VsClass> Classes { get; set; }

        public List<VsInterfaces> Interfaces { get; set; }

        public override string ToString()
        {
            string s = "Classes in File=> ";
            foreach (var vsClass in Classes)
            {
                s += vsClass.Name+" ";
            }
            return s;
        }

        public static VsFile Parse(FileCodeModel fileCodeModel)
        {
            var vsFile = new VsFile();
            
            foreach (CodeElement cdElement in fileCodeModel.CodeElements)
            {
                if (cdElement.Kind == vsCMElement.vsCMElementNamespace)
                {
                    Parse(vsFile,cdElement);
                }
            }
            return vsFile;
        }
        private static VsFile Parse(VsFile vsFile,CodeElement cdElement)
        {
            vsFile.Namespaces = cdElement.FullName;
            foreach (CodeElement codeElement in ((CodeNamespace)cdElement).Members)
            {
                if (codeElement.Kind == vsCMElement.vsCMElementClass)
                {
                    vsFile.Classes.Add(VsClass.Parse(codeElement));
                    
                }
                else if (codeElement.Kind == vsCMElement.vsCMElementInterface)
                {

                    vsFile.Interfaces.Add(VsInterfaces.Parse(codeElement));
                }

                

            }
            return vsFile;
        }

        
    }
}