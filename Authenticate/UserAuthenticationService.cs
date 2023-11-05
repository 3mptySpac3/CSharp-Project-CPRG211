using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPsShopz.Data;

namespace JPsShopz.Authenticate
{
    public class UserAuthenticationService
    {
        private bool _isAuthenticated;

        public event Action OnAuthenticationStateChanged;

        private void NotifyAuthenticationStateChanged() => OnAuthenticationStateChanged?.Invoke();

        public bool IsAuthenticated { 
            get => _isAuthenticated;
            private set
            {
                if (_isAuthenticated != value)
                {
                    _isAuthenticated = value;
                    NotifyAuthenticationStateChanged();
                }

            } 

            }

        private readonly Database _database;

        public UserAuthenticationService(Database database)
        {
            _database = database;
        }

        public async Task LogoutAsync()
        {
            // Perform logout logic, like clearing tokens or any other sign-out cleanup
            IsAuthenticated = false;

            // Notify the AuthenticationStateProvider to refresh the state
            // If you have a custom AuthenticationStateProvider, you would call a method here to update its state.
        }

        private async Task<User> GetUserAsync(string userName)
        {
            return await _database.GetUserByUsernameAsync(userName);
        }

        public async Task<bool> AuthenticateUserAsync(string userName, string password)
        {
            var userData = await GetUserAsync(userName);

            if (userData != null)
            {
                Console.WriteLine($"User from database: {userData.Username}, Password: {userData.Password}");
                Console.WriteLine($"Provided username: {userName}, password: {password}");

                if (userData.Password == password)
                {
                    IsAuthenticated = true;
                    return true;
                }
            }
            else
            {
                Console.WriteLine($"No user found with username: {userName}");
            }

            IsAuthenticated = false;
            return false;
        }
    }
}
