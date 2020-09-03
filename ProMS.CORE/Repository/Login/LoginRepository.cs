using Microsoft.EntityFrameworkCore;
using ProMS.CORE.Data;
using ProMS.CORE.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProMS.CORE.Repository.Login
{
    public sealed class LoginRepository
    {
        private readonly PmsDbContext _database;

        public LoginRepository(PmsDbContext context)
        {
            _database = context;
        }

        public UserModel CurrentUser { get; private set; }

        public bool Login(string username, string Password)
        {
            try
            {
                if (_database == null)
                    throw new ArgumentNullException(nameof(_database));

                CurrentUser = _database.Users.FirstOrDefaultAsync(user => user.Username == username
                && user.Password == Password).Result ?? null;

                if (CurrentUser == null)
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void LoadCurrentUser(string id)
        {
            CurrentUser = _database.Users.FirstOrDefaultAsync(user => user.Id.ToString() == id).Result ?? null;
        }
    }
}
