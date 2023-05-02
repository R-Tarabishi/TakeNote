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

        public void InitConn()
        {
            _connection = new SQLiteConnection(_dbPath);
            _connection.CreateTable<Board> ();
            _connection.CreateTable<Note> ();

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

        public void removeBoard(Board board)
        {
            _connection = new SQLiteConnection(_dbPath);
            _connection.Delete(board);
        }



        //Note Operations
        public List<Note> GetNotes(int boardID)
        {
            _connection = new SQLiteConnection(_dbPath);
            List<Note> notes = new List<Note> ();

            foreach (var item in _connection.Table<Board>().ToList())
            {
                foreach (var note in notes)
                {
                    notes.Add (note);
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







        public void dropTable(string tableName)
        {
            _connection = new SQLiteConnection(_dbPath);
            SQLiteCommand sqlite_cmd = _connection.CreateCommand(tableName);
            sqlite_cmd.ExecuteNonQuery();
        }
    }
}
