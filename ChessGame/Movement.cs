namespace ChessGame
{
    using System;
    using ChessLibrary.Enums;
    using ChessLibrary.Interfaces;

    public class Movement : IMoves
    {
        public bool BishopMove(IPiece model, int previousColumn, int previousRow, int nextColumn, int nextRow, bool validBool)
        {
            if (Math.Abs(previousColumn - nextColumn) == Math.Abs(previousRow - nextRow))
            {
                validBool = true;
            }

            else
            {
                validBool = false;
            }

            return validBool;
        }

        public bool KingMove(IPiece model, int previousColumn, int previousRow, int nextColumn, int nextRow, bool validBool)
        {
            if ((previousColumn == nextColumn + 1 || previousColumn == nextColumn - 1) && (previousRow == nextRow + 1 || previousRow == nextRow - 1))
            {
                validBool = true;
            }

            else if ((previousColumn == nextColumn) && (previousRow == nextRow + 1 || previousRow == nextRow - 1))
            {
                validBool = true;
            }

            else if ((previousRow == nextRow) && (previousColumn == nextColumn + 1 || previousColumn == nextColumn - 1))
            {
                validBool = true;
            }

            else if (model.PieceMoveCounter == 0 && previousRow == nextRow && (previousColumn == nextColumn + 2 || previousColumn == nextColumn - 2))
            {
                validBool = true;
            }

            else
            {
                validBool = false;
            }
            return validBool;
        }

        public bool KnightMove(IPiece model, int previousColumn, int previousRow, int nextColumn, int nextRow, bool validBool)
        {
            if ((previousColumn == nextColumn + 1 || previousColumn == nextColumn - 1) && (previousRow == nextRow + 2 || previousRow == nextRow - 2))
            {
                validBool = true;
            }

            else if ((previousRow == nextRow + 1 || previousRow == nextRow - 1) && (previousColumn == nextColumn + 2 || previousColumn == nextColumn - 2))
            {
                validBool = true;
            }

            else
            {
                validBool = false;
            }

            return validBool;
        }

        public bool PawnMove(IPiece modelPrevious, IPiece modelNext, int previousColumn, int previousRow, int nextColumn, int nextRow, bool validBool) 
        {
            if (modelPrevious.PieceColor == PieceColor.White)
            {
                if ((modelNext.PieceColor == PieceColor.Black) && (previousColumn == nextColumn))
                {
                    validBool = false;
                }

                else if ((modelNext.PieceColor == PieceColor.Black) && (previousRow == nextRow + 1) && (previousColumn == nextColumn + 1 || previousColumn == nextColumn - 1))
                {
                    validBool = true;
                }

                else if ((previousColumn == nextColumn) && (previousRow == nextRow + 2) && previousRow == 6)
                {
                    validBool = true;
                }

                else if ((previousColumn == nextColumn) && (previousRow == nextRow + 1))
                {
                    validBool = true;
                }

                else if ((previousColumn == nextColumn + 1 || previousColumn == nextColumn - 1) && nextRow == 2)
                {
                    validBool = true;
                }

                else
                {
                    validBool = false;
                }
            }

            else if (modelPrevious.PieceColor == PieceColor.Black)
            {
                if ((modelNext.PieceColor == PieceColor.White) && (previousColumn == nextColumn))
                {
                    validBool = false;
                }

                else if ((modelNext.PieceColor == PieceColor.White) && (previousRow == nextRow - 1) && (previousColumn == nextColumn + 1 || previousColumn == nextColumn - 1))
                {
                    validBool = true;
                }

                else if ((previousColumn == nextColumn) && (previousRow == nextRow - 2) && previousRow == 1)
                {
                    validBool = true;
                }

                else if ((previousColumn == nextColumn) && (previousRow == nextRow - 1))
                {
                    validBool = true;
                }

                else if ((previousColumn == nextColumn + 1 || previousColumn == nextColumn - 1) && nextRow == 5)
                {
                    validBool = true;
                }

                else
                {
                    validBool = false;
                }
            }

            return validBool;
        }

        public bool QueenMove(IPiece model, int previousColumn, int previousRow, int nextColumn, int nextRow, bool validBool)
        {
            if (previousColumn == nextColumn || previousRow == nextRow)
            {
                validBool = true;
            }

            else if (Math.Abs(previousColumn - nextColumn) == Math.Abs(previousRow - nextRow))
            {
                validBool = true;
            }

            else
            {
                validBool = false;
            }

            return validBool;
        }

        public bool RookMove(IPiece model, int previousColumn, int previousRow, int nextColumn, int nextRow, bool validBool)
        {
            if (previousColumn == nextColumn || previousRow == nextRow)
            {
                validBool = true;
            }

            else
            {
                validBool = false;
            }

            return validBool;
        }

        public bool ValidMoveChecker(bool validation, IPiece previousPiece, IPiece nextPiece, int previousColumn, int previousRow, int nextColumn, int nextRow)
        {
            if (previousPiece.PieceColor != nextPiece.PieceColor  && previousPiece.PieceType != PieceType.Free)
            {
                if (previousPiece.PieceType == PieceType.Pawn)
                {
                    validation = PawnMove(previousPiece, nextPiece, previousColumn, previousRow, nextColumn, nextRow, validation);
                }

                else if (previousPiece.PieceType == PieceType.Rook)
                {
                    validation = RookMove(previousPiece, previousColumn, previousRow, nextColumn, nextRow, validation);
                }

                else if (previousPiece.PieceType == PieceType.Bishop)
                {
                    validation = BishopMove(previousPiece, previousColumn, previousRow, nextColumn, nextRow, validation);
                }

                else if (previousPiece.PieceType == PieceType.King)
                {
                    validation = KingMove(previousPiece, previousColumn, previousRow, nextColumn, nextRow, validation);
                }

                else if (previousPiece.PieceType == PieceType.Queen)
                {
                    validation = QueenMove(previousPiece, previousColumn, previousRow, nextColumn, nextRow, validation);
                }

                else if (previousPiece.PieceType == PieceType.Knight)
                {
                    validation = KnightMove(previousPiece, previousColumn, previousRow, nextColumn, nextRow, validation);
                }
            }
            else
            {
                validation = false;
            }

            return validation;
        }
    }
}
