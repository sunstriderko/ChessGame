using System;
using System.Windows;
using ChessGame.Builders;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ChessLibrary.Models;
using System.IO;
using System.Drawing.Imaging;

namespace ChessGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        Piece[,] myBoard = new Piece[,] { };
        Button buttonClickOne;
        Button buttonClickTwo;
        int pressLeftMouseButton;
        int currentColumn;
        int currentRow;
        Piece previousPiece;
        Piece nextPiece;

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

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pressLeftMouseButton == 0)
            {
                buttonClickOne = (Button)sender;

                currentColumn = Grid.GetColumn(buttonClickOne);
                currentRow = Grid.GetRow(buttonClickOne);
                previousPiece = myBoard[currentRow, currentColumn - 1];

                pressLeftMouseButton++;
            }

            else
            {
                buttonClickTwo = (Button)sender;

                currentColumn = Grid.GetColumn(buttonClickTwo);
                currentRow = Grid.GetRow(buttonClickTwo);

                nextPiece = myBoard[currentRow, currentColumn - 1];

                nextPiece.PieceType = previousPiece.PieceType;
                nextPiece.PieceColor = previousPiece.PieceColor;

                PieceReplacer(nextPiece, buttonClickTwo);

                previousPiece.PieceType = PieceTypes.Free;
                previousPiece.PieceColor = PieceColors.None;

                PieceReplacer(previousPiece, buttonClickOne);

                MoveReseter();
            }
        }

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
        }
    }
}

