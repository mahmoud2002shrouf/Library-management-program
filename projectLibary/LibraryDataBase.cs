using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projectLibary
{

    public class LibraryDataBase
    {
        [Key][Required] public int ldb_id { get; set; }

        public string? ISBN { get; set; }
        public virtual ICollection<Book>? ListOfBooks { get; set; }

        public int? ID_librarian { get; set; }
        public virtual Librarian? Librarian { get; set; }

        public int? AccountId { get; set; }
        public virtual ICollection<Account>? Accounts { get; set; }



        LibaryContext ctx = new LibaryContext();


        public void Add(Book book)
        {
            try
            {
                // Check if the ISBN is already in use
                var existingBook = ctx.Books.SingleOrDefault(b => b.ISBN == book.ISBN);

                if (existingBook != null)
                {
                    MessageBox.Show("ISBN مستخدم من قبل");
                }
                else
                {
                    // ISBN is not in use, proceed with the update
                    ctx.Set<Book>().Add(book);
                    book.Librarian = Program.LibrarianLogIn;
                    book.ID_librarian = Program.LibrarianLogIn?.ID_librarian;
                    book.ldb_id = Program.LibrarianLogIn?.ldb_id;

                    // You can choose to save changes here or later based on your logic
                    ctx.SaveChanges();
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency exception
                MessageBox.Show($"حدث خطأ أثناء محاولة إضافة الكتاب: {ex.Message}");
            }
        }

        public void Delete(string ISBN)
        {
            var bookToDelete =ctx. Books.SingleOrDefault(s=>s.ISBN==ISBN);

            if (bookToDelete != null)
            {
               ctx. Books.Remove(bookToDelete);
                ctx.SaveChanges();
            }
        }




        public void Update(string ISBN)
        {
            var BookUpData = ctx.Books.SingleOrDefault(s => s.ISBN == ISBN);

            if (BookUpData != null)
            {
                ctx.Books.Update(BookUpData);
                ctx.SaveChanges();
            }

        }

        public List<Book> Display()
        {
            return ctx.Books.ToList();
        }

        public Book Search(string ISBN)
        {
           return ctx.Books.SingleOrDefault(book => book.ISBN.Equals(ISBN));
        }
    }
}
