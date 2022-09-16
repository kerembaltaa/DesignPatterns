using System;

namespace Proxy3
{
    class Program
    {
        static void Main(string[] args)
        {
            ImageGeneratorProxy proxy1 = new ImageGeneratorProxy("c:\\resim1.jpg");
            ImageGeneratorProxy proxy2 = new ImageGeneratorProxy("c:\\resim2.jpg");

            proxy1.ShowImage();
            proxy2.ShowImage();
            proxy1.ShowImage();

            Console.ReadKey();
        }
    }
    public interface IImageGenerator
    {
        void ShowImage();
    }
    public class ImageGenerator : IImageGenerator
    {
        private string _fullPath;

        public ImageGenerator(string fullPath)
        {
            _fullPath = fullPath;
        }
        public void ShowImage()
        {
            Console.WriteLine("{0} Resim Gösteriliyor..", _fullPath);
        }
    }
    public class ImageGeneratorProxy : IImageGenerator
    {
        private ImageGenerator _generator;
        private string _fullPath;

        public ImageGeneratorProxy(string fullPath)
        {
            _fullPath = fullPath;
        }

        public void ShowImage()
        {
            if (_generator == null)
                _generator = new ImageGenerator(_fullPath);

            _generator.ShowImage();
        }
    }
}
