using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectLibary
{
    public class Account
    {
        LibaryContext ctx=new LibaryContext();

        [Key][Required] public int AccountId { get; set; }
        public int No_BorrowedBooks { get; set; }
        public int No_Late_book { get; set; }
        public int No_ReturnedBooks { get; set; }
        public int No_LostBooks { get; set; }
        public decimal FineAmount { get; set; }
        public int ?  UserId { get; set; }
        public virtual  User ? user{ get; set; }

        public int ? ldb_id { get; set; }
        public virtual LibraryDataBase ? LibraryDataBase { get; set; }


        public decimal CalculateFine()
        {
            return  (No_LostBooks * 5) + (No_Late_book * 3);

        }
        public void Update_Acount(Account account) {

            if (account != null)
            {
                ctx.Accounts.Update(account);
                ctx.SaveChanges();
            }
       
        }
    }
}
