using CommunityToolkit.Maui.Views;
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
    private int currentBoard = 1;
    
    public BoardsView()
	{
		InitializeComponent();

        initBoardMenu();

        initNotes();


    }

    private void BoardName_btn_Clicked(object sender, EventArgs e)
    {
        BoardButton clickedBtn = sender as BoardButton;
        DisplayAlert("Board Btn", clickedBtn.BoardID.ToString() + "\n" + clickedBtn.BoardTitle, "Ok");
        currentBoard = clickedBtn.BoardID;
        initNotes();
    }



    void initNotes()
    {
        if(notesStack.Count > 0)
        {
            notesStack.Clear();
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



    void initBoardMenu()
    {
        if(boardsStack.Count > 0)
        {
            boardsStack.Clear();
        }
        foreach (Board board in App.TakeNoteRepo.GetBoards())
        {
            BoardButton boardButton = new BoardButton();
            TapGestureRecognizer boardTapGestureRecognizer = new TapGestureRecognizer();
            boardButton.BoardTitle = board.Name;
            boardButton.BoardID = board.boardID;
            boardTapGestureRecognizer.Tapped += BoardName_btn_Clicked;
            boardButton.GestureRecognizers.Add(boardTapGestureRecognizer);
            boardsStack.Add(boardButton);
        }
    }

    void createBoard_PopUp(Object board, EventArgs e)
    {
        createBoardPopUp boardPopUp = new createBoardPopUp();
        this.ShowPopup(boardPopUp);


    }
}