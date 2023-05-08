
using TakeNote.Models;
using TakeNote;

namespace TakeNote.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();

        //Drop table, and start fresh on launch , Remove Later, add check if table Exists
        if (App.TakeNoteRepo.dropTable(" DROP Table 'boards'") == 0)
        {
            DisplayAlert("Alert", "DB boards does not exist", "Continue");
        }
        if (App.TakeNoteRepo.dropTable(" DROP Table 'Notes'") == 0)
        {
            DisplayAlert("Alert", "DB Notes does not exist", "Continue");
        }

        App.TakeNoteRepo.InitConn();
        initBoards();
        List<Board> boardsList = App.TakeNoteRepo.GetBoards();
        initnotes(boardsList);
        addTestUser();
    }


    //genereate 5 boards, for now
    public void initBoards()
    {
        for (int i = 1; i < 6; i++)
        {
            App.TakeNoteRepo.addBoard(new Board
            {
                Name = "board " + i

            });
        }
    }

    //procedurly generate nodes, for now
    public async void initnotes(List<Board> boardslist)
    {
        List<Board> updatedBoards = new List<Board>();

        foreach (Board board in boardslist)
        {
            if (board.notes != null)
            {
                Note note = new Note
                {
                    Title = "this is note in: " + board.Name,
                    Description = "this is note in: " + board.Name,
                    boardID = board.boardID,
                };

                board.notes.Add(note);
                App.TakeNoteRepo.addNote(note);
                updatedBoards.Add(board);

                //second note per board
                Note note1 = new Note
                {
                    Title = "this is note in: " + board.Name,
                    Description = "this is note in: " + board.Name,
                    boardID = board.boardID,
                };

                board.notes.Add(note1);
                App.TakeNoteRepo.addNote(note1);
                updatedBoards.Add(board);
            }
            else
            {
                await DisplayAlert("Alert", " No notes found", "ok");
                return;
            }
        }
        App.TakeNoteRepo.updateBoards(updatedBoards);
    }

    public async  void logIn_btn(object sender, EventArgs e)
    {

        List<User> users = App.TakeNoteRepo.GetUsers();
        foreach (User user in users)
        {
            if (user.name == username.Text && user.password == password.Text && user != null)
            {
                await Shell.Current.GoToAsync("//BoardsView");
            }
            else
            {
               await  DisplayAlert("Error", "Wrong Username and password", "Ok");
                return;
            }
        }

    }
    public void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {

    }
    void OnEntryCompleted(object sender, EventArgs e)
    {

    }


    void addTestUser()
    {
        User user = new User();
        user.name = "root";
        user.password = "admin";

        App.TakeNoteRepo.addUser(user);

    }

}