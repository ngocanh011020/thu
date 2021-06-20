using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class UserDao
    {
        PhamNgocAnhContext db = null;
        public UserDao()
        {
            db = new PhamNgocAnhContext();
        }
        public long Insert(UserAccount entity)
        {
            db.UserAccounts.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(UserAccount entity)
        {
            try
            {
                var user = db.UserAccounts.Find(entity.ID);
                
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.UserName = entity.UserName;
                user.Status = entity.Status;
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public object Login(string userName, object v)
        {
            throw new NotImplementedException();
        }

        public object login(string userName, string v)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserAccount> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<UserAccount> model = db.UserAccounts.OrderBy(x => x.ID);
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.UserName.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
        public UserAccount GetById(string userName)
        {
            return db.UserAccounts.SingleOrDefault(x => x.UserName == userName);
        }
        public UserAccount ViewDetail(int id)
        {
            return db.UserAccounts.Find(id);
        }
        public int Login(string userName, string passWord)
        {
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.UserAccounts.Find(id);
                db.UserAccounts.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}