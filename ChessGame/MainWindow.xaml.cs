namespace ChessGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using ChessGame.Builders;
    using ChessLibrary.Enums;
    using ChessLibrary.Interfaces;
    using ChessLibrary.Models;
    using ChessLibrary.Models.Pieces;

    public partial class MainWindow : Window
    {
        #region Constants (Pieces images)
        private const string pawnImageBlack = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_black_pawn_T.png";
        private const string rookImageBlack = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_black_rook_T.png";
        private const string bishopImageBlack = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_black_bishop_T.png";
        private const string knightImageBlack = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_black_knight_T.png";
        private const string queenImageBlack = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_black_queen_T.png";
        private const string kingImageBlack = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_black_king_T.png";

        private const string pawnImageWhite = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_white_pawn_T.png";
        private const string rookImageWhite = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_white_rook_T.png";
        private const string bishopImageWhite = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_white_bishop_T.png";
        private const string knightImageWhite = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_white_knight_T.png";
        private const string queenImageWhite = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_white_queen_T.png";
        private const string kingImageWhite = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_white_king_T.png";
        #endregion

        #region Variables
        private IPiece[,] myBoard = new IPiece[,] { };
        private Button buttonClickOne;
        private Button buttonClickTwo;
        private Button castleButtonOne;
        private Button castleButtonTwo;
        private IEnumerable<UIElement> listElements;
        private int pressLeftMouseButton;
        private int pressRightMouseButton;
        private int previousColumn;
        private int previousRow;
        private int nextColumn;
        private int nextRow;
        private IPiece previousPiece;
        private IPiece nextPiece;
        private IPiece lastTurn;
        private bool validMove;
        private bool blockCheck = true;
        private int placeholderColumn;
        private int placeholderRow;
        private int turnCounter = 1;
        private bool turnCheck;
        private bool castleCheck;
        private bool enPassantCheck;
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            GridBuilder.GridDeployer(MainGrid);

            VirtualBoardDeployer();

            PiecesDeployer();

            LastTurnFirstRoundFixer();
        }

        #region Board
        private void PiecesDeployer()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button button = new Button();
                    button.Height = 100;
                    button.Width = 100;

                    if (myBoard[i, j].PieceType == PieceType.Pawn)
                    {
                        if (myBoard[i, j].PieceColor == PieceColor.White)
                        {
                            button.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(pawnImageWhite)),
                            };
                        }
                        else if (myBoard[i, j].PieceColor == PieceColor.Black)
                        {
                            button.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(pawnImageBlack)),
                            };
                        }
                    }

                    else if (myBoard[i, j].PieceType == PieceType.Rook)
                    {
                        if (myBoard[i, j].PieceColor == PieceColor.White)
                        {
                            button.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(rookImageWhite)),
                            };
                        }
                        else if (myBoard[i, j].PieceColor == PieceColor.Black)
                        {
                            button.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(rookImageBlack)),
                            };
                        }
                    }

                    else if (myBoard[i, j].PieceType == PieceType.Bishop)
                    {
                        if (myBoard[i, j].PieceColor == PieceColor.White)
                        {
                            button.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(bishopImageWhite)),
                            };
                        }
                        else if (myBoard[i, j].PieceColor == PieceColor.Black)
                        {
                            button.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(bishopImageBlack)),
                            };
                        }
                    }

                    else if (myBoard[i, j].PieceType == PieceType.Knight)
                    {
                        if (myBoard[i, j].PieceColor == PieceColor.White)
                        {
                            button.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(knightImageWhite)),
                            };
                        }
                        else if (myBoard[i, j].PieceColor == PieceColor.Black)
                        {
                            button.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(knightImageBlack)),
                            };
                        }
                    }

                    else if (myBoard[i, j].PieceType == PieceType.Queen)
                    {
                        if (myBoard[i, j].PieceColor == PieceColor.White)
                        {
                            button.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(queenImageWhite)),
                            };
                        }
                        else if (myBoard[i, j].PieceColor == PieceColor.Black)
                        {
                            button.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(queenImageBlack)),
                            };
                        }
                    }

                    else if (myBoard[i, j].PieceType == PieceType.King)
                    {
                        if (myBoard[i, j].PieceColor == PieceColor.White)
                        {
                            button.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(kingImageWhite)),
                            };
                        }
                        else if (myBoard[i, j].PieceColor == PieceColor.Black)
                        {
                            button.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(kingImageBlack)),
                            };
                        }
                    }

                    button.Background = Brushes.Transparent;
                    button.Click += new RoutedEventHandler(Button_Click);
                    button.MouseRightButtonUp += new MouseButtonEventHandler(RightButton_Click);
                    MainGrid.Children.Add(button);
                    Grid.SetColumn(button, j + 1);
                    Grid.SetRow(button, i);
                }
            }
        }

        private void VirtualBoardDeployer()
        {
            myBoard = new Piece[,] {
                { new Rook(PieceType.Rook,PieceColor.Black),new Knight(PieceType.Knight,PieceColor.Black), new Bishop(PieceType.Bishop,PieceColor.Black),new King(PieceType.King,PieceColor.Black), new Queen(PieceType.Queen,PieceColor.Black), new Bishop(PieceType.Bishop,PieceColor.Black), new Piece(PieceType.Knight,PieceColor.Black), new Piece(PieceType.Rook,PieceColor.Black) },
                { new Pawn(PieceType.Pawn,PieceColor.Black), new Pawn(PieceType.Pawn,PieceColor.Black), new Pawn(PieceType.Pawn,PieceColor.Black), new Pawn(PieceType.Pawn,PieceColor.Black), new Pawn(PieceType.Pawn,PieceColor.Black), new Pawn(PieceType.Pawn,PieceColor.Black), new Pawn(PieceType.Pawn,PieceColor.Black), new Pawn(PieceType.Pawn,PieceColor.Black) },
                { new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Piece(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None) },
                { new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Piece(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None) },
                { new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Piece(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None) },
                { new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Piece(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None), new Free(PieceType.Free,PieceColor.None) },
                { new Pawn(PieceType.Pawn,PieceColor.White), new Pawn(PieceType.Pawn,PieceColor.White), new Pawn(PieceType.Pawn,PieceColor.White), new Pawn(PieceType.Pawn,PieceColor.White), new Pawn(PieceType.Pawn,PieceColor.White), new Pawn(PieceType.Pawn,PieceColor.White), new Pawn(PieceType.Pawn,PieceColor.White), new Pawn(PieceType.Pawn,PieceColor.White) },
                { new Rook(PieceType.Rook,PieceColor.White),new Knight(PieceType.Knight,PieceColor.White), new Bishop(PieceType.Bishop,PieceColor.White),new King(PieceType.King,PieceColor.White), new Queen(PieceType.Queen,PieceColor.White), new Bishop(PieceType.Bishop,PieceColor.White), new Knight(PieceType.Knight,PieceColor.White), new Rook(PieceType.Rook,PieceColor.White) },
            };
        }
        #endregion

        #region Events
        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            if (pressRightMouseButton < 1)
            {
                castleButtonOne = (Button)sender;
                pressRightMouseButton++;
            }
            else
            {
                castleButtonTwo = (Button)sender;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pressLeftMouseButton == 0)
            {
                buttonClickOne = (Button)sender;
                SelectedIndicator(buttonClickOne);
                previousColumn = Grid.GetColumn(buttonClickOne) - 1;
                previousRow = Grid.GetRow(buttonClickOne);
                previousPiece = myBoard[previousRow, previousColumn];

                pressLeftMouseButton++;
            }

            else
            {
                buttonClickTwo = (Button)sender;
                nextColumn = Grid.GetColumn(buttonClickTwo) - 1;
                nextRow = Grid.GetRow(buttonClickTwo);
                nextPiece = myBoard[nextRow, nextColumn];

                validMove = Movement.ValidMoveChecker(validMove, previousPiece, nextPiece, previousColumn, previousRow, nextColumn, nextRow);

                if (validMove)
                {
                    turnCheck = TurnChecker(previousPiece);

                    if (turnCheck)
                    {
                        blockCheck = BlockChecker(previousColumn, previousRow, nextColumn, nextRow, previousPiece);

                        if (blockCheck)
                        {
                            castleCheck = CastlingChecker(previousPiece, myBoard[7, 0], myBoard[7, 7], myBoard[0, 0], myBoard[0, 7], previousColumn, nextColumn);

                            if (castleCheck)
                            {
                                enPassantCheck = EnPassantTakeChecker(previousPiece, previousColumn, previousRow, nextColumn, nextRow);

                                if (enPassantCheck)
                                {
                                    nextPiece.PieceType = previousPiece.PieceType;
                                    nextPiece.PieceColor = previousPiece.PieceColor;
                                    myBoard[nextRow, nextColumn].PieceType = previousPiece.PieceType;
                                    myBoard[nextRow, nextColumn].PieceColor = previousPiece.PieceColor;
                                    myBoard[nextRow, nextColumn].PieceMoveCounter = PieceMoveCounterFixer(myBoard[previousRow, previousColumn].PieceMoveCounter);

                                    PieceReplacer(nextPiece, buttonClickTwo);

                                    previousPiece.PieceType = PieceType.Free;
                                    previousPiece.PieceColor = PieceColor.None;
                                    myBoard[previousRow, previousColumn].PieceType = PieceType.Free;
                                    myBoard[previousRow, previousColumn].PieceColor = PieceColor.None;

                                    lastTurn = nextPiece;

                                    PieceReplacer(previousPiece, buttonClickOne);

                                    turnCounter++;

                                    TurnHelper(turnIndicatorBorder, turnCounter);

                                    MoveReseter();
                                }

                                else
                                {
                                    EnPassantMover();
                                }
                            }

                            else
                            {
                                CastleMover();
                            }
                        }

                        else
                        {
                            BlockedMover();
                        }
                    }

                    else
                    {
                        TurnMover();
                    }
                }

                else
                {
                    InvalidMover();
                }
            }
        }
        #endregion

        #region Pieces/Turn successed
        private void PieceReplacer(IPiece piece, Button pieceButton)
        {
            if (piece.PieceType == PieceType.Pawn)
            {
                if (piece.PieceColor == PieceColor.White)
                {
                    pieceButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(pawnImageWhite)),
                    };
                }
                else if (piece.PieceColor == PieceColor.Black)
                {
                    pieceButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(pawnImageBlack)),
                    };
                }
            }

            else if (piece.PieceType == PieceType.Rook)
            {
                if (piece.PieceColor == PieceColor.White)
                {
                    pieceButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(rookImageWhite)),
                    };
                }
                else if (piece.PieceColor == PieceColor.Black)
                {
                    pieceButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(rookImageBlack)),
                    };
                }
            }

            else if (piece.PieceType == PieceType.Bishop)
            {
                if (piece.PieceColor == PieceColor.White)
                {
                    pieceButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(bishopImageWhite)),
                    };
                }
                else if (piece.PieceColor == PieceColor.Black)
                {
                    pieceButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(bishopImageBlack)),
                    };
                }
            }

            else if (piece.PieceType == PieceType.Knight)
            {
                if (piece.PieceColor == PieceColor.White)
                {
                    pieceButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(knightImageWhite)),
                    };
                }
                else if (piece.PieceColor == PieceColor.Black)
                {
                    pieceButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(knightImageBlack)),
                    };
                }
            }

            else if (piece.PieceType == PieceType.Queen)
            {
                if (piece.PieceColor == PieceColor.White)
                {
                    pieceButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(queenImageWhite)),
                    };
                }
                else if (piece.PieceColor == PieceColor.Black)
                {
                    pieceButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(queenImageBlack)),
                    };
                }
            }

            else if (piece.PieceType == PieceType.King)
            {
                if (piece.PieceColor == PieceColor.White)
                {
                    pieceButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(kingImageWhite)),
                    };
                }
                else if (piece.PieceColor == PieceColor.Black)
                {
                    pieceButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(kingImageBlack)),
                    };
                }
            }

            else if (piece.PieceType == PieceType.Free)
            {
                pieceButton.Content = new Image { };
            }
        }

        private void MoveReseter()
        {
            pressLeftMouseButton = 0;
            pressRightMouseButton = 0;
            buttonClickOne.Background = Brushes.Transparent;
            buttonClickOne = null;
            buttonClickTwo = null;
            castleButtonOne = null;
            castleButtonTwo = null;
            blockCheck = true;

            previousColumn = 0;
            previousRow = 0;
            nextColumn = 0;
            nextRow = 0;
            placeholderColumn = 0;
            placeholderRow = 0;
        }
        #endregion

        #region Checkers
        private bool BlockChecker(int previousPieceColumn, int previousPieceRow, int nextPieceColumn, int nextPieceRow, IPiece piece)
        {

            placeholderRow = previousPieceRow - nextPieceRow;
            placeholderColumn = previousPieceColumn - nextPieceColumn;

            placeholderRow = PlaceholdersFixer(placeholderRow);
            placeholderColumn = PlaceholdersFixer(placeholderColumn);

            if (piece.PieceType == PieceType.Knight)
            {
                return true;
            }

            if (placeholderRow == 0)
            {
                for (int i = placeholderColumn; i != 0; i = IncrementWorker(i))
                {

                    if (myBoard[previousPieceRow, previousPieceColumn - i].PieceType != PieceType.Free)
                    {
                        blockCheck = false;
                        break;
                    }

                    else
                    {
                        blockCheck = true;
                    }
                }
            }

            else if (placeholderColumn == 0)
            {
                for (int i = placeholderRow; i != 0; i = IncrementWorker(i))
                {

                    if (myBoard[previousPieceRow - i, previousPieceColumn].PieceType != PieceType.Free)
                    {
                        blockCheck = false;
                        break;
                    }

                    else
                    {
                        blockCheck = true;
                    }
                }
            }

            else
            {
                int j = placeholderColumn;
                for (int i = placeholderRow; i != 0; i = IncrementWorker(i))
                {
                    if (myBoard[previousPieceRow - i, previousPieceColumn - j].PieceType != PieceType.Free)
                    {
                        blockCheck = false;
                        break;
                    }

                    else
                    {
                        blockCheck = true;
                        j = IncrementWorker(j);
                    }
                }
            }

            return blockCheck;
        }

        private bool TurnChecker(IPiece piece)
        {
            if (turnCounter % 2 != 0 && piece.PieceColor == PieceColor.White)
            {
                return true;
            }

            else if (turnCounter % 2 == 0 && piece.PieceColor == PieceColor.Black)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        #endregion

        #region Invalid moves messengers
        private void InvalidMover()
        {
            MessageBox.Show("Invalid move. Submit a legit move only!.", "Invalid move.", MessageBoxButton.OK);

            MoveReseter();
        }

        private void BlockedMover()
        {
            MessageBox.Show("You submitted a illegal move. Your piece is blocked!", "Invalid move", MessageBoxButton.OK);

            MoveReseter();
        }

        private void TurnMover()
        {
            MessageBox.Show("You submitted a illegal move. It is not your turn!", "Invalid move", MessageBoxButton.OK);

            MoveReseter();
        }

        private void CastleMover()
        {
            MessageBox.Show("You submitted a illegal move. Castling in this form is not allowed anymore!", "Invalid move", MessageBoxButton.OK);

            MoveReseter();
        }

        private void EnPassantMover()
        {
            MessageBox.Show("You submitted a illegal move. En passant in this form is not allowed!", "Invalid move", MessageBoxButton.OK);

            MoveReseter();
        }
        #endregion

        #region Grid numbering fixers
        private int PlaceholdersFixer(int model)
        {
            if (model > 0)
            {
                model = model - 1;
            }

            else if (model < 0)
            {
                model = model + 1;
            }

            return model;
        }

        private int IncrementWorker(int model)
        {
            if (model > 0)
            {
                model--;
            }

            else if (model < 0)
            {
                model++;
            }

            return model;
        }
        #endregion 

        private void SelectedIndicator(Button model)
        {
            model.Background = Brushes.Yellow;
        }

        private void TurnHelper(Border modelBorder, int modelCounter)
        {
            turnIndicatorBorder = GridBuilder.TurnIndicator(modelBorder, modelCounter);
        }

        //maybe re-do CastleChecker with searching function + loop with is
        private bool CastlingChecker(IPiece piece, IPiece pieceWhiteRookLeft, IPiece pieceWhiteRookRight, IPiece pieceBlackRookLeft, IPiece pieceBlackRookRight, int piecePreviousColumn, int pieceNextColumn)
        {
            if (piece.PieceType == PieceType.King && (previousColumn == nextColumn + 2 || previousColumn == nextColumn - 2))
            {
                if (piece.PieceColor == PieceColor.White)
                {
                    if (pieceWhiteRookLeft.PieceType == PieceType.Rook && pieceWhiteRookLeft.PieceMoveCounter == 0 && piecePreviousColumn == pieceNextColumn + 2)
                    {
                        if (castleButtonOne != null && castleButtonTwo != null && Grid.GetColumn(castleButtonTwo) == 3 && Grid.GetRow(castleButtonTwo) == 7)
                        {
                            myBoard[7, 0].PieceColor = PieceColor.None;
                            myBoard[7, 0].PieceType = PieceType.Free;
                            myBoard[7, 2].PieceType = PieceType.Rook;
                            myBoard[7, 2].PieceColor = PieceColor.White;
                            PieceReplacer(myBoard[7, 2], castleButtonTwo);
                            PieceReplacer(myBoard[7, 0], castleButtonOne);

                            castleCheck = true;
                        }

                        else
                        {
                            castleCheck = false;
                        }
                    }

                    else if (pieceWhiteRookRight.PieceType == PieceType.Rook && pieceWhiteRookRight.PieceMoveCounter == 0 && piecePreviousColumn == pieceNextColumn - 2)
                    {
                        if (castleButtonOne != null && castleButtonTwo != null && myBoard[7, 6].PieceType == PieceType.Free && Grid.GetColumn(castleButtonTwo) == 5 && Grid.GetRow(castleButtonTwo) == 7)
                        {
                            myBoard[7, 7].PieceColor = PieceColor.None;
                            myBoard[7, 7].PieceType = PieceType.Free;
                            myBoard[7, 4].PieceType = PieceType.Rook;
                            myBoard[7, 4].PieceColor = PieceColor.White;
                            PieceReplacer(myBoard[7, 4], castleButtonTwo);
                            PieceReplacer(myBoard[7, 7], castleButtonOne);

                            castleCheck = true;
                        }

                        else
                        {
                            castleCheck = false;
                        }
                    }

                    else
                    {
                        castleCheck = false;
                    }
                }

                else if (piece.PieceColor == PieceColor.Black)
                {
                    if (pieceBlackRookLeft.PieceType == PieceType.Rook && pieceBlackRookLeft.PieceMoveCounter == 0 && piecePreviousColumn == pieceNextColumn + 2)
                    {
                        if (castleButtonOne != null && castleButtonTwo != null && Grid.GetColumn(castleButtonTwo) == 3 && Grid.GetRow(castleButtonTwo) == 0)
                        {
                            myBoard[0, 0].PieceColor = PieceColor.None;
                            myBoard[0, 0].PieceType = PieceType.Free;
                            myBoard[0, 2].PieceType = PieceType.Rook;
                            myBoard[0, 2].PieceColor = PieceColor.Black;
                            PieceReplacer(myBoard[0, 2], castleButtonTwo);
                            PieceReplacer(myBoard[0, 0], castleButtonOne);

                            castleCheck = true;
                        }
                        else
                        {
                            castleCheck = false;
                        }
                    }

                    else if (pieceBlackRookRight.PieceType == PieceType.Rook && pieceBlackRookRight.PieceMoveCounter == 0 && piecePreviousColumn == pieceNextColumn - 2)
                    {
                        if (castleButtonOne != null && castleButtonTwo != null && myBoard[0, 6].PieceType == PieceType.Free && Grid.GetColumn(castleButtonTwo) == 5 && Grid.GetRow(castleButtonTwo) == 0)
                        {
                            myBoard[0, 7].PieceColor = PieceColor.None;
                            myBoard[0, 7].PieceType = PieceType.Free;
                            myBoard[0, 4].PieceType = PieceType.Rook;
                            myBoard[0, 4].PieceColor = PieceColor.Black;
                            PieceReplacer(myBoard[0, 4], castleButtonTwo);
                            PieceReplacer(myBoard[0, 7], castleButtonOne);

                            castleCheck = true;
                        }

                        else
                        {
                            castleCheck = false;
                        }
                    }

                    else
                    {
                        castleCheck = false;
                    }
                }
            }

            else
            {
                castleCheck = true;
            }

            return castleCheck;
        }

        private bool EnPassantTakeChecker(IPiece piece, int piecePreviousColumn, int piecePreviousRow, int pieceNextColumn, int pieceNextRow)
        {
            if (piece.PieceType == PieceType.Pawn && ((piecePreviousColumn == pieceNextColumn + 1) || (piecePreviousColumn == pieceNextColumn - 1)))
            {
                if (piece.PieceColor == PieceColor.White && piecePreviousRow == pieceNextRow + 1 && myBoard[nextRow + 1,nextColumn] == lastTurn && lastTurn.PieceMoveCounter == 1 && lastTurn.PieceType == PieceType.Pawn)
                {
                    myBoard[nextRow + 1, nextColumn].PieceColor = PieceColor.None;
                    myBoard[nextRow + 1, nextColumn].PieceType = PieceType.Free;

                    IPiece enPassantDead = myBoard[nextRow + 1, nextColumn];
                    
                    listElements = FindByCell(MainGrid, nextRow + 1, pieceNextColumn + 1);

                    SpecialMoveReplacer(listElements, enPassantDead);

                    return true;
                }

                else if (piece.PieceColor == PieceColor.Black && piecePreviousRow == pieceNextRow - 1 && myBoard[nextRow - 1, nextColumn] == lastTurn && lastTurn.PieceMoveCounter == 1 && lastTurn.PieceType == PieceType.Pawn)
                {
                    myBoard[nextRow - 1, nextColumn].PieceColor = PieceColor.None;
                    myBoard[nextRow - 1, nextColumn].PieceType = PieceType.Free;

                    IPiece enPassantDead = myBoard[nextRow - 1, nextColumn];

                    listElements = FindByCell(MainGrid, nextRow - 1, pieceNextColumn + 1);

                    SpecialMoveReplacer(listElements, enPassantDead);

                    return true;
                }

                else
                {
                    return false;
                }
            }

            else
            {
                return true;
            }            
        }

        private void LastTurnFirstRoundFixer()
        {
            lastTurn = myBoard[0, 4];
        }

        private int PieceMoveCounterFixer(int modelIntPrevious)
        {
            return modelIntPrevious + 1;
        }

        private IEnumerable<UIElement> FindByCell(Grid g, int row, int col)
        {
            var childs = g.Children.Cast<UIElement>();
            var result = childs.Where(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == col);

            return result;
        }

        private void SpecialMoveReplacer(IEnumerable<UIElement> listModel, IPiece piece)
        {
            foreach (UIElement item in listModel)
            {
                if (item is Button button)
                {
                    PieceReplacer(piece, button);
                }
            }
        }
    }
}

