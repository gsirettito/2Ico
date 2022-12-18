using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _2Ico {
    public class ImageInfoConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var image = value as ImageSource;
            switch (parameter.ToString()) {
                case "Dimensions": return $"{((BitmapFrame)image).PixelWidth}x{((BitmapFrame)image).PixelHeight}"; break;
                case "FileName": return $"{((BitmapFrame)image).BaseUri}"; break;
                case "DPi": return $"{((BitmapFrame)image).DpiX}x{((BitmapFrame)image).DpiY}"; break;
            }
            return Binding.DoNothing;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }
    }
}
