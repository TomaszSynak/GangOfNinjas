using Microsoft.ServiceFabric.Services.Runtime;
using System;
using System.Diagnostics;
using System.Threading;

namespace HiddenNinja
{
    internal static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            try
            {
                ServiceRuntime.RegisterServiceAsync("HiddenNinjaType", context => new HiddenNinja(context)).GetAwaiter().GetResult();

                ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(HiddenNinja).Name);

                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception exception)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(exception.ToString());
                throw;
            }
        }
    }
}
