using System;

namespace ISBN {
    public class ISBNFinder {
        public BookInfo lookup(string ISBN) {
            
            if (ISBN.Length != 10) {
                BookInfo badISBN = new BookInfo();
                badISBN.title = "ISBN must be 10 characters in length";
                return badISBN;
            }            
            
            BookInfo bookInfo = new BookInfo();
            bookInfo.title = "Title not found";
            return bookInfo;
        }
    }
    
        
    public class BookInfo {
        public String title;
    }
    
}