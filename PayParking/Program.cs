using CommandDotNet;
using CommandDotNet.IoC.SimpleInjector;
using SimpleInjector;


namespace PayParking
{
    class Program
    {
        static int Main(string[] args)
        {
            var container = new Container();
            container.Register<ParkingManager>();
            container.Register<ParkingOperations>();
            
            return new AppRunner<ParkingManager>()               
                .UseSimpleInjector(container).Run(args);
        }
    }
}
