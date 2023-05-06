using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeNote.Models;

namespace TakeNote.Data
{
    public class Repository
    {
        string _dbPath;
        private SQLiteConnection _connection;

        public Repository(string dbPath)
        {
            _dbPath = dbPath;
        }

        // Return sqlLite CreateTableResult Created = 0, Migrated = 1
        public CreateTableResult InitConn()
        {
            _connection = new SQLiteConnection(_dbPath);
            
            if (!_connection.CreateTable<Board>().HasFlag(CreateTableResult.Created))
            {
                return CreateTableResult.Migrated;
            }
            if (!_connection.CreateTable<Note>().HasFlag(CreateTableResult.Created))
            {
                return CreateTableResult.Migrated;
            }

            return CreateTableResult.Created;
        }

        //Board Operations
        public List<Board> GetBoards()
        {
            _connection = new SQLiteConnection(_dbPath);
            return _connection.Table<Board>().ToList();
        }

        public void addBoard(Board board)
        {
            _connection = new SQLiteConnection(_dbPath);
            _connection.Insert(board);
        }
        public void updateBoard(Board board)
        {
            _connection = new SQLiteConnection(_dbPath);
            _connection.Update(board);
        }

        public void removeBoard(Board board)
        {
            _connection = new SQLiteConnection(_dbPath);
            _connection.Delete(board);
        }


        public void updateBoards(List<Board> boards)
        {
            _connection = new SQLiteConnection(_dbPath);
            _connection.UpdateAll(boards);
           
        }



        //Note Operations
        public List<Note> GetNotes(int boardID)
        {
            _connection = new SQLiteConnection(_dbPath);
            List<Note> notes = new List<Note> ();

            foreach (var note in _connection.Table<Note>().ToList())
            {
                if (note.boardID == boardID)
                {
                    notes.Add(note);
                }
                
            }
            return notes;
        }
        public void addNote(Note note)
        {
            _connection = new SQLiteConnection(_dbPath);
            _connection.Insert(note);
        }

        public void removeNote(Note note)
        {
            _connection = new SQLiteConnection(_dbPath);
            _connection.Delete(note);
        }







        public int dropTable(string tableName)
        {
            _connection = new SQLiteConnection(_dbPath);
            SQLiteCommand sqlite_cmd = _connection.CreateCommand(tableName);
            try
            {
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (SQLiteException)
            {

                return 0;
            }

            return 1;
        }
    }
}
