using ConvertToIcon;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2Ico {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private string fileName;
        private List<BitmapFrame> frameList;

        public MainWindow() {
            InitializeComponent();
        }

        private BitmapFrame LoadImage(Uri imageUri, Size desiredSize) {
            var decoder = BitmapDecoder.Create(imageUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
            var dpiFactor = 1f;

            var frames = decoder.Frames.OrderBy(f => f.Width).ThenBy(f => f.Height).ToList();
            return frames.FirstOrDefault(f => f.Width >= desiredSize.Width * dpiFactor && f.Height >= desiredSize.Height * dpiFactor);
        }

        private BitmapFrame LoadImage(Uri imageUri) {
            var decoder = BitmapDecoder.Create(imageUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
            var frames = decoder.Frames.OrderBy(f => f.Width).ThenBy(f => f.Height).ToList();
            return frames.FirstOrDefault();
        }

        private BitmapFrame FastResize(BitmapFrame bitmap, int width, int height) {
            var target = new TransformedBitmap(bitmap,
                new ScaleTransform(
                    width / bitmap.Width * 96 / bitmap.DpiX,
                    height / bitmap.Height * 96 / bitmap.DpiY,
                    0, 0));
            return BitmapFrame.Create(target);
        }

        private void upload_image_btn_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            frameList = new List<BitmapFrame>();
            dialog.Filter = "Archivos de Imagen|*.png";
            if (dialog.ShowDialog() == true) {
                //var origen = new FileStream(dialog.FileName, FileMode.Open);
                //var destino = new FileStream(System.IO.Path.GetFileNameWithoutExtension(dialog.FileName) + ".ico", FileMode.OpenOrCreate);
                fileName = dialog.FileName;
                var imageUri = new Uri(dialog.FileName, UriKind.Absolute);
                BitmapImage bmp = new BitmapImage(imageUri);
                int size = Math.Max(bmp.PixelWidth, bmp.PixelHeight);

                image_upload.Source = null;
                int width = 0;
                int height = 0;
                int thumb_size = 256;
                if (size >= 256)
                    try {
                        if (bmp.PixelWidth == size) {
                            width = thumb_size;
                            height = (int)(thumb_size * ((double)bmp.Height / (double)bmp.Width));
                        } else if (bmp.PixelHeight == size) {
                            height = thumb_size;
                            width = (int)(thumb_size * ((double)bmp.Width / (double)bmp.Height));
                        }
                        BitmapFrame frame = FastResize(LoadImage(imageUri), width, height);
                        frameList.Add(frame);
                    } catch { }
                if (size >= 128) {
                    try {
                        thumb_size = 128;
                        if (bmp.PixelWidth == size) {
                            width = thumb_size;
                            height = (int)(thumb_size * ((double)bmp.Height / (double)bmp.Width));
                        } else if (bmp.PixelHeight == size) {
                            height = thumb_size;
                            width = (int)(thumb_size * ((double)bmp.Width / (double)bmp.Height));
                        }
                        BitmapFrame frame = FastResize(LoadImage(imageUri), width, height);
                        frameList.Add(frame);
                    } catch { }
                }
                if (size >= 96) {
                    try {
                        thumb_size = 96;
                        if (bmp.PixelWidth == size) {
                            width = thumb_size;
                            height = (int)(thumb_size * ((double)bmp.Height / (double)bmp.Width));
                        } else if (bmp.PixelHeight == size) {
                            height = thumb_size;
                            width = (int)(thumb_size * ((double)bmp.Width / (double)bmp.Height));
                        }
                        BitmapFrame frame = FastResize(LoadImage(imageUri), width, height);

                        frameList.Add(frame);
                    } catch { }
                }
                if (size >= 64) {
                    try {
                        thumb_size = 64;
                        if (bmp.PixelWidth == size) {
                            width = thumb_size;
                            height = (int)(thumb_size * ((double)bmp.Height / (double)bmp.Width));
                        } else if (bmp.PixelHeight == size) {
                            height = thumb_size;
                            width = (int)(thumb_size * ((double)bmp.Width / (double)bmp.Height));
                        }
                        BitmapFrame frame = FastResize(LoadImage(imageUri), width, height);
                        frameList.Add(frame);
                    } catch { }
                }
                if (size >= 48) {
                    try {
                        thumb_size = 48;
                        if (bmp.PixelWidth == size) {
                            width = thumb_size;
                            height = (int)(thumb_size * ((double)bmp.Height / (double)bmp.Width));
                        } else if (bmp.PixelHeight == size) {
                            height = thumb_size;
                            width = (int)(thumb_size * ((double)bmp.Width / (double)bmp.Height));
                        }
                        BitmapFrame frame = FastResize(LoadImage(imageUri), width, height);
                        frameList.Add(frame);
                    } catch { }
                }
                if (size >= 32) {
                    try {
                        thumb_size = 32;
                        if (bmp.PixelWidth == size) {
                            width = thumb_size;
                            height = (int)(thumb_size * ((double)bmp.Height / (double)bmp.Width));
                        } else if (bmp.PixelHeight == size) {
                            height = thumb_size;
                            width = (int)(thumb_size * ((double)bmp.Width / (double)bmp.Height));
                        }
                        BitmapFrame frame = FastResize(LoadImage(imageUri), width, height);
                        frameList.Add(frame);
                    } catch { }
                }
                if (size >= 16) {
                    try {
                        thumb_size = 16;
                        if (bmp.PixelWidth == size) {
                            width = thumb_size;
                            height = (int)(thumb_size * ((double)bmp.Height / (double)bmp.Width));
                        } else if (bmp.PixelHeight == size) {
                            height = thumb_size;
                            width = (int)(thumb_size * ((double)bmp.Width / (double)bmp.Height));
                        }
                        BitmapFrame frame = FastResize(LoadImage(imageUri), width, height);
                        frameList.Add(frame);
                    } catch { }
                }

                framesLV.ItemsSource = frameList;
                if (image_upload.Source == null) {
                    image_upload.Width = frameList[0].PixelWidth;
                    image_upload.Height = frameList[0].PixelHeight;
                    image_upload.Stretch = Stretch.UniformToFill;
                    image_upload.Source = frameList[0];
                }
            }
        }

        private void download_image_btn_Click(object sender, RoutedEventArgs e) {
            using (FileStream fs = new FileStream($"{System.IO.Path.GetFileNameWithoutExtension(fileName)}.ico", FileMode.OpenOrCreate)) {
                IconWriter.Write(fs, frameList);
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            var image = (sender as FrameworkElement).DataContext as ImageSource;
            image_upload.Source = image;
        }
    }
}
