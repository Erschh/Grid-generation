using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Avalonia.Media;
using Grid_generation.ViewModels;

namespace Grid_generation.Views;

public partial class MainWindow : Window
{
    int rows, columns;
    private IBrush _openColor=Brushes.Beige;
    private IBrush _closeColor=Brushes.Black;
    public MainWindow()
    {
        InitializeComponent();
        InitGrid();
    }

    public void GetGrid(object sender, RoutedEventArgs e)
    {
        if(check.IsChecked == true)
        (DataContext as MainWindowViewModel).GenerateMapWithDensity();
        else
        (DataContext as MainWindowViewModel).GenerateMap();

        InitGrid();
    }

    public void ShowDensity(object sender, RoutedEventArgs e)
    {
        if(check.IsChecked==true) densityNum.IsVisible = true;
        else densityNum.IsVisible = false;
    }

    private void InitGrid()
    {
        MapGrid.Children.Clear();
        MapGrid.RowDefinitions.Clear();
        MapGrid.ColumnDefinitions.Clear();

        int.TryParse(heightNum.Text, out rows);
        int.TryParse(widthNum.Text, out columns);

        MapGrid.Width = columns*10;
        MapGrid.Height = rows*10;

        for(var i=0; i<rows; i++)
        {
            /*MapGrid.RowDefinitions.Add(new RowDefinition(GridLength.Star));
            MapGrid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));*/

            MapGrid.RowDefinitions.Add(new RowDefinition(GridLength.Star));

            for(var j=0; j<columns; j++)
            {
                if (i == 0) MapGrid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));

                var gridPoint=new Rectangle
                {
                    Width = 10,
                    Height = 10
                };
                
                gridPoint.Fill=(DataContext as MainWindowViewModel).GetNodeValue(i,j)? _openColor:_closeColor;

                MapGrid.Children.Add(gridPoint);
                Grid.SetRow(gridPoint, i);
                Grid.SetColumn(gridPoint, j);
            }
        }

        MapGrid.VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center;
        MapGrid.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
        
    }
}