using TakeNote.Views;

namespace TakeNote;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("BoardsView", typeof(BoardsView));
        Routing.RegisterRoute("RegisterPage", typeof(RegisterPage));
    }
}
