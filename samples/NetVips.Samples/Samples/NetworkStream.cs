namespace NetVips.Samples
{
    using System;
    using System.IO;
    using System.Net;

    public class NetworkStream : ISample
    {
        public string Name => "Network stream";
        public string Category => "Streaming";

        //public const string Uri = "https://github.com/weserv/images/raw/5.x/test/api/fixtures/alpha-layer-2-ink.jpg"; // JPG
        public const string Uri = "https://github.com/weserv/images/raw/5.x/test/api/fixtures/alpha-layer-1-fill.png"; // PNG
        //public const string Uri = "https://github.com/weserv/images/raw/5.x/test/api/fixtures/dancing_banana2.lossless.webp"; // WebP
        //public const string Uri = "https://github.com/weserv/images/raw/5.x/test/api/fixtures/dancing-banana.gif"; // GIF
        //public const string Uri = "https://github.com/weserv/images/raw/5.x/test/api/fixtures/tv-test-pattern-146649.svg"; // SVG
        //public const string Uri = "https://github.com/weserv/images/raw/5.x/test/api/fixtures/winter_1440x960.heic"; // HEIC
        //public const string Uri = "https://github.com/weserv/images/raw/5.x/test/api/fixtures/84y2.hdr"; // HDR

        // -1 to test https://github.com/kleisauke/net-vips/issues/101
        public const int BufferSize = 4096 - 1;

        public string Execute(string[] args)
        {
            using var web = new WebClient();
            using var stream = web.OpenRead(Uri);

            var source = new SourceCustom();
            source.OnRead += (buffer, length) =>
            {
                Console.WriteLine($"-> {length} bytes");
                var bytesRead = stream.Read(buffer, 0, length > BufferSize ? BufferSize : length);
                Console.WriteLine($"<- {bytesRead} bytes");
                return bytesRead;
            };

            // var image = Image.NewFromStream(stream, access: Enums.Access.Sequential);
            var image = Image.NewFromSource(source, access: Enums.Access.Sequential);
            Console.WriteLine(image.ToString());

            using var output = File.OpenWrite("stream-network.jpg");
            image.WriteToStream(output, ".jpg");

            return "See stream-network.jpg";
        }
    }
}