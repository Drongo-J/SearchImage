using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SearchImage.Helpers
{
    public class ImageAsyncHelper : DependencyObject
    {
        public static Uri GetSourceUri(DependencyObject obj)
        {
            return (Uri)obj.GetValue(SourceUriProperty);
        }

        public static void SetSourceUri(DependencyObject obj, Uri value)
        {
            obj.SetValue(SourceUriProperty, value);
        }

        public static readonly DependencyProperty SourceUriProperty =
            DependencyProperty.RegisterAttached("SourceUri",
                typeof(Uri),
                typeof(ImageAsyncHelper),
                new PropertyMetadata
                {
                    PropertyChangedCallback = (obj, e) =>
                    ((Image)obj).SetBinding(
                        Image.SourceProperty,
                        new Binding("VerifiedUri")
                        {
                            Source = new ImageAsyncHelper
                            {
                                _givenUri = (Uri)e.NewValue
                            },
                            IsAsync = true
                        }
                    )
                }
            );

        private Uri _givenUri;
        public Uri VerifiedUri
        {
            get
            {
                try
                {
                    System.Net.Dns.GetHostEntry(_givenUri.DnsSafeHost);
                    return _givenUri;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }

    //public class ImageAsyncHelpers
    //{
    //    public static ImageSource StringToImageSource(string source)
    //    {
    //        try
    //        {
    //            if (!source.Contains("https://"))
    //                source = "https://" + source;

    //            var imgUrl = new Uri(source);
    //            var imageData = new WebClient().DownloadData(imgUrl);
    //            return ByteImageConverter.ByteToImage(imageData);
    //        }
    //        catch (Exception)
    //        {
    //            return null;
    //        }

    //    }
    //}

    //public class ByteImageConverter
    //{
    //    public static ImageSource ByteToImage(byte[] imageData)
    //    {
    //        BitmapImage biImg = new BitmapImage();
    //        MemoryStream ms = new MemoryStream(imageData);
    //        biImg.BeginInit();
    //        biImg.StreamSource = ms;
    //        biImg.EndInit();

    //        ImageSource imgSrc = biImg as ImageSource;

    //        return imgSrc;
    //    }
    //}
}
