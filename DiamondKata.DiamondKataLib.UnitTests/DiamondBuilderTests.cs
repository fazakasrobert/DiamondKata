using Xunit;

namespace DiamondKata.DiamondKataLib.UnitTests
{
    public class DiamondBuilderTests
    {
        private static Random random = new Random();

        private static char GetRandomCharacter()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
            return chars[random.Next(chars.Length)];
        }

        [Fact]
        public void Constructor_InvalidInputCharacter_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            DiamondBuilder diamondBuilder;

            //Act
            Action act = () => diamondBuilder = new DiamondBuilder(' ');

            //Assert
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Theory]
        [InlineData('A')]
        [InlineData('B')]
        [InlineData('Z')]
        public void CharacterMatrixToString_ValidMatrix_ReturnsPrintedMatrix(char inputCharacter)
        {
            //Arrange
            var diamondBuilder = new DiamondBuilder(inputCharacter);
            var matrixSize = diamondBuilder.MatrixSize;
            char[,] testMatrix = new char[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                for  (int j= 0; j < matrixSize; j++)
                {
                    testMatrix[i,j] = GetRandomCharacter();
                }
            }

            //Act
            var matrixString = diamondBuilder.CharacterMatrixToString(testMatrix);

            //Assert
            string[] lines = matrixString.Split(new string[] {Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < matrixSize; i++)
            {
                for  (int j= 0; j < matrixSize; j++)
                {
                    Assert.Equal(testMatrix[i,j], lines[i][j]);
                }
            }
        }

        [Fact]
        public void Build_InputCharacterIsA_ReturnsCorrectDiamond()
        {
            //Arrange
            DiamondBuilder diamondBuilder = new DiamondBuilder('A');
            string expectedResult = "A";

            //Act
            var diamond = diamondBuilder.Build();

            //Assert
            Assert.Equal(expectedResult, diamond);
        }

        [Fact]
        public void Build_InputCharacterIsB_ReturnsCorrectDiamond()
        {
            //Arrange
            DiamondBuilder diamondBuilder = new DiamondBuilder('B');
            string expectedResult = string.Empty 
            + " A " + Environment.NewLine 
            + "B B" + Environment.NewLine 
            + " A ";

            //Act
            var diamond = diamondBuilder.Build();

            //Assert
            Assert.Equal(expectedResult, diamond);
        }

        [Fact]
        public void Build_InputCharacterIsC_ReturnsCorrectDiamond()
        {
            //Arrange
            DiamondBuilder diamondBuilder = new DiamondBuilder('C');
            string expectedResult = string.Empty 
            + "  A  " + Environment.NewLine 
            + " B B " + Environment.NewLine 
            + "C   C" + Environment.NewLine 
            + " B B " + Environment.NewLine 
            + "  A  ";

            //Act
            var diamond = diamondBuilder.Build();

            //Assert
            Assert.Equal(expectedResult, diamond);
        }

        [Fact]
        public void Build_InputCharacterIsD_ReturnsCorrectDiamond()
        {
            //Arrange
            DiamondBuilder diamondBuilder = new DiamondBuilder('D');
            string expectedResult = string.Empty 
            + "   A   " + Environment.NewLine 
            + "  B B  " + Environment.NewLine 
            + " C   C " + Environment.NewLine 
            + "D     D" + Environment.NewLine 
            + " C   C " + Environment.NewLine 
            + "  B B  " + Environment.NewLine 
            + "   A   ";

            //Act
            var diamond = diamondBuilder.Build();

            //Assert
            Assert.Equal(expectedResult, diamond);
        }

        [Fact]
        public void Build_InputCharacterIsE_ReturnsCorrectDiamond()
        {
            //Arrange
            DiamondBuilder diamondBuilder = new DiamondBuilder('E');
            string expectedResult = string.Empty 
            + "    A    " + Environment.NewLine 
            + "   B B   " + Environment.NewLine 
            + "  C   C  " + Environment.NewLine 
            + " D     D " + Environment.NewLine 
            + "E       E" + Environment.NewLine 
            + " D     D " + Environment.NewLine 
            + "  C   C  " + Environment.NewLine 
            + "   B B   " + Environment.NewLine 
            + "    A    ";

            //Act
            var diamond = diamondBuilder.Build();

            //Assert
            Assert.Equal(expectedResult, diamond);
        }
    }
}
