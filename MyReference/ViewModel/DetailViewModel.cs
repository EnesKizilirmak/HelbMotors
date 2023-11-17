using System.ComponentModel;

namespace MyReference.ViewModel;

[QueryProperty(nameof(MonTxt), "Databc")]

public partial class DetailViewModel : BaseViewModel
{
    [ObservableProperty]
    String lapin;

    private string _matchMessage;
    private string _imageUrl;


    private string _image;
    public string Image
    {
        get { return _image; }
        set
        {
            if (_image != value)
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
    }

    // Autres propriétés et méthodes

    // Implémentation de l'interface INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public string MatchMessage
    {
        get { return _matchMessage; }
        set { SetProperty(ref _matchMessage, value); }
    }

    public string ImageUrl
    {
        get { return _imageUrl; }
        set
        {
            if (_imageUrl != value)
            {
                _imageUrl = value;
                OnPropertyChanged(nameof(ImageUrl));
            }
        }
    }

    private Monkey _matchingMonkey;
    public Monkey MatchingMonkey
    {
        get { return _matchingMonkey; }
        set { SetProperty(ref _matchingMonkey, value); }
    }

    [ObservableProperty]
    string monTxt;

    DeviceOrientationServices MyDeviceOrientationServices;

    public DetailViewModel()
    {
        this.MyDeviceOrientationServices = new DeviceOrientationServices();
        MyDeviceOrientationServices.ConfigureScanner();

        MyDeviceOrientationServices.SerialBuffer.Changed += SerialBuffer_Changed;
    }

    private void SerialBuffer_Changed(object sender, EventArgs e)
    {
        DeviceOrientationServices.QueueBuffer myQueue = (DeviceOrientationServices.QueueBuffer)sender;

        MonTxt = myQueue.Dequeue().ToString();

        foreach (Monkey m in Globals.MyStaticList)
        {
            if (MonTxt == m.Id.ToString())
            {
                Lapin = m.Image;
                MatchMessage =
                    " Id : " + MonTxt +
                    "\n Brand : " + m.Marque +
                    "\n Modele : " + m.Title +
                    "\n Prdouction date : " + m.StartProduction +
                    "\n Color : " + m.Color;
                ;
                MatchingMonkey = m;
            }
        }
    }
}