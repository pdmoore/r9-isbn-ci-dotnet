using System;
using Xunit;

namespace ISBN {
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

        [Fact]
        public void ISBN_LongerThan10Characters_ReturnsInvalidBookInfo() {
            String longISBN = "123456789ABCEDF";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(longISBN);
            
            Assert.Equal("ISBN must be 10 characters in length", actual.title);
        }

        [Fact]
        public void ISBN_BookAvailableFromFinder() {
            String unknownISBN = "0553562614";
            
            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(unknownISBN);
            
            Assert.Equal("Title not found", actual.title);
        }
    }

}