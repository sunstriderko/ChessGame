using System;
using System.Windows;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace ChessGame.Builders
{
    public static class GridBuilder
    {
        public static Grid GridDeployer(Grid model)
        {
            int height = 100;
            int width = 100;
            SolidColorBrush stroke = Brushes.Black;
            SolidColorBrush fillColor;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if ((i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0))
                    {
                        fillColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF0C587"));
                    }
                    else
                    {
                        fillColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF553208"));
                    }
                    Rectangle rectangle = new Rectangle()
                    {
                        Width = width,
                        Height = height,
                        Stroke = stroke,
                        StrokeThickness = 0,
                        Fill = fillColor,
                        Name = $"pos{i}{j}",

                    };

                   
                    model.Children.Add(rectangle);
                    Grid.SetColumn(rectangle, j);
                    Grid.SetRow(rectangle, i);
                }
            }
            return model;
        }
    }
}
