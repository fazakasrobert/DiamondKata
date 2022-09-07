using System;
using DiamondKata.DiamondKataLib;
using Xunit;

namespace DiamondKata.DiamondKataLib.UnitTests
{
    public class DiamondBuilderTests
    {
        [Fact]
        public void Constructor_InvalidInputCharacter_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            DiamondBuilder diamondBuilder = null;

            //Act
            Action act = () => diamondBuilder = new DiamondBuilder(' ');

            //Assert
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Theory]
        [InlineData('A', "A")]
        [InlineData('B', " A \r\nB B\r\n A ")]
        [InlineData('C', "  A  \r\n B B \r\nC   C\r\n B B \r\n  A  ")]
        [InlineData('D', "   A   \r\n  B B  \r\n C   C \r\nD     D\r\n C   C \r\n  B B  \r\n   A   ")]
        [InlineData('E', "    A    \r\n   B B   \r\n  C   C  \r\n D     D \r\nE       E\r\n D     D \r\n  C   C  \r\n   B B   \r\n    A    ")]
        public void Build_InputCharacterIsValid_ReturnsCorrectDiamond(char inputCharacter, string expectedResult)
        {
            //Arrange
            DiamondBuilder diamondBuilder = new DiamondBuilder(inputCharacter);

            //Act
            var diamond = diamondBuilder.Build();

            //Assert
            Assert.Equal (expectedResult, diamond);
        }
    }
}
