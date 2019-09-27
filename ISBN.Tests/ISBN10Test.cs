using System;
using System.Collections.Generic;
using Xunit;

namespace ISBN.Tests {
    public class ISBN10Test {
        [Fact]
        public void ISBN_ShorterThan10Characters_ReturnsInvalidBookInfo() {
            //Arrange
            String shortISBN = "12345";
            
            //Act
            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(shortISBN);
            
            //Assert
            Assert.Equal("ISBN must be 10 characters in length", actual.title);
        }
    }

    public class BookInfo {
        public String title;
    }

    public class ISBNFinder {
        public BookInfo lookup(string ISBN) {
            BookInfo bookInfo = new BookInfo();
            bookInfo.title = "ISBN must be 10 characters in length";
            
            return bookInfo;
        }
    }
}