using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace projectLibary
{
    public class User : LibraryManagmentUser
    {
       [Key][Required] public int UserId { get; set; }
        public string ? name { get; set; }

        public int ?  AccountId { get; set; }
        public virtual Account ? account { get; set; }


        public string ? ISBN { get; set; }
        public virtual ICollection<Book> ? Books  { get; set; }


        public virtual void Register(User user)
        {
            ctx.users.Add(user);
            ctx.SaveChanges();
        }
        public User Verify(string userName,string password)
        {
            User users = ctx.users.SingleOrDefault(u => u.UserName == userName && u.Password == password);
            if (users != null)
            {
                return users;


            }
            else
            {
                return null;
            }
        }
        public void CheckAccount(){}

        public void GetBookInfo(){}

    }
}
