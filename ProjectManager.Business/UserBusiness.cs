using ProjectManager.Data;
using ProjectManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProjectManager.Business
{

    public class UserBusiness
    {
        public List<User> GetAllUsers()
        {
            using (ProjectDBContext _db = new ProjectDBContext())
            {
                return _db.Users.ToList();
            }
        }
        
        public User GetUserByID(string id)
        {
            using (ProjectDBContext _db = new ProjectDBContext())
            {
                if (_db.Users.Any(a => a.User_ID == id))
                {
                    return _db.Users.FirstOrDefault(a => a.User_ID == id);
                }
                else
                {
                    throw new Exception(string.Format("User with the id - {0} could not be found", id));
                }
            }
        }

        public User GetUserByProjectID(string id)
        {
            using (ProjectDBContext _db = new ProjectDBContext())
            {
                if (_db.Users.Any(a => a.Project_ID == id))
                {
                    return _db.Users.LastOrDefault(a => a.Project_ID == id);
                }
                else
                {
                    return null;
                }
            }
        }

        public bool AddUser(User newUser)
        {
            using (ProjectDBContext _db = new ProjectDBContext())
            {
                _db.Users.Add(newUser);
                _db.SaveChanges();
                return true;
            }
        }

        public bool UpdateUser(User updateUser)
        {
            using (ProjectDBContext _db = new ProjectDBContext())
            {
                if (_db.Users.Any(a => a.User_ID == updateUser.User_ID))
                {
                    User userToRemove = _db.Users.FirstOrDefault(a => a.User_ID == updateUser.User_ID);
                    _db.Users.Remove(userToRemove);
                    _db.Users.Add(updateUser);
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception(string.Format("User with the name - {0} could not be found", updateUser.User_ID));
                }
            }
        }

        public bool DeleteUser(string id)
        {
            using (ProjectDBContext _db = new ProjectDBContext())
            {
                if (_db.Users.Any(a => a.User_ID == id))
                {
                    User userToRemove = _db.Users.FirstOrDefault(a => a.User_ID == id);
                    _db.Users.Remove(userToRemove);
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception(string.Format("User with the name - {0} could not be found", id));
                }
            }
        }

    }
}
