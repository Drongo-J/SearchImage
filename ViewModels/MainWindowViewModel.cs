using PexelsDotNetSDK.Api;
using SearchImage.Commands;
using SearchImage.Helpers;
using SearchImage.Services;
using SearchImage.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SearchImage.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public RelayCommand MouseEnterCommand { get; set; }
        public RelayCommand MouseLeaveCommand { get; set; }
        public RelayCommand IsFocusedCommand { get; set; }
        public RelayCommand IsNotFocusedCommand { get; set; }
        public RelayCommand ClearCommand { get; set; }
        public RelayCommand KeyDownCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }

        private string DefaultText = "Search For Image . . .";

        public TextBox SearchTb { get; set; }

        private ObservableCollection<UIElement> images = new ObservableCollection<UIElement>();

        public ObservableCollection<UIElement> Images
        {
            get { return images; }
            set { images = value; OnPropertyChanged(); }
        }

        public MainWindowViewModel()
        {
            KeyDownCommand = new RelayCommand((key) =>
            {
                var _key = key as string;
                if (_key[key.ToString().Length - 1] == '\r')
                {
                    SearchCommand.Execute(null);
                }
            });

            MouseEnterCommand = new RelayCommand((m) =>
            {
                if (SearchTb.Text.Trim() == DefaultText)
                {
                    SearchTb.Text = String.Empty;
                }
            });

            MouseLeaveCommand = new RelayCommand((m) =>
            {
                if (SearchTb.Text.Trim() == String.Empty && SearchTb.IsFocused == false)
                {
                    SearchTb.Text = DefaultText;
                }
            });

            IsFocusedCommand = new RelayCommand((i) =>
            {
                SearchTb.Foreground = Brushes.Black;
            });

            IsNotFocusedCommand = new RelayCommand((i) =>
            {
                string text = SearchTb.Text.Trim();
                if (text == String.Empty || text == DefaultText)
                {
                    SearchTb.Foreground = Brushes.Gray;
                    SearchTb.Text = DefaultText;
                }
            });

            SearchCommand = new RelayCommand(async (s) =>
            {
                string text = SearchTb.Text.Trim();

                var pexelsClient = new PexelsDotNetSDK.Api.PexelsClient(Constants.API_KEY);

                var result = await pexelsClient.SearchPhotosAsync(text);

                Images.Clear();
                //result.photos.RemoveRange(1, result.photos.Count - 1);
                foreach (var photo in result.photos)
                {
                    var imageUC = new ImageUC();
                    //imageUC.Height = photo.height;
                    //imageUC.Width = photo.width;
                    imageUC.Height = 250;
                    imageUC.Width = 400;

                    // Method 1
                    //BitmapImage logo = new BitmapImage();
                    //logo.BeginInit();
                    //logo.UriSource = new Uri(photo.source.original, UriKind.RelativeOrAbsolute);
                    //logo.EndInit();
                    //imageUC.Image.Source = logo;

                    //Method 2
                    imageUC.Image.Source = new BitmapImage(new Uri(photo.source.original));

                    Images.Add(imageUC);
                }

                if (Images.Count == 0)
                {
                    Images.Add(new NoResultUC());
                }
            });

            ClearCommand = new RelayCommand((c) =>
            {
                string text = SearchTb.Text.Trim();
                if (text != DefaultText && text != string.Empty)
                {
                    SearchTb.Text = string.Empty;
                }
            });
        }
    }
}
