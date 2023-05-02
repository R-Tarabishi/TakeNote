using TakeNote.Models;

namespace TakeNote.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		
		//Drop table, and start fresh on launch
		App.TakeNoteRepo.dropTable(" DROP Table 'boards'");
        App.TakeNoteRepo.InitConn();
        initBoards();
        List<Board> boardsList = App.TakeNoteRepo.GetBoards();
        initNotes(boardsList);
    }


	//basic create boards
	public void initBoards()
	{
		for (int i = 0; i < 5; i++)
		{
            App.TakeNoteRepo.addBoard(new Board
            {
                Name = "board "+i
            });
        }
	}

	public void initNotes(List<Board> boardsList)
	{
        foreach (var item in boardsList)
        {
			item.notes.Add(new Note
			{
				Title = "This is Note in: "+item.Name,
				Description= "This is note in: "+item.Name,
				boardID = item.Id
			});
        }
    }
}