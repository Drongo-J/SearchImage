using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchImage.Services
{
    public class Constants
    {
        public const string API_URL = "https://api.pexels.com/";
        public const string API_KEY = "563492ad6f917000010000018a22158dcfd14500b388238b3ce86808";
        public const string API_URL_VERSION = "v1/";
        public const int REQUEST_TIMEOUT_SECS = 30;
        public const string VERSION = "1.0.11";
        public static readonly string[] SIZES = { "small", "medium", "large" };
        public static readonly string[] ORIENTATIONS = { "landscape", "portrait", "square" };
        public static readonly string[] COLORS = { "red", "orange", "yellow", "green", "turquoise", "blue", "violet", "pink", "brown", "black", "gray", "white" };
    }
}
