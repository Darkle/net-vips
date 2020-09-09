namespace NetVips.Samples
{
    using System;

    public class Sobel : ISample
    {
        public string Name => "Sobel";
        public string Category => "Edge detection";

        public const string Filename = "images/lichtenstein.jpg";

        public void Execute(string[] args)
        {
            var im = Image.NewFromFile(Filename, access: Enums.Access.Sequential);

            // Optionally, convert to greyscale
            // im = im.Colourspace("b-w");

            // Apply sobel operator
            im = im.Sobel();

            im.WriteToFile("sobel.jpg");

            Console.WriteLine("See sobel.jpg");
        }
    }
}