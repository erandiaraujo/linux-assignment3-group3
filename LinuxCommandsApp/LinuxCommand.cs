namespace LinuxCommandsApp
{
    public class LinuxCommand
    {
        public string? Command { get; set; }
        public string? Description { get; set; }
        public string? Syntax { get; set; }
        public string? Category { get; set; }
        public string[]? Examples { get; set; }

        public void DisplayCommandInfo()
        {
            Console.WriteLine($"Command: {Command}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Syntax: {Syntax}");
            Console.WriteLine($"Category: {Category}");
            Console.WriteLine("Examples:");
            
            if (Examples != null)
            {
                foreach (var example in Examples)
                {
                    Console.WriteLine($"  - {example}");
                }
            }
            Console.WriteLine(new string('-', 50));
        }
    }
}