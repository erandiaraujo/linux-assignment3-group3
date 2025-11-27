using System.Text.Json;

namespace LinuxCommandsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Linux Commands Reference App");
            Console.WriteLine("=============================\n");

            try
            {
                // Use full path to ensure we find the file
                string jsonFilePath = GetJsonFilePath();
                
                Console.WriteLine($"Loading commands from: {jsonFilePath}");

                if (!File.Exists(jsonFilePath))
                {
                    Console.WriteLine("Error: JSON file not found!");
                    Console.WriteLine("Please ensure the file exists at: Data/linux-commands.json");
                    return;
                }

                // Read and deserialize JSON
                string jsonString = File.ReadAllText(jsonFilePath);
                var commands = JsonSerializer.Deserialize<List<LinuxCommand>>(jsonString, 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (commands != null && commands.Count > 0)
                {
                    Console.WriteLine($"Found {commands.Count} Linux commands:\n");
                    
                    foreach (var command in commands)
                    {
                        command.DisplayCommandInfo();
                    }
                }
                else
                {
                    Console.WriteLine("No commands found in JSON file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static string GetJsonFilePath()
        {
            // Try multiple possible locations
            string[] possiblePaths = {
                Path.Combine("Data", "linux-commands.json"),
                Path.Combine("LinuxCommandsApp", "Data", "linux-commands.json"),
                "Data/linux-commands.json",
                "../Data/linux-commands.json"
            };

            foreach (string path in possiblePaths)
            {
                if (File.Exists(path))
                    return path;
            }

            return "Data/linux-commands.json"; // Default path
        }
    }
}