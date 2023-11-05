using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JPsShopz.Data
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _connection;

        public Database(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<User>().Wait();
        }

        public Task<User> GetUserByUsernameAsync(string username)
        {
            return _connection.Table<User>().Where(user => user.Username == username).FirstOrDefaultAsync();

        }

        public Task<int> AddUserAsync(User user)
        {
            return _connection.InsertAsync(user);
        }


    }
}
