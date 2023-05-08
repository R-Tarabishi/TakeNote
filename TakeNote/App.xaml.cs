using TakeNote.Data;

namespace TakeNote;

public partial class App : Application
{
	public static Repository TakeNoteRepo { get; set; }


	public App(Repository repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		TakeNoteRepo = repo;



	}
}
