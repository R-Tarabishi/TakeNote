using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using TakeNote.Components;
using TakeNote.Models;
// using Windows.ApplicationModel.Appointments;

namespace TakeNote.Views;

public partial class BoardsView : ContentPage
{

    public List<Board> boardsList = App.TakeNoteRepo.GetBoards();

    private int currentBoard = 2;
    
    public BoardsView()
	{
		InitializeComponent();

        foreach (Board board in boardsList)
        {
            Button boardName_btn = new Button();
            boardName_btn.Text = board.Name;
            boardsStack.Add(boardName_btn);
            boardName_btn.Clicked += BoardName_btn_Clicked;


            //Give button Custom property for board id

        }





        foreach (var note in App.TakeNoteRepo.GetNotes(currentBoard))
        {
            if (note != null)
            {
                NoteCard noteCard = new NoteCard();
                noteCard.CardTitle = note.Title;
                noteCard.CardDescription = note.Description;
                notesStack.Add(noteCard);
            }
            else
            {
                 DisplayAlert("Alert", "no Notes", "Ok");
                return;
            }

        }


    }

    private void BoardName_btn_Clicked(object sender, EventArgs e)
    {
        //based on button's board's id, a board will be selected,
        int board_id;

    }

    public void boardLable_clk(object sender, EventArgs e)
    {
        
    }
}