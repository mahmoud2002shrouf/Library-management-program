using projectLibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectLibary
{
    
    public class LibraryManagmentUser
    {
        public LibaryContext ctx = new LibaryContext();


        public string ?UserTayp { get; set; }
        public string ?UserName { get; set; }
        public string ? Password { get; set; }

        public void logIn() { }
        public void logOut() { }
        public void Register(LibraryManagmentUser user) {
           
          
        }
    }
}
