using ModuleA.Controls;
using ModuleA.ViewModels;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows.Controls;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private IRegionManager _regionManager;

        // Post-Build event: Register using a directory:
        // xcopy "$(TargetDir)$(TargetName)*$(TargetExt)" "$(SolutionDir)$(SolutionName)\bin\Debug\netcoreapp3.1\Modules\" /Y /S


        public ModuleAModule(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
        }




        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegion region = _regionManager.Regions["ContentRegion"];

            var tabA = containerProvider.Resolve<TabView>();
            SetTitle(tabA, "Tab A");
            region.Add(tabA);

            var tabB = containerProvider.Resolve<TabView>();
            SetTitle(tabB, "Tab B");
            region.Add(tabB);

            var tabC = containerProvider.Resolve<TabView>();
            SetTitle(tabC, "Tab C");
            region.Add(tabC);
        }

        void SetTitle(TabView tab, string title)
        {
            (tab.DataContext as TabViewModel).Title = title;
        }


        //public void OnInitialized(IContainerProvider containerProvider)
        //{

        //    _regionManager.RegisterViewWithRegion("ContentRegion", typeof(TabView));


        //    //  UsingViewInjection(containerProvider);

        //    //  UsingViewDiscovery();
        //}


        private void UsingViewDiscovery()
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(TabView));
        }

        private void UsingViewInjection(IContainerProvider containerProvider)
        {
            IRegion region = _regionManager.Regions["ContentRegion"];

            var view1 = containerProvider.Resolve<TabView>();
            region.Add(view1);

            var view2 = containerProvider.Resolve<TabView>();
            view2.Content = new TextBlock()
            {
                Text = "Hello from View 2",
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Center
            };

            region.Add(view2);

            region.Activate(view2);

            region.Activate(view1);

            region.Deactivate(view1);

            region.Activate(view2);

            region.Remove(view2);

            region.Activate(view1); 
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<ControlA, ControlAViewModel>();

          
            //ViewModelLocationProvider.Register<ControlA>(() => new ControlAViewModel() { Text = "Hello from Factory" });


            //  containerRegistry.RegisterForNavigation<ViewB>();
        }
    }
}