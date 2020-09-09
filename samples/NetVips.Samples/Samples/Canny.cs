namespace NetVips.Samples
{
    using System;

    public class Canny : ISample
    {
        public string Name => "Canny";
        public string Category => "Edge detection";

        public const string Filename = "images/lichtenstein.jpg";

        public void Execute(string[] args)
        {
            var im = Image.NewFromFile(Filename, access: Enums.Access.Sequential);

            // Optionally, convert to greyscale
            // im = im.Colourspace("b-w");

            // Canny edge detector
            im = im.Canny(1.4, precision: Enums.Precision.Integer);

            // Canny makes a float image, scale the output up to make it visible.
            im *= 64;

            im.WriteToFile("canny.jpg");

            Console.WriteLine("See canny.jpg");
        }
    }
}