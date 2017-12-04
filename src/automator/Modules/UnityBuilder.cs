using System;
using System.Net.Http.Headers;
using Modules.Interfaces;

namespace Modules
{
    public class UnityBuilder : IAutoModule
    {
        private readonly string _macOsUnityPath = "/Applications/Unity/Unity.app/Contents/MacOS/Unity";
        private readonly string _windowsUnityPath = "C:\\Program Files\\Unity\\Editor\\Unity.exe";
        
        public bool Run<T>(T[] data)
        {
            Console.WriteLine("Running Unity Project Builder");

            if (typeof(T) != typeof(string))
            {
                Console.WriteLine(
                    $"Incorrect Data Type Used: Type of {typeof(string)} required, but {typeof(T)} used.");
                return false;
            }

            var version = "0.0.0";
            var projectPath = "";
            var target = "AllPc";
            var unityWindows = false;
            var debugMode = true;
            var buildPath = "Builds/";
            foreach (var arg in data)
            {
                if (arg.ToString().Contains("-version="))
                    version = arg.ToString().Replace("-version=", "");

                if (arg.ToString().Contains("-projectPath="))
                    projectPath = arg.ToString().Replace("-projectPath=","");

                if (arg.ToString().Contains("-targetBuild="))
                    target = arg.ToString().Replace("-targetBuild=", "");

                if (arg.ToString().Contains("-buildPath="))
                    buildPath = arg.ToString().Replace("-buildPath=","");

                if (arg.ToString().Equals("-debug"))
                    debugMode = true;

                if (arg.ToString().Equals("-release"))
                    debugMode = false;
            }

            var typeTag = debugMode ? "-debug" : "-release";
            
            if (String.IsNullOrWhiteSpace(projectPath))
            {
                Console.WriteLine("Project Path Required but none provided.");
                return false;
            }

            var unityLocation = unityWindows ? _windowsUnityPath : _macOsUnityPath;
            var command =
                $"{unityLocation} -quit -batchmode -logFile -projectPath {projectPath} -executeMethod BuildScript.{target} -version={version} -buildPath={buildPath} {typeTag}";
            var result = command.Bash();
            Console.WriteLine(result);
            return true;
        }
    }
}