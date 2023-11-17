namespace MyReference.ViewModel;

[QueryProperty(nameof(MonTxt), "Databc")]
public partial class AboutViewModel : BaseViewModel
{
    [ObservableProperty]
    string monTxt;
    public AboutViewModel()
    {

    }
}