using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
    public partial class ProxyService : ServiceBase
    {
        public ServiceHost serviceHost = null;

        public ProxyService()
        {
            InitializeComponent();
            ServiceName = "WCFWindowsServiceSample";
        }

        
        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }
            serviceHost = new ServiceHost(typeof(ToDoProxyService));
            
            serviceHost.Open();
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }

        [RunInstaller(true)]
        public class ProjectInstaller : Installer
        {
            private ServiceProcessInstaller process;
            private ServiceInstaller service;

            public ProjectInstaller()
            {
                process = new ServiceProcessInstaller();
                process.Account = ServiceAccount.LocalSystem;
                service = new ServiceInstaller();
                service.ServiceName = "WCFWindowsServiceSample";
                Installers.Add(process);
                Installers.Add(service);
            }
        }
    }
}
