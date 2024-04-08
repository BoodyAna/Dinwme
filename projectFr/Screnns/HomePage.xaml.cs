namespace projectFr.Screnns;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    protected override bool OnBackButtonPressed()
    {
        
        Application.Current.Quit();
        return true;
    }

    
}