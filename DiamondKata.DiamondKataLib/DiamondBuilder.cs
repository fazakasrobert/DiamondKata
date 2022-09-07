using System;
using System.Text;

namespace DiamondKata.DiamondKataLib
{
    public class DiamondBuilder
    {
        private char _inputCharacter;

        public int MatrixSize 
        { 
            get 
            { 
                return (_inputCharacter - 'A') * 2 + 1; 
            }
        }

        public DiamondBuilder(char inputCharacter)
        {
            if (inputCharacter < 'A' || inputCharacter > 'Z')
                throw new ArgumentOutOfRangeException("Invalid input character, please use a letter between A and Z.");

            this._inputCharacter = inputCharacter;
        }

        public string Build()
        {
            var matrixSize = this.MatrixSize;
            char[,] diamondMatrix = new char[matrixSize, matrixSize];

            SetLettersInDiamondShape(diamondMatrix, matrixSize);

            return CharacterMatrixToString(diamondMatrix);
        }

        public void SetLettersInDiamondShape(char[,] diamondMatrix, int matrixSize)
        {
            for (char actChar = 'A'; actChar <= _inputCharacter; actChar++)
            {
                //top left
                diamondMatrix[actChar - 'A', _inputCharacter - actChar] = actChar;

                //top right
                diamondMatrix[actChar - 'A', matrixSize / 2 + actChar - 'A'] = actChar;

                //bottom left
                diamondMatrix[matrixSize - 1 - (actChar - 'A'), _inputCharacter - actChar] = actChar;

                //bottom right
                diamondMatrix[matrixSize - 1 - (actChar - 'A'), matrixSize / 2 + actChar - 'A'] = actChar;
            }
        }

        public string CharacterMatrixToString(char[,] matrix)
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    var currentCharacter = matrix[i, j];
                    
                    //array is initialised with defaults, using defaults instead of spaces in the array to avoid having to use a nested loop to initialise the array
                    if (currentCharacter == default(char))
                        stringBuilder.Append(' ');
                    else
                        stringBuilder.Append(currentCharacter);
                }

                //add newline only if this is not the last row
                if (i < matrix.GetLength(0) - 1) 
                    stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}
