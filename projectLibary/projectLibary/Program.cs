namespace projectLibary
{

    internal static class Program
    {
        public static  User? UserLogin;
        public static Librarian? LibrarianLogIn;


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
        LibaryContext ctx=new LibaryContext();
            List<Book> books = new List<Book>();
            try
            {
                foreach (Book book in ctx.Books)
                {
                    if (book.dateRetarn != null)
                    {
                        if (DateTime.Now > book.dateRetarn && book.status == "Borrowed")
                        {
                            book.status = "Late";
                            if (book.UserId != null)
                            {
                         


                                ctx.Books.Update(book);
                            }
                        }
                    }


                }
                ctx.SaveChanges();

            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show($"InvalidCastException: {ex.Message}");
            }
            List<Book> bookAcount = new List<Book>();
            try
            {
                foreach (Book book in ctx.Books)
                {
                    if (book.dateRetarn != null)
                    {
                        if (DateTime.Now > book.dateRetarn && book.status == "Borrowed")
                        {
                            if (book.UserId != null)
                            {
                                Account ac = ctx.Accounts.SingleOrDefault(s => s.UserId == book.UserId);
                                if (ac != null)
                                {
                                    ac.No_Late_book += 1;
                                    ac.No_BorrowedBooks -= 1;
                                    ctx.Accounts.Update(ac);
                                }
                            }
                        }
                    }


                }
                ctx.SaveChanges();

            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show($"InvalidCastException: {ex.Message}");
            }
            List<Account> accounts = new List<Account>();
            try
            {
                foreach (Account account in ctx.Accounts)
                {
                    account.FineAmount = account.CalculateFine();
                    
                   
                }
                ctx.SaveChanges();


            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show($"InvalidCastException: {ex.Message}");
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.Run(new Form2());
        }
    }
}