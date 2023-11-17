namespace MyReference.ViewModel;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    string monTexte = "Jurs";
    public ObservableCollection<Monkey> MyShownList { get; } = new();


    [ObservableProperty]
    public string monCode="MonCodeOslm"; //G�n�re un get set (commencer avec une minuscule)

    public MainViewModel()
	{

	}

    [RelayCommand]
    public async Task GoToDetailPage(string data)
    {
        await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
        {
            {"Databc", data }
        });
    }

    [RelayCommand]
    public async Task GoToAboutPage(string data)
    {
        await Shell.Current.GoToAsync(nameof(AboutPage), true, new Dictionary<string, object>
        {
            {"Databc", data }
        });
    }

    [RelayCommand]
    async Task MonkeysFromJSON()
    {
        if (IsBusy) return;

        MonkeyService MyService = new MonkeyService();

        try
        {
            IsBusy = true;
            Globals.MyStaticList = await MyService.GetMonkeys();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Students: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally { IsBusy = false; }

        MyShownList.Clear();

        foreach (Monkey stu in Globals.MyStaticList)
        {
            MyShownList.Add(stu);
        }
    }
}