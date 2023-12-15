using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using supertest.modelx;


namespace supertest
{



    public class UserControllercs
    {
        Connection connection = new Connection();

        public List<Users> GetUsers()
        {
            try
            {
                var users = connection.auth.Users.ToList();
                return users;
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

        }


        public Users CreateNewUser(string firstname, string lastname, string patronymic, DateTime datebirth, string username, string password, int genderId)
        {
            try
            {
                Users users = new Users
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Patronymic = patronymic,
                    DateBirth = datebirth,
                    UserName = username,
                    UserPassword = password,
                    GenderID = genderId,
                    RoleID = 1,
                };

                connection.auth.Users.Add(users);
                connection.auth.SaveChanges();
                return users;


            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public Users SignIn(string username, string password)
        {
            try
            {
                var user = connection.auth.Users.Where(x => x.UserName == username && x.UserPassword == password).First();
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
