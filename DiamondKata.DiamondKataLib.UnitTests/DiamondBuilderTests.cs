using System;
using DiamondKata.DiamondKataLib;
using Xunit;

namespace DiamondKata.DiamondKataLib.UnitTests
{
    public class DiamondBuilderTests
    {
        [Fact]
        public void Constructor_InvalidCharacter_ThrowsException()
        {
            //Arrange
            DiamondBuilder builder = null;

            //Act
            Action act = () => builder = new DiamondBuilder(' ');

            //Assert
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Theory]
        [InlineData('A', "A")]
        [InlineData('B', " A \r\nB B\r\n A ")]
        [InlineData('C', "  A  \r\n B B \r\nC   C\r\n B B \r\n  A  ")]
        [InlineData('D', "   A   \r\n  B B  \r\n C   C \r\nD     D\r\n C   C \r\n  B B  \r\n   A   ")]
        public void Build_InputCharIsValid_ReturnsCorrectDiamond(char inputCharacter, string expectedResult)
        {
            //Arrange
            DiamondBuilder builder = new DiamondBuilder(inputCharacter);

            //Act
            var diamond = builder.Build();

            //Assert
            Assert.Equal (expectedResult, diamond);
        }
    }
}
