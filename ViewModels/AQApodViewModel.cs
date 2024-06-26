using AnahiQuezadaAPINasa.Models;
using AnahiQuezadaAPINasa.Services;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AnahiQuezadaAPINasa.ViewModels
{
    public class AQApodViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AQApodViewModel()
        {
            ChosenDate = DateTime.Now;
        }

        private DateTime dateTime;
        public DateTime ChosenDate
        {
            get { return dateTime; }
            set
            {
                if (value != dateTime)
                {
                    dateTime = value;
                    NotifyPropertyChanged();
                    _ = GetPictureOfTheDay(dateTime);
                }
            }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (value != title)
                {
                    title = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private Uri imageUri;
        public Uri ImageURI
        {
            get { return imageUri; }
            set
            {
                if (imageUri != value)
                {
                    imageUri = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string didactic;
        public string Didactic
        {
            get { return didactic; }
            set
            {
                if (didactic != value)
                {
                    didactic = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private AQApodService service;
        public AQApodService Service
        {
            get
            {
                if (service == null)
                {
                    service = new AQApodService();
                }
                return service;
            }
        }

        private async Task GetPictureOfTheDay(DateTime day)
        {
            AQApod dto = await Service.GetImage(day);
            if (dto == null)
            {
                ImageURI = new Uri("https://image.freepik.com/vector-gratis/error-404-no-encontrado-efecto-falla_8024-5.jpg");
                Didactic = "";
                Title = "Intenta con otra fecha";
            }
            else
            {
                ImageURI = new Uri(dto.hdurl);
                Didactic = dto.explanation;
                Title = dto.title;
            }
        }
    }
}
