namespace API_Email.Repositories
{
    using System;
    using System.Configuration;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Dapper.Contrib.Extensions;
    using Models;

    public class UsersRepository : IRepository<User>
    {
        private readonly string _connectionString;

        public UsersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var users = await connection.GetAllAsync<User>();
                return users;
            }
        }

        public async Task<User> GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var user = await connection.GetAsync<User>(id);
                return user;
            }
        }

        public async Task<User> Create(User user)
        {
            string insertQuery = "INSERT INTO USERS (Name, Email) VALUES (@Name, @Email)";
            string findByEmailQuery = "SELECT * from USERS where Email = @Email";

            using (var connection = new SqlConnection(_connectionString))
            {
                var existingUserWithEmail = connection.Query<User>(findByEmailQuery, new {Email = user.Email}).FirstOrDefault();
                if (existingUserWithEmail == null)
                {
                    await connection.InsertAsync(user);
                    var createdUser = (await connection.QueryAsync<User>(findByEmailQuery, new {Email = user.Email})).FirstOrDefault();
                    return createdUser;
                }

                return null;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var user = await connection.GetAsync<User>(id);
                if (user != null)
                {
                    var isSuccess = await connection.DeleteAsync(user);
                    return isSuccess;
                }

                return false;
            }
        }

        public async Task<bool> Update(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var isSuccess = await connection.UpdateAsync<User>(user);
                return isSuccess;
            }
        }
    }
}
