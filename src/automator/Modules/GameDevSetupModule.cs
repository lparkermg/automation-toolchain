using System;
using System.IO;
using Modules.Interfaces;

namespace Modules
{
    public class GameDevSetupModule : IAutoModule
    {

        private string[] _directories2D = new string[]
        {
            "/Audio/Bgm",
            "/Audio/Sfx",
            "/Data",
            "/Fonts",
            "/Graphics/UI",
            "/Graphics/Logos",
            "/Graphics/Game",
            "/Materials/Paritcles",
            "/Materials/Game",
            "/Prefabs",
            "/Scenes",
            "/Scripts/Managers",
            "/Scripts/Helpers",
            "/Scripts/Enums",
            "/Scripts/Entities"
        };
        private string[] _directories3D = new string[]
        {
            "/Audio/Bgm",
            "/Audio/Sfx",
            "/Data",
            "/Fonts",
            "/Graphics/UI",
            "/Graphics/Logos",
            "/Graphics/Game",
            "/Materials/Paritcles",
            "/Materials/Game",
            "/Models",
            "/Prefabs",
            "/Scenes",
            "/Scripts/Managers",
            "/Scripts/Helpers",
            "/Scripts/Enums",
            "/Scripts/Entities"
        };
        public bool Run<T>(T[] data)
        {
            Console.WriteLine("Running GameDev Setup Module.");
            
            if (typeof(T) != typeof(string))
            {
                Console.WriteLine(
                    $"Incorrect Data Type Used: Type of {typeof(string)} required, but {typeof(T)} used.");
                return false;
            }
            
            var location = data[0];
            var is2D = data[1].Equals("--2d");

            var dirs = is2D ? _directories2D : _directories3D;
            try
            {
                foreach (var dir in dirs)
                {
                    Directory.CreateDirectory($"{location}{dir}");
                }
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error Creating Directories:");
                Console.WriteLine($"{ioe} - {ioe.Message}");
                return false;
            }
            
            Console.WriteLine("Files Generated. Finishing.");
            return true;
        }
    }
}