using System;
using ChessLibrary.Models;
using ChessLibrary.Interfaces;
using ChessGame;
using System.Windows;
using System.Windows.Controls;

namespace ChessGame
{
    public class Movement : IMoves
    {
        public bool BishopMove(Piece model, int previousColumn, int previousRow, int nextColumn, int nextRow, bool validBool)
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

        public bool KingMove(Piece model, int previousColumn, int previousRow, int nextColumn, int nextRow, bool validBool)
        {
            if ((previousColumn == nextColumn + 1 || previousColumn == nextColumn - 1) && (previousRow == nextRow + 1 || previousRow == nextRow - 1))
            {
                validBool = true;
            }

            else if ((previousColumn == nextColumn) && (previousRow == nextRow + 1 || previousRow == nextRow - 1))
            {
                validBool = true;
            }

            else if ((previousRow == nextRow) && (previousColumn == nextColumn + 1 || previousColumn == nextColumn + 1))
            {
                validBool = true;
            }

            else
            {
                validBool = false;
            }
            return validBool;
        }

        public bool KnightMove(Piece model, int previousColumn, int previousRow, int nextColumn, int nextRow, bool validBool)
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

        public bool PawnMove(Piece model, int previousColumn, int previousRow, int nextColumn, int nextRow, bool validBool)
        {
            if (model.PieceColor == PieceColors.White)
            {
                if ((previousColumn == nextColumn) && (previousRow == nextRow - 1))
                {
                    validBool = true;
                }

                else
                {
                    validBool = false;
                }
            }

            else if (model.PieceColor == PieceColors.Black)
            {
                if ((previousColumn == nextColumn) && (previousRow == nextRow + 1))
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

        public bool QueenMove(Piece model, int previousColumn, int previousRow, int nextColumn, int nextRow, bool validBool)
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

        public bool RookMove(Piece model, int previousColumn, int previousRow, int nextColumn, int nextRow, bool validBool)
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

        public bool ValidMoveChecker(bool validation, Piece previousPiece, Piece nextPiece, int previousColumn, int previousRow, int nextColumn, int nextRow)
        {
            if ((previousPiece.PieceColor != nextPiece.PieceColor) && (previousPiece.PieceType != PieceTypes.Free))
            {
                if (previousPiece.PieceType == PieceTypes.Pawn)
                {
                    validation = PawnMove(previousPiece, previousColumn, previousRow, nextColumn, nextRow, validation);
                }

                else if (previousPiece.PieceType == PieceTypes.Rook)
                {
                    validation = RookMove(previousPiece, previousColumn, previousRow, nextColumn, nextRow, validation);
                }

                else if (previousPiece.PieceType == PieceTypes.Bishop)
                {
                    validation = BishopMove(previousPiece, previousColumn, previousRow, nextColumn, nextRow, validation);
                }

                else if (previousPiece.PieceType == PieceTypes.King)
                {
                    validation = KingMove(previousPiece, previousColumn, previousRow, nextColumn, nextRow, validation);
                }

                else if (previousPiece.PieceType == PieceTypes.Queen)
                {
                    validation = QueenMove(previousPiece, previousColumn, previousRow, nextColumn, nextRow, validation);
                }

                else if (previousPiece.PieceType == PieceTypes.Knight)
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
