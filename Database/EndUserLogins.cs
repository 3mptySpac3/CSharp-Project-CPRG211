using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPsShopz.Data;

namespace JPsShopz.Data
{
    public static class EndUserLogins
    {
        public static async Task InitializeUsersAsync(Database database)
        {
            var user1 = await database.GetUserByUsernameAsync("user1");
            var user2 = await database.GetUserByUsernameAsync("user2");
            var user3 = await database.GetUserByUsernameAsync("John");

            if (user1 == null)
            {
                user1 = new User { Username = "user1", Password = "password1" };
                await database.AddUserAsync(user1);
            }

            if (user2 == null)
            {
                user2 = new User { Username = "user2", Password = "password2" };
                await database.AddUserAsync(user2);
            }

            if (user3 == null)
            {
                user3 = new User { Username = "John", Password = "John" };
                await database.AddUserAsync(user3);
            }
        }
    }
}
