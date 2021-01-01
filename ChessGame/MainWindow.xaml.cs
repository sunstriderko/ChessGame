using System;
using System.Windows;
using ChessGame.Builders;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ChessLibrary.Models;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constants (Pieces images)
        const string pawnImageBlack = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_black_pawn_T.png";
        const string rookImageBlack = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_black_rook_T.png";
        const string bishopImageBlack = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_black_bishop_T.png";
        const string knightImageBlack = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_black_knight_T.png";
        const string queenImageBlack = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_black_queen_T.png";
        const string kingImageBlack = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_black_king_T.png";

        const string pawnImageWhite = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_white_pawn_T.png";
        const string rookImageWhite = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_white_rook_T.png";
        const string bishopImageWhite = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_white_bishop_T.png";
        const string knightImageWhite = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_white_knight_T.png";
        const string queenImageWhite = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_white_queen_T.png";
        const string kingImageWhite = "https://wpclipart.com/dl.php?img=/recreation/games/chess/chess_set_1/chess_piece_white_king_T.png";
        #endregion

        #region Variables
        Piece[,] myBoard = new Piece[,] { };
        Button buttonClickOne;
        Button buttonClickTwo;
        Button castleButtonOne;
        Button castleButtonTwo;
        List<UIElement> listElements;
        int pressLeftMouseButton;
        int pressRightMouseButton;
        int previousColumn;
        int previousRow;
        int nextColumn;
        int nextRow;
        Piece previousPiece;
        Piece nextPiece;
        Piece lastTurn;
        bool validMove;
        bool blockCheck = true;
        int placeholderColumn;
        int placeholderRow;
        int turnCounter = 1;
        bool turnCheck;
        bool castleCheck;
        bool enPassantCheck;
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
        public void PiecesDeployer()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button but = new Button();
                    but.Height = 100;
                    but.Width = 100;

                    if (myBoard[i, j].PieceType == PieceTypes.Pawn)
                    {
                        if (myBoard[i, j].PieceColor == PieceColors.White)
                        {
                            but.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(pawnImageWhite)),
                            };
                        }
                        else if (myBoard[i, j].PieceColor == PieceColors.Black)
                        {
                            but.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(pawnImageBlack)),
                            };
                        }
                    }

                    else if (myBoard[i, j].PieceType == PieceTypes.Rook)
                    {
                        if (myBoard[i, j].PieceColor == PieceColors.White)
                        {
                            but.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(rookImageWhite)),
                            };
                        }
                        else if (myBoard[i, j].PieceColor == PieceColors.Black)
                        {
                            but.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(rookImageBlack)),
                            };
                        }
                    }

                    else if (myBoard[i, j].PieceType == PieceTypes.Bishop)
                    {
                        if (myBoard[i, j].PieceColor == PieceColors.White)
                        {
                            but.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(bishopImageWhite)),
                            };
                        }
                        else if (myBoard[i, j].PieceColor == PieceColors.Black)
                        {
                            but.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(bishopImageBlack)),
                            };
                        }
                    }

                    else if (myBoard[i, j].PieceType == PieceTypes.Knight)
                    {
                        if (myBoard[i, j].PieceColor == PieceColors.White)
                        {
                            but.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(knightImageWhite)),
                            };
                        }
                        else if (myBoard[i, j].PieceColor == PieceColors.Black)
                        {
                            but.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(knightImageBlack)),
                            };
                        }
                    }

                    else if (myBoard[i, j].PieceType == PieceTypes.Queen)
                    {
                        if (myBoard[i, j].PieceColor == PieceColors.White)
                        {
                            but.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(queenImageWhite)),
                            };
                        }
                        else if (myBoard[i, j].PieceColor == PieceColors.Black)
                        {
                            but.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(queenImageBlack)),
                            };
                        }
                    }

                    else if (myBoard[i, j].PieceType == PieceTypes.King)
                    {
                        if (myBoard[i, j].PieceColor == PieceColors.White)
                        {
                            but.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(kingImageWhite)),
                            };
                        }
                        else if (myBoard[i, j].PieceColor == PieceColors.Black)
                        {
                            but.Content = new Image
                            {
                                Source = new BitmapImage(new Uri(kingImageBlack)),
                            };
                        }
                    }

                    but.Background = Brushes.Transparent;
                    but.Click += new RoutedEventHandler(Button_Click);
                    but.MouseRightButtonUp += new MouseButtonEventHandler(RightButton_Click);
                    MainGrid.Children.Add(but);
                    Grid.SetColumn(but, j + 1);
                    Grid.SetRow(but, i);
                }
            }
        }

        public void VirtualBoardDeployer()
        {
            myBoard = new Piece[,] {
                {new Piece(PieceTypes.Rook,PieceColors.Black),new Piece(PieceTypes.Knight,PieceColors.Black), new Piece(PieceTypes.Bishop,PieceColors.Black),new Piece(PieceTypes.King,PieceColors.Black), new Piece(PieceTypes.Queen,PieceColors.Black), new Piece(PieceTypes.Bishop,PieceColors.Black), new Piece(PieceTypes.Knight,PieceColors.Black), new Piece(PieceTypes.Rook,PieceColors.Black) },
                {new Piece(PieceTypes.Pawn,PieceColors.Black), new Piece(PieceTypes.Pawn,PieceColors.Black), new Piece(PieceTypes.Pawn,PieceColors.Black), new Piece(PieceTypes.Pawn,PieceColors.Black), new Piece(PieceTypes.Pawn,PieceColors.Black), new Piece(PieceTypes.Pawn,PieceColors.Black), new Piece(PieceTypes.Pawn,PieceColors.Black), new Piece(PieceTypes.Pawn,PieceColors.Black) },
                {new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None) },
                {new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None) },
                {new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None) },
                {new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None) },
                {new Piece(PieceTypes.Pawn,PieceColors.White), new Piece(PieceTypes.Pawn,PieceColors.White), new Piece(PieceTypes.Pawn,PieceColors.White), new Piece(PieceTypes.Pawn,PieceColors.White), new Piece(PieceTypes.Pawn,PieceColors.White), new Piece(PieceTypes.Pawn,PieceColors.White), new Piece(PieceTypes.Pawn,PieceColors.White), new Piece(PieceTypes.Pawn,PieceColors.White) },
                {new Piece(PieceTypes.Rook,PieceColors.White),new Piece(PieceTypes.Knight,PieceColors.White), new Piece(PieceTypes.Bishop,PieceColors.White),new Piece(PieceTypes.King,PieceColors.White), new Piece(PieceTypes.Queen,PieceColors.White), new Piece(PieceTypes.Bishop,PieceColors.White), new Piece(PieceTypes.Knight,PieceColors.White), new Piece(PieceTypes.Rook,PieceColors.White) },
            };
        }
        #endregion

        #region Events
        public void RightButton_Click(object sender, RoutedEventArgs e)
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

        public void Button_Click(object sender, RoutedEventArgs e)
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

                Movement mov = new Movement();

                validMove = mov.ValidMoveChecker(validMove, previousPiece, nextPiece, previousColumn, previousRow, nextColumn, nextRow);

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

                                    previousPiece.PieceType = PieceTypes.Free;
                                    previousPiece.PieceColor = PieceColors.None;
                                    myBoard[previousRow, previousColumn].PieceType = PieceTypes.Free;
                                    myBoard[previousRow, previousColumn].PieceColor = PieceColors.None;

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
        public void PieceReplacer(Piece model, Button modelButton)
        {
            if (model.PieceType == PieceTypes.Pawn)
            {
                if (model.PieceColor == PieceColors.White)
                {
                    modelButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(pawnImageWhite)),
                    };
                }
                else if (model.PieceColor == PieceColors.Black)
                {
                    modelButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(pawnImageBlack)),
                    };
                }
            }

            else if (model.PieceType == PieceTypes.Rook)
            {
                if (model.PieceColor == PieceColors.White)
                {
                    modelButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(rookImageWhite)),
                    };
                }
                else if (model.PieceColor == PieceColors.Black)
                {
                    modelButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(rookImageBlack)),
                    };
                }
            }

            else if (model.PieceType == PieceTypes.Bishop)
            {
                if (model.PieceColor == PieceColors.White)
                {
                    modelButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(bishopImageWhite)),
                    };
                }
                else if (model.PieceColor == PieceColors.Black)
                {
                    modelButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(bishopImageBlack)),
                    };
                }
            }

            else if (model.PieceType == PieceTypes.Knight)
            {
                if (model.PieceColor == PieceColors.White)
                {
                    modelButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(knightImageWhite)),
                    };
                }
                else if (model.PieceColor == PieceColors.Black)
                {
                    modelButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(knightImageBlack)),
                    };
                }
            }

            else if (model.PieceType == PieceTypes.Queen)
            {
                if (model.PieceColor == PieceColors.White)
                {
                    modelButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(queenImageWhite)),
                    };
                }
                else if (model.PieceColor == PieceColors.Black)
                {
                    modelButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(queenImageBlack)),
                    };
                }
            }

            else if (model.PieceType == PieceTypes.King)
            {
                if (model.PieceColor == PieceColors.White)
                {
                    modelButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(kingImageWhite)),
                    };
                }
                else if (model.PieceColor == PieceColors.Black)
                {
                    modelButton.Content = new Image
                    {
                        Source = new BitmapImage(new Uri(kingImageBlack)),
                    };
                }
            }

            else if (model.PieceType == PieceTypes.Free)
            {
                modelButton.Content = new Image { };
            }
        }

        public void MoveReseter()
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
        public bool BlockChecker(int previousModelColumn, int previousModelRow, int nextModelColumn, int nextModelRow, Piece modelPiece)
        {

            placeholderRow = previousModelRow - nextModelRow;
            placeholderColumn = previousModelColumn - nextModelColumn;

            placeholderRow = PlaceholdersFixer(placeholderRow);
            placeholderColumn = PlaceholdersFixer(placeholderColumn);

            if (modelPiece.PieceType == PieceTypes.Knight)
            {
                return true;
            }

            if (placeholderRow == 0)
            {
                for (int i = placeholderColumn; i != 0; i = IncrementWorker(i))
                {

                    if (myBoard[previousModelRow, previousModelColumn - i].PieceType != PieceTypes.Free)
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

                    if (myBoard[previousModelRow - i, previousModelColumn].PieceType != PieceTypes.Free)
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
                    if (myBoard[previousModelRow - i, previousModelColumn - j].PieceType != PieceTypes.Free)
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

        public bool TurnChecker(Piece model)
        {
            if (turnCounter % 2 != 0 && model.PieceColor == PieceColors.White)
            {
                return true;
            }

            else if (turnCounter % 2 == 0 && model.PieceColor == PieceColors.Black)
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
        public void InvalidMover()
        {
            MessageBox.Show("Invalid move. Submit a legit move only!.", "Invalid move.", MessageBoxButton.OK);

            MoveReseter();
        }

        public void BlockedMover()
        {
            MessageBox.Show("You submitted a illegal move. Your piece is blocked!", "Invalid move", MessageBoxButton.OK);

            MoveReseter();
        }

        public void TurnMover()
        {
            MessageBox.Show("You submitted a illegal move. It is not your turn!", "Invalid move", MessageBoxButton.OK);

            MoveReseter();
        }

        public void CastleMover()
        {
            MessageBox.Show("You submitted a illegal move. Castling in this form is not allowed anymore!", "Invalid move", MessageBoxButton.OK);

            MoveReseter();
        }

        public void EnPassantMover()
        {
            MessageBox.Show("You submitted a illegal move. En passant in this form is not allowed!", "Invalid move", MessageBoxButton.OK);

            MoveReseter();
        }
        #endregion

        #region Grid numbering fixers
        public int PlaceholdersFixer(int model)
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

        public int IncrementWorker(int model)
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

        public void SelectedIndicator(Button model)
        {
            model.Background = Brushes.Yellow;
        }

        public void TurnHelper(Border modelBorder, int modelCounter)
        {
            turnIndicatorBorder = GridBuilder.TurnIndicator(modelBorder, modelCounter);
        }

        //maybe re-do CastleChecker with searching function + loop with is
        public bool CastlingChecker(Piece model, Piece modelWhiteRookLeft, Piece modelWhiteRookRight, Piece modelBlackRookLeft, Piece modelBlackRookRight, int modelPreviousColumn, int modelNextColumn)
        {
            if (model.PieceType == PieceTypes.King && (previousColumn == nextColumn + 2 || previousColumn == nextColumn - 2))
            {
                if (model.PieceColor == PieceColors.White)
                {
                    if (modelWhiteRookLeft.PieceType == PieceTypes.Rook && modelWhiteRookLeft.PieceMoveCounter == 0 && modelPreviousColumn == modelNextColumn + 2)
                    {
                        if (castleButtonOne != null && castleButtonTwo != null && Grid.GetColumn(castleButtonTwo) == 3 && Grid.GetRow(castleButtonTwo) == 7)
                        {
                            myBoard[7, 0].PieceColor = PieceColors.None;
                            myBoard[7, 0].PieceType = PieceTypes.Free;
                            myBoard[7, 2].PieceType = PieceTypes.Rook;
                            myBoard[7, 2].PieceColor = PieceColors.White;
                            PieceReplacer(myBoard[7, 2], castleButtonTwo);
                            PieceReplacer(myBoard[7, 0], castleButtonOne);

                            castleCheck = true;
                        }

                        else
                        {
                            castleCheck = false;
                        }
                    }

                    else if (modelWhiteRookRight.PieceType == PieceTypes.Rook && modelWhiteRookRight.PieceMoveCounter == 0 && modelPreviousColumn == modelNextColumn - 2)
                    {
                        if (castleButtonOne != null && castleButtonTwo != null && myBoard[7, 6].PieceType == PieceTypes.Free && Grid.GetColumn(castleButtonTwo) == 5 && Grid.GetRow(castleButtonTwo) == 7)
                        {
                            myBoard[7, 7].PieceColor = PieceColors.None;
                            myBoard[7, 7].PieceType = PieceTypes.Free;
                            myBoard[7, 4].PieceType = PieceTypes.Rook;
                            myBoard[7, 4].PieceColor = PieceColors.White;
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

                else if (model.PieceColor == PieceColors.Black)
                {
                    if (modelBlackRookLeft.PieceType == PieceTypes.Rook && modelBlackRookLeft.PieceMoveCounter == 0 && modelPreviousColumn == modelNextColumn + 2)
                    {
                        if (castleButtonOne != null && castleButtonTwo != null && Grid.GetColumn(castleButtonTwo) == 3 && Grid.GetRow(castleButtonTwo) == 0)
                        {
                            myBoard[0, 0].PieceColor = PieceColors.None;
                            myBoard[0, 0].PieceType = PieceTypes.Free;
                            myBoard[0, 2].PieceType = PieceTypes.Rook;
                            myBoard[0, 2].PieceColor = PieceColors.Black;
                            PieceReplacer(myBoard[0, 2], castleButtonTwo);
                            PieceReplacer(myBoard[0, 0], castleButtonOne);

                            castleCheck = true;
                        }
                        else
                        {
                            castleCheck = false;
                        }
                    }

                    else if (modelBlackRookRight.PieceType == PieceTypes.Rook && modelBlackRookRight.PieceMoveCounter == 0 && modelPreviousColumn == modelNextColumn - 2)
                    {
                        if (castleButtonOne != null && castleButtonTwo != null && myBoard[0, 6].PieceType == PieceTypes.Free && Grid.GetColumn(castleButtonTwo) == 5 && Grid.GetRow(castleButtonTwo) == 0)
                        {
                            myBoard[0, 7].PieceColor = PieceColors.None;
                            myBoard[0, 7].PieceType = PieceTypes.Free;
                            myBoard[0, 4].PieceType = PieceTypes.Rook;
                            myBoard[0, 4].PieceColor = PieceColors.Black;
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

        public bool EnPassantTakeChecker(Piece model, int modelPreviousColumn, int modelPreviousRow, int modelNextColumn, int modelNextRow)
        {
            if (model.PieceType == PieceTypes.Pawn && ((modelPreviousColumn == modelNextColumn + 1) || (modelPreviousColumn == modelNextColumn - 1)))
            {
                if (model.PieceColor == PieceColors.White && modelPreviousRow == modelNextRow + 1 && myBoard[nextRow + 1,nextColumn] == lastTurn && lastTurn.PieceMoveCounter == 1 && lastTurn.PieceType == PieceTypes.Pawn)
                {
                    myBoard[nextRow + 1, nextColumn].PieceColor = PieceColors.None;
                    myBoard[nextRow + 1, nextColumn].PieceType = PieceTypes.Free;

                    Piece enPassantDead = myBoard[nextRow + 1, nextColumn];
                    
                    listElements = FindByCell(MainGrid, nextRow + 1, modelNextColumn + 1);

                    SpecialMoveReplacer(listElements, enPassantDead);

                    return true;
                }

                else if (model.PieceColor == PieceColors.Black && modelPreviousRow == modelNextRow - 1 && myBoard[nextRow - 1, nextColumn] == lastTurn && lastTurn.PieceMoveCounter == 1 && lastTurn.PieceType == PieceTypes.Pawn)
                {
                    myBoard[nextRow - 1, nextColumn].PieceColor = PieceColors.None;
                    myBoard[nextRow - 1, nextColumn].PieceType = PieceTypes.Free;

                    Piece enPassantDead = myBoard[nextRow - 1, nextColumn];

                    listElements = FindByCell(MainGrid, nextRow - 1, modelNextColumn + 1);

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

        public void LastTurnFirstRoundFixer()
        {
            lastTurn = myBoard[0, 4];
        }

        public int PieceMoveCounterFixer(int modelIntPrevious)
        {
            return modelIntPrevious + 1;
        }

        public List<UIElement> FindByCell(Grid g, int row, int col)
        {
            List<UIElement> childs = g.Children.Cast<UIElement>().ToList();
            List<UIElement> result = childs.Where(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == col).ToList();

            return result;
        }

         public void SpecialMoveReplacer(List<UIElement> listModel, Piece model)
        {
            foreach (UIElement item in listModel)
            {
                if (item is Button btn)
                {
                    PieceReplacer(model, btn);
                }
            }
        }
    }
}

