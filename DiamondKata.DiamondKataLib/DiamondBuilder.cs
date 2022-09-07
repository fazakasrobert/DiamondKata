using System;
using System.Text;

namespace DiamondKata.DiamondKataLib
{
    public class DiamondBuilder
    {
        private char _inputCharacter; 
        
        public DiamondBuilder(char inputCharacter)
        {
            if (inputCharacter < 'A' || inputCharacter > 'Z')
                throw new ArgumentOutOfRangeException("Invalid input character, please enter a letter between A and Z.");

            this._inputCharacter = inputCharacter;            
        }

        public string Build()
        {
            int matrixSize = (_inputCharacter - 'A') * 2 + 1;
            char[,] diamondMatrix = new char[matrixSize, matrixSize];

            for (char actChar = 'A'; actChar <= _inputCharacter; actChar++)
            {
                //top left
                diamondMatrix[actChar - 'A', _inputCharacter - actChar] = actChar;
                //top right
                diamondMatrix[actChar - 'A', matrixSize / 2 + actChar - 'A' ] = actChar;
                //bottom left
                diamondMatrix[matrixSize -1 - (actChar - 'A'), _inputCharacter - actChar] = actChar;
                //bottom right
                diamondMatrix[matrixSize -1 - (actChar - 'A'), matrixSize / 2 + actChar - 'A'] = actChar;
            }

            return CharacterMatrixToString(diamondMatrix);
        }

        private string CharacterMatrixToString(char[,] matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int i=0; i < matrix.GetLength(0); i++)
            {
                for (int j=0; j < matrix.GetLength(1); j++)
                {
                    var actChar = matrix[i,j];

                    //array is full of defaults, checking for defaults here to avoid double loop to populate at the start
                    if (actChar == default(char))
                        sb.Append(' ');
                    else
                        sb.Append(actChar);
                }

                //to avoid unnecessary trailing new line
                if (i < matrix.GetLength(0)-1)
                    sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}