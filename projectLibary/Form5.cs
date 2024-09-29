using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectLibary
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            LibaryContext ctx = new LibaryContext();
            InitializeComponent();
            var userId = Program.UserLogin.UserId;
            Account account = ctx.Accounts.SingleOrDefault(s => s.UserId == Program.UserLogin.UserId);
            account.No_BorrowedBooks = ctx.Books.Count(book => book.UserId == userId && book.status == "Borrowed");
            account.No_Late_book = ctx.Books.Count(book => book.UserId == userId && book.status == "Late");
            account.No_LostBooks = ctx.Books.Count(book => book.UserId == userId && book.status == "Lost");

            ctx.Accounts.Update(account);
            ctx.SaveChanges();
            label25.Text = Convert.ToString(account.No_BorrowedBooks);
            label24.Text = Convert.ToString(account.No_ReturnedBooks);
            label26.Text = Convert.ToString(account.No_Late_book);
            label27.Text = Convert.ToString(account.No_LostBooks);
            label28.Text = Convert.ToString(account.FineAmount);




        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
