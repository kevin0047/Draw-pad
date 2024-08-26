using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace Draw_pad
{
    public partial class MainWindow : Window
    {
        private bool isDrawing; 
        private string whatPen = "pen";
        private Polyline currentLine; // 타입 뒤에 ?을 붙이면 널값을 가질수 있음을 나타냄
        private double penPixel = 2; // 초기 펜 굵기


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
                    StrokeThickness = penPixel//strokethickness 선의 두께 ;
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
        private void PixelSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           
            if (PixelValueTextBlock == null)
            {
                MessageBox.Show("PixelValueTextBlock이 null입니다.");
                return;
            }
            penPixel = PixelSlider.Value; // 슬라이더 값을 펜 굵기 값으로 설정
            PixelValueTextBlock.Text = $"펜 굵기: {(int)penPixel}"; // 텍스트 블록 업데이트

        }

    }

}
