using projectFr.Constant;
using projectFr.Helper;

namespace projectFr.Screnns;

public partial class SettingsPage : ContentPage
{
    #region Variables
    string togle = Preferences.Default.Get(AppConst.IsBio, "True");
    string Push = Preferences.Default.Get(AppConst.Push, "false");
    string PIN = Preferences.Default.Get(AppConst.PIN, "1234");
    string Lic = Preferences.Default.Get(AppConst.Lic, "");
    #endregion

    #region Cos
    public SettingsPage()
    {
        InitializeComponent();
        bio.IsToggled = Convert.ToBoolean(togle);
        PINE.Text = PIN;
        LicEN.Text = Lic;
        PushS.IsToggled = Convert.ToBoolean(Push);
    }
    #endregion

    #region Methodes
    private void bio_Toggled(object sender, ToggledEventArgs e)
    {
        Preferences.Default.Set(AppConst.IsBio, e.Value.ToString());
    }

    private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Length == 4)
        {
            Preferences.Default.Set(AppConst.PIN, e.NewTextValue);
        }
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        PushId();
        await Shell.Current.DisplayAlert("Info", "setting Saved", "Ok");
    }

    private void Push_Toggled(object sender, ToggledEventArgs e)
    {
        Preferences.Default.Set(AppConst.Push, e.Value.ToString());
    }

    async void PushId()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post,
            "https://dinewme.com/App/SetGooglePush?userTokenId=7Uxcrm4RMwkfo%2fMhyyx4db%2bERUCNlhyLt%2bkg4MA3%2bbARWJLOiB8JGv74FaNBQIGn&googlePushId=69fGfkki%2fAdYh7BUk3QJI1j%2fbzIDDE8LWnEv3ZZIVYkTy52afk43KGxgn4WlPYayU%2bTv%2f0yghzWgtQ%2fXjtUrMce7SbMuUke0IQY%2bsNTH%2fA2tNCE%2fKQANBIyTORl8wMZQOjlUPsDwZwYIVFsgyIqJj1Kqs0ogi9MZjyQauC5qsneTTWZA107sxAuIhdzbUkQ3CBcxd90KJSzvnntnedWTgOOcFCSrLHyeC%2fA2pBTF7CE%3d&idMobile=U9SmfIpzrxjWWoTYsXeLpA%3d%3d&nameMobile=0MpPcX5zSC8IvFbBECUWUQ%3d%3d");

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

    }

    private void LicEN_Completed(object sender, TextChangedEventArgs e)
    {
        if (Lic != e.NewTextValue)
        {
            Preferences.Default.Set(AppConst.Lic, EnDE.Encrypt(LicEN.Text));
        }
        
    }
    #endregion
}