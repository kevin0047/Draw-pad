using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Draw_pad
{
    public partial class MainWindow : Window
    {
        private bool isDrawing;
        private Polyline currentLine;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                isDrawing = true;
                currentLine = new Polyline
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };
                paintCanvas.Children.Add(currentLine);
                Point point = e.GetPosition(paintCanvas);
                currentLine.Points.Add(point);
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Point point = e.GetPosition(paintCanvas);
                currentLine.Points.Add(point);
            }
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDrawing = false;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            paintCanvas.Children.Clear();
        }
    }
}
