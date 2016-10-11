using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCommissionCorrect.baseClasses
{

    public class IoCManager 
    {
        private IUnityContainer _Ioc;

        private static IoCManager _Instance;
        public static IoCManager Current
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new IoCManager();
                }
                return _Instance;
            }
        }

        private IoCManager()
        {
            try
            {
                //  This creates a new unitycontainer object 
                //  It does all the injection work for us
                _Ioc = new UnityContainer();

                //  Load the app.config section titled "unity"
                UnityConfigurationSection section =
                    (UnityConfigurationSection)ConfigurationManager.GetSection("unity");

                //  Point that section to the new container and 
                //  Tell it to add all dependancies found in the config
                //  INto the UnityContainer
                section.Configure(_Ioc);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public T FetchDependency<T>(string name)
        {
            //  Calls on Unity to find the right class based on config
            return _Ioc.Resolve<T>(name);
        }
    }

}
