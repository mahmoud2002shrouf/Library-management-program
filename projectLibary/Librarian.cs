using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace projectLibary
{
    public class Librarian : LibraryManagmentUser
    {
        LibaryContext ctx=new LibaryContext();
    [Key][Required] public int ID_librarian { get; set; }

        public string ?Name { get; set; }
        public string ?Password { get; set; }

        public int ? ldb_id { get; set; }
        public virtual LibraryDataBase? LibraryDataBase { get; set; }

        public string ?ISBN { get; set; }
        public virtual ICollection<Book> ? Books { get; set; }

        public Librarian VerifyLibrarian(string userName,string password)
        {
            Librarian lip = ctx.librarians.FirstOrDefault(u => u.UserName == userName && u.Password == password);
           if (lip != null)
            {
                return lip;


            }
            else
            {
                return null;
            }
        }
        public virtual void Register(Librarian user)
        {
            ctx.librarians.Add(user);
            ctx.SaveChanges();
        }


    }
}
