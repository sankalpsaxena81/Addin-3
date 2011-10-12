using System;
using System.Collections.Generic;
using EnvDTE;

namespace MyAddin3
{
    public class VsSolution
    {
        private VsSolution()
        {
            Projects= new List<VsProject>();
        }
        public static VsSolution Parse(Solution solution)
        {
            var vsSolution = new VsSolution();
            foreach (Project project in solution.Projects)
            {
                VsProject vsProject = VsProject.Parse(project);
                vsSolution.Projects.Add(vsProject);
                Console.WriteLine(vsProject.ToString());
            }
            return vsSolution;

        }

        public List<VsProject> Projects { get; private set; }

        public override string ToString()
        {
            string s = "Soution";
            foreach (var vsProject in Projects)
            {
                s +="/n"+ vsProject.ToString();
            }
            return s;
        }
    }
}