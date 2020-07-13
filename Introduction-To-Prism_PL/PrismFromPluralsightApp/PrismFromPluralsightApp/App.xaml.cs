 
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using PrismDemo.Core.Commands;
using PrismFromPluralsightApp.Adapters;
using PrismFromPluralsightApp.Views;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace PrismFromPluralsightApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
        }




        //protected override void ConfigureViewModelLocator()
        //{
        //    base.ConfigureViewModelLocator();

        //    ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
        //    {
        //        var viewName = viewType.FullName;
        //        var assemblyName = viewType.Assembly.FullName;
        //        var vmName = $"{viewName.Replace("Views", "ViewModels")}ViewModel, {assemblyName}";
        //        return Type.GetType(vmName);
        //    });
        //}




        /// <summary>
        /// Register a module by code
        /// </summary>        
        //protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        //{
        //    moduleCatalog.AddModule<ModuleAModule>();
        //}

        /// <summary>
        /// Register a module using a directory
        /// </summary>
        /// <param name="regionAdapterMappings"></param>
        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
        //}

        protected override IModuleCatalog CreateModuleCatalog()
        { 
            return new ConfigurationModuleCatalog();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
        }


    }
}
