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

    
    public BoardsView()
	{
		InitializeComponent();
        

        foreach (Board board in boardsList)
        {
            Button boardName_btn = new Button();
            boardName_btn.Text = board.Name;
            boardsStack.Add(boardName_btn);


            Label lbID = new Label();
            lbID.Text = "ID: "+board.Id.ToString();
            boardsStack.Add(lbID);

        }

        foreach (var board in boardsList)
        {
            
            foreach (var note in board.notes)
            {
                NoteCard noteCard = new NoteCard();
                noteCard.CardTitle = note.Title;
                noteCard.CardDescription = note.Description;
                notesStack.Add(noteCard);
            }
        }


    }

    public void boardLable_clk(object sender, EventArgs e)
    {
        
    }
}