using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using bdForumBusinessLogic.BusinessLogic;
using bdForumBusinessLogic.Interfaces;
using bdForumBusinessLogic.ViewModels;
using bdForumDBImplement.Implements;
using Unity;
using Unity.Lifetime;

namespace bdForum
{
    static class Program
    {
        public static ModeratorViewModel Moderator { get; set; }
        public static VisitorViewModel Visitor { get; set; }
        public static DateTime myTimer { get; set; }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormSignIn>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IfacultiesStorage, facultiesStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IapplicantsStorage, applicantsStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IdirictionStorage, dirictionStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IsubjectStorage, subjectStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IuniversityStorage, universityStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<facultiesLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<applicantsLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<dirictionLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<subjectLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<universityLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
