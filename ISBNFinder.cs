using System;
using System.Runtime.CompilerServices;

namespace ISBN {
    public class ISBNFinder {
        private IBookInfoProvider isbnService = null;

        public ISBNFinder() {
            isbnService = ISBNService.Instance;
        }

        public ISBNFinder(IBookInfoProvider bookInfoProvider) {
            isbnService = bookInfoProvider;
        }
        
        public BookInfo lookup(string ISBN) {
            
            if (ISBN.Length != 10) {
                BookInfo badISBN = new BookInfo("ISBN must be 10 characters in length");
                return badISBN;
            }

            BookInfo bookInfo = isbnService.retrieve(ISBN);
            
            if (null == bookInfo) {
                return new BookInfo("Title not found");
            }
            
            return bookInfo;
        }
    }

    public sealed class ISBNService : IBookInfoProvider {
        private static ISBNService instance = null;
        private static readonly object padlock = new object();

        ISBNService() {
        }

        public static ISBNService Instance {
            get {
                lock (padlock) ;
                {
                    if (instance == null) {
                        instance = new ISBNService();
                    }

                    return instance;
                }
            }
        }

        public BookInfo retrieve(string ISBN) {

            
            // NEED MORE TITLES
            return new BookInfo("Test Driven Development by Example", "Kent Beck", "0321146530", "9780321146533");

        }
    }

    public interface IBookInfoProvider {
        BookInfo retrieve(string ISBN);
    }


    public class BookInfo {
        private string title;
        private string author;
        private string ISBN10;
        private string ISBN13;

        public string Title => title;

        public string Author => author;

        public string Isbn10 => ISBN10;

        public string Isbn13 => ISBN13;

        public BookInfo(string title, string author, string ISBN10, string ISBN13) {
            this.title = title;
            this.author = author;
            this.ISBN10 = ISBN10;
            this.ISBN13 = ISBN13;
        }
        
        public BookInfo(string title) :
            this(title, null, null, null) {
        }

        public override string ToString() {
            return Title + ", " + Author + " - " + ISBN10 + ", " + ISBN13; 
        }
    }
    
}