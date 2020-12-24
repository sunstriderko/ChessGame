using System;
using System.Windows;
using ChessGame.Builders;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ChessLibrary.Models;
using ChessLibrary.Interfaces;

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
        int pressLeftMouseButton;
        int previousColumn;
        int previousRow;
        int nextColumn;
        int nextRow;
        Piece previousPiece;
        Piece nextPiece;
        bool validMove;
        bool blockCheck = true;
        int placeholderColumn;
        int placeholderRow;
        int turnCounter = 1;
        bool turnCheck;
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            GridBuilder.GridDeployer(MainGrid);

            myBoard = new Piece[,] {
                {new Piece(PieceTypes.Rook,PieceColors.White),new Piece(PieceTypes.Knight,PieceColors.White), new Piece(PieceTypes.Bishop,PieceColors.White),new Piece(PieceTypes.King,PieceColors.White), new Piece(PieceTypes.Queen,PieceColors.White), new Piece(PieceTypes.Bishop,PieceColors.White), new Piece(PieceTypes.Knight,PieceColors.White), new Piece(PieceTypes.Rook,PieceColors.White) },
                {new Piece(PieceTypes.Pawn,PieceColors.White), new Piece(PieceTypes.Pawn,PieceColors.White), new Piece(PieceTypes.Pawn,PieceColors.White), new Piece(PieceTypes.Pawn,PieceColors.White), new Piece(PieceTypes.Pawn,PieceColors.White), new Piece(PieceTypes.Pawn,PieceColors.White), new Piece(PieceTypes.Pawn,PieceColors.White), new Piece(PieceTypes.Pawn,PieceColors.White) },
                {new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None) },
                {new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None) },
                {new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None) },
                {new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None), new Piece(PieceTypes.Free,PieceColors.None) },
                {new Piece(PieceTypes.Pawn,PieceColors.Black), new Piece(PieceTypes.Pawn,PieceColors.Black), new Piece(PieceTypes.Pawn,PieceColors.Black), new Piece(PieceTypes.Pawn,PieceColors.Black), new Piece(PieceTypes.Pawn,PieceColors.Black), new Piece(PieceTypes.Pawn,PieceColors.Black), new Piece(PieceTypes.Pawn,PieceColors.Black), new Piece(PieceTypes.Pawn,PieceColors.Black) },
                {new Piece(PieceTypes.Rook,PieceColors.Black),new Piece(PieceTypes.Knight,PieceColors.Black), new Piece(PieceTypes.Bishop,PieceColors.Black),new Piece(PieceTypes.King,PieceColors.Black), new Piece(PieceTypes.Queen,PieceColors.Black), new Piece(PieceTypes.Bishop,PieceColors.Black), new Piece(PieceTypes.Knight,PieceColors.Black), new Piece(PieceTypes.Rook,PieceColors.Black) },
            };

            BoardCreator();
        }

        #region Board
        public void BoardCreator()
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
                    MainGrid.Children.Add(but);
                    Grid.SetColumn(but, j + 1);
                    Grid.SetRow(but, i);
                }
            }

        }
        #endregion

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pressLeftMouseButton == 0)
            {
                buttonClickOne = (Button)sender;
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
                            nextPiece.PieceType = previousPiece.PieceType;
                            nextPiece.PieceColor = previousPiece.PieceColor;
                            myBoard[nextRow, nextColumn].PieceType = previousPiece.PieceType;
                            myBoard[nextRow, nextColumn].PieceColor = previousPiece.PieceColor;

                            PieceReplacer(nextPiece, buttonClickTwo);

                            previousPiece.PieceType = PieceTypes.Free;
                            previousPiece.PieceColor = PieceColors.None;
                            myBoard[previousRow, previousColumn].PieceType = PieceTypes.Free;
                            myBoard[previousRow, previousColumn].PieceColor = PieceColors.None;

                            PieceReplacer(previousPiece, buttonClickOne);

                            turnCounter++;

                            MoveReseter();
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
            buttonClickOne = null;
            buttonClickTwo = null;
            blockCheck = true;

            previousColumn = 0;
            previousRow= 0;
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

            if(modelPiece.PieceType == PieceTypes.Knight)
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
    }
}

