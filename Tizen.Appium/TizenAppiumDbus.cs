using System;
using System.Linq;
using System.Reflection;
using Tizen.Appium.Dbus;

namespace Tizen.Appium
{
    public class TizenAppiumDbus : IDisposable
    {
        static DbusConnection _dbusConn;
        bool disposed = false;

        internal static DbusConnection DbusConnection
        {
            get
            {
                return _dbusConn;
            }
        }

        public TizenAppiumDbus()
        {
            Console.WriteLine("#### TizenAppiumDbus");
            _dbusConn = new DbusConnection();

            InitializeDbusMethods();
        }

        void InitializeDbusMethods()
        {
            Assembly asm = typeof(TizenAppiumDbus).GetTypeInfo().Assembly;
            Type methodType = typeof(IDbusMethod);

            var methods = from method in asm.GetTypes()
                          where methodType.IsAssignableFrom(method) && !method.GetTypeInfo().IsInterface && !method.GetTypeInfo().IsAbstract
                          select Activator.CreateInstance(method) as IDbusMethod;

            foreach (var method in methods)
            {
                Console.WriteLine("#### method:{0}", method.ToString());
                _dbusConn.AddMethod(method);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _dbusConn.Close();
            }
            disposed = true;
        }
    }
}
