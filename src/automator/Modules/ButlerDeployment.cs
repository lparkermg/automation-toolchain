using System;
using Modules.Interfaces;

namespace Modules
{
    public class ButlerDeployment: IAutoModule
    {
        private readonly string _macOsButlerPath = "";
        
        public bool Run<T>(T[] data)
        {
            Console.WriteLine("Running Butler Deployment");

            if (typeof(T) != typeof(string))
            {
                Console.WriteLine(
                    $"Incorrect Data Type Used: Type of {typeof(string)} required, but {typeof(T)} used.");
                return false;
            }

            var version = "0.0.0";
            var projectPath = "";
            
            throw new System.NotImplementedException();
        }
    }
}