using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectLibary
{
    public class Book
    {
        LibaryContext ctx=new LibaryContext();
        [Key][Required] public string ISBN { get; set; }

        public string ?Title { get; set; }
        public string ?Author { get; set; }
        public string ?Publication { get; set; }
        public string ?status { get; set; }
        public int ? ldb_id { set; get; }
        public virtual LibraryDataBase ? LibraryDataBase { get; set; }

      public int ? UserId { get; set; }
        public virtual User ? User { get; set; }

        public virtual int ? ID_librarian { get; set; }
         public virtual Librarian ? Librarian { get; set; }
        public DateTime? dateBorrowing { get; set; }
        public DateTime? dateRetarn { get; set; }







        public void UpdateStatus(string ISBN ,int UserId) {
            Book b = ctx.Books.SingleOrDefault(s => s.ISBN == ISBN);
            Account acount = ctx.Accounts.FirstOrDefault(s => s.UserId == UserId);
            if (b.status == "Borrowed")
            {
                acount.No_ReturnedBooks += 1;

            }
            else if (b.status == "Late") {
                acount.No_ReturnedBooks += 1;

            }
            else if (b.status == "Lost")
            {
                acount.No_ReturnedBooks += 1;

            }

              
            ctx.Accounts.Update(acount);
            b.UserId = null;
            b.dateRetarn= null;
            b.dateBorrowing = null;
            b.status = "Existing";
            ctx.Books.Update(b);
            ctx.SaveChanges();
            MessageBox.Show("return done .");




        }
        public void Borrow(User userLogin, DateTime time,string ISBN) {

            Account ac = ctx.Accounts.SingleOrDefault(s => s.UserId == userLogin.UserId);
            Book b = ctx.Books.SingleOrDefault(s => s.ISBN == ISBN);

            ac.No_BorrowedBooks += 1;
            ctx.Accounts.Update(ac);
            ctx.SaveChanges();
            
            b.dateBorrowing = DateTime.Now;
            b.dateRetarn = time;
            b.status = "Borrowed";
            ctx.Books.Update(b);
            ctx.SaveChanges();
            Book bok = ctx.Books.SingleOrDefault(s => s.ISBN == ISBN);
            bok.UserId = userLogin.UserId;
            ctx.Update(bok);
            ctx.SaveChanges();
            MessageBox.Show("done !");
        }






    }
}
