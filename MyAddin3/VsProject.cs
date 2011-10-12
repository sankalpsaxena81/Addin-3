using System;
using System.Collections.Generic;
using EnvDTE;

namespace MyAddin3
{
    public class VsProject
    {
        public List<VsFile> Files { get; set; }

        public VsProject()
        {
            Files = new List<VsFile>();
        }

        public override string ToString()
        {
            string s = "Files in Project => ";
            foreach (var vsFile in Files)
            {
                s += vsFile.ToString() + " ";
            }
            return s;
        }

        public static VsProject Parse(Project project)
        {
            var vsProject = new VsProject();
            foreach (ProjectItem projectItem in project.ProjectItems)
            {
                if (projectItem.Kind == EnvDTEConstants.vsProjectItemKindPhysicalFile)
                {
                    FileCodeModel fileCodeModel = projectItem.FileCodeModel;
                    vsProject.Files.Add(VsFile.Parse(fileCodeModel));
                }
            }
            return vsProject;
        }
    }
}