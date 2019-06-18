using System;
using System.Collections.Generic;
using System.Text;

namespace API_Email.Data.Repositories
{
    using System.Threading.Tasks;
    using Models;

    public class UsersRepository : IRepository<User>
    {
        private readonly string _connectionString;

        public UsersRepository()
        {
                
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User Create(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
