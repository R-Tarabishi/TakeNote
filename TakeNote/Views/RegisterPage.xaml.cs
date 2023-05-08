using TakeNote.Models;
namespace TakeNote.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
       

    }

    private void register_btn(object sender, EventArgs e)
    {
        //Validate Method
        if (!validateInput())
            return;

		//Create user Object
		User newUser = new User
		{
			name = nUsername.Text,
			password = nPassword.Text,
			email = email.Text,
		};
		App.TakeNoteRepo.addUser(newUser);
		Shell.Current.GoToAsync("//LogInView");
		
    }

    bool validateInput()
    {
        if (string.IsNullOrEmpty(nUsername.Text)
            || string.IsNullOrEmpty(nPassword.Text)
            || string.IsNullOrEmpty(email.Text)
            || string.IsNullOrWhiteSpace(nUsername.Text)
            || string.IsNullOrWhiteSpace(nPassword.Text)
            || string.IsNullOrWhiteSpace(email.Text)
            || nUsername.Text.Contains(" ")
            || nPassword.Text.Contains(" ")
            || email.Text.Contains(" "))
        {
            DisplayAlert("Error", "Fields Cant be empty or contain white space", "Ok");
            return false;
        }

        if(!eula_chkbx.IsChecked)
        {
            DisplayAlert("Error", "Must Accept EULA To register", "Ok");
            return false;
        }
        return true;
    }

    void ClearFields(Object sender, EventArgs e)
    {
        nUsername.Text = string.Empty;
        nPassword.Text = string.Empty;
        email.Text = string.Empty;
        eula_chkbx.IsChecked = false;
    }
}