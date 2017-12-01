using System;
using System.Collections.Generic;
using Modules;
using Modules.Interfaces;

namespace automator
{
    class Program
    {
        private static List<IAutoModule> _modules = new List<IAutoModule>()
        {
            new GameDevSetupModule(),
            new UnityBuilder()
        }; 
        
        static void Main(string[] args)
        {
            var res = RunApplication(args);
            
            if(!res)
                Console.WriteLine("Application failed to run.");
            else
                Console.WriteLine("Application ran successfully.");
            Console.WriteLine("Press Any Key to Exit.");
            Console.ReadKey();
        }

        private static bool RunApplication(string[] args)
        {
            if (args == null || args.Length == 0)
                return false;

            var toRun = args[0];
            
            switch (toRun)
            {
                case("gamedev-foldergen"):
                    return _modules[0].Run(new string[] {args[1], args[2]});
                case("build-unity-project"):
                    var data = new List<string>();
                    foreach (var arg in args)
                    {
                        if(!arg.Equals("build-unity-project"))
                            data.Add(arg);
                    }
                    return _modules[1].Run(data.ToArray());
                default:
                    Console.WriteLine($"Argument {toRun} not found");
                    return false;
            }
        }
    }
}