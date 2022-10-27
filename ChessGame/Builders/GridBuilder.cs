namespace ChessGame.Builders
{
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;

    public static class GridBuilder
    {
        private readonly static int height = 100;
        private readonly static int width = 100;

        public static Grid GridDeployer(Grid model)
        {
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

        public static Border TurnIndicator(Border model, int modelTurnCounter)
        {
            if (modelTurnCounter % 2 == 0)
            {
                model.Background = Brushes.Black;
            }
            else
            {
                model.Background = Brushes.White;
            }

            return model;
        }
    }
}
