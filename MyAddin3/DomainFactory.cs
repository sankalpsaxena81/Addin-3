using System;
using EnvDTE;

namespace MyAddin3
{
    ///<summary>
    ///</summary>
    public class DomainFactory
    {
        public VsSolution CreateDomainObjectModel(Solution solution)
        {
            var vsSolution = VsSolution.Parse(solution);
//            new SolutionAnalyser(vsSolution).GetGeneralSolutionAnalyses();
            return  vsSolution;
        }
    }

    public class SolutionAnalyser
    {
        private readonly VsSolution _solution;

//        public SolutionAnalyser(VsSolution solution)
//        {
//            _solution = solution;
//        }
//
//        public SolutionAnalyses GetGeneralSolutionAnalyses()
//        {
//            var solutionAnalyses = new SolutionAnalyses();
//            foreach ( var project in _solution.Projects)
//            {
//                foreach (var file in project.Files)
//                {
//                    foreach (var @class in file.Classes)
//                    {
//                        
//                    }
//                }
//            }
//        }
    }

    public class SolutionAnalyses
    {
    }

    internal abstract class EnvDTEConstants
    {
        public const string vsProjectItemKindPhysicalFile = "{6BB5F8EE-4483-11D3-8BCF-00C04F8EC28C}";

    }
}
