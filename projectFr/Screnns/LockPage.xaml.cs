using projectFr.Constant;

namespace projectFr.Screnns;

public partial class LockPage : ContentPage
{
    string PIN = Preferences.Default.Get(AppConst.PIN, "1234");
    public LockPage()
	{
		InitializeComponent();
	}

    private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(e.NewTextValue == PIN)
        {
            await Shell.Current.GoToAsync("/Dashbord");
        } else if (e.NewTextValue.Length == 4 & e.NewTextValue != PIN)
        {
            await Shell.Current.DisplayAlert("Info", "Incorrect PIN", "OK");
        }
    }
}