using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Draw_pad
{
    public partial class MainWindow : Window
    {
        private bool isDrawing; 
        private string whatPen = "pen";
        private Polyline currentLine; // 타입 뒤에 ?을 붙이면 널값을 가질수 있음을 나타냄

        public MainWindow()
        {
            InitializeComponent();
            currentLine = new Polyline();//널값으로 인한 경고 방지
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                isDrawing = true;
                currentLine = new Polyline //선
                {
                    StrokeThickness = 2//strokethickness 선의 두께 ;
                };
                if (whatPen=="pen")
                {
                    currentLine.Stroke = Brushes.Black;
                }
                else
                {
                    currentLine. Stroke = Brushes.White;
                }

                
                    
                    paintCanvas.Children.Add(currentLine); //캔버스에 선 추가
                    Point point = e.GetPosition(paintCanvas); // 마우스 포지션 받기
                    currentLine.Points.Add(point); // 좌표 업뎃
                
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

        private void PenButton_Click(object sender, RoutedEventArgs e)
        {
            PenButton.IsChecked = true;
            whatPen = "pen";
            EraserButton.IsChecked = false;
    }
        private void EraserButton_Click(object sender, RoutedEventArgs e)
        {
            EraserButton.IsChecked = true;
            whatPen = "eraser";
            PenButton.IsChecked = false;
        }
    }
}
