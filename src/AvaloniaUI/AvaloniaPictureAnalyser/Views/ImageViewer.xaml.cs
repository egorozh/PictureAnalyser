using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Avalonia.Media.Imaging;

namespace AvaloniaPictureAnalyser
{
    public class ImageViewer : UserControl
    {
        #region Private Fields

        private Bitmap _imageSource;

        private ImageViewerController _controller;

        /// <summary>
        /// ���������� �������� ������� ��������� ����
        /// </summary>
        private Point _prevPoint;

        private bool _isTranslate;

        #endregion

        #region Dependency Properties

        public static readonly AvaloniaProperty<Uri> ImagePathProperty =
            AvaloniaProperty.Register<ImageViewer, Uri>(nameof(ImagePath), inherits: true, notifying: ImagePathChanged);

        private static void ImagePathChanged(IAvaloniaObject arg1, bool arg2)
        {
            if (arg1 is ImageViewer imageViewer)
                imageViewer.ImagePathChanged(imageViewer.ImagePath);
        }

        //private static void ImagePathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is ImageViewer viewer && e.NewValue is Uri path)
        //        viewer.ImagePathChanged(path);
        //}

        public static readonly AvaloniaProperty<decimal> MinimumScaleProperty =
            AvaloniaProperty.Register<ImageViewer, decimal>(nameof(MinimumScale), inherits: true, defaultValue: 1m);

        //DependencyProperty.Register(
        //    nameof(MinimumScale), typeof(decimal), typeof(ImageViewer), new PropertyMetadata(1m));

        public static readonly AvaloniaProperty<decimal> MaximumScaleProperty =
            AvaloniaProperty.Register<ImageViewer, decimal>(nameof(MaximumScale), inherits: true, defaultValue: 5000m);

        //DependencyProperty.Register(
        //nameof(MaximumScale), typeof(decimal), typeof(ImageViewer), new PropertyMetadata(5000m));

        public static readonly AvaloniaProperty<decimal> ScaleProperty =
            AvaloniaProperty.Register<ImageViewer, decimal>(nameof(Scale), inherits: true, defaultValue: 100m);
        //DependencyProperty.Register(
        //nameof(Scale), typeof(decimal), typeof(ImageViewer), new PropertyMetadata(100m, ScaleChanged));

        //private static void ScaleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is ImageViewer viewer && e.NewValue is decimal scale)
        //        viewer.ScaleChanged(scale);
        //}

        public static readonly AvaloniaProperty<ImageViewerController> ControllerProperty =
            AvaloniaProperty.Register<ImageViewer, ImageViewerController>(nameof(Controller), inherits: true);

    
        //DependencyProperty.Register(
        //nameof(Controller), typeof(ImageViewerController), typeof(ImageViewer),
        //new PropertyMetadata(default(ImageViewerController), ControllerChanged));


        //private static void ControllerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is ImageViewer viewer && e.NewValue is ImageViewerController controller)
        //        viewer.ControllerChanged(controller);
        //}

        #endregion

        #region Public Properties

        public decimal Scale
        {
            get => GetValue(ScaleProperty);
            private set => SetValue(ScaleProperty, value);
        }

        public Uri ImagePath
        {
            get => GetValue(ImagePathProperty);
            set => SetValue(ImagePathProperty, value);
        }

        public decimal MinimumScale
        {
            get => GetValue(MinimumScaleProperty);
            set => SetValue(MinimumScaleProperty, value);
        }

        public decimal MaximumScale
        {
            get => GetValue(MaximumScaleProperty);
            set => SetValue(MaximumScaleProperty, value);
        }

        public ImageViewerController Controller
        {
            get => GetValue(ControllerProperty);
            set => SetValue(ControllerProperty, value);
        }

        #endregion

        #region Constructor

        public ImageViewer()
        {
            InitializeComponent();

            //PreviewMouseWheel += ImageEngine_MouseWheel;

            //ScrollViewer.PreviewMouseLeftButtonDown += ImageEngine_MouseLeftButtonDown;
            //PreviewMouseMove += ImageEngine_MouseMove;
            //PreviewMouseLeftButtonUp += ImageEngine_MouseLeftButtonUp;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        #endregion

        #region Internal Methods

        internal void ToScale(ScaleType type)
        {
            if (type == ScaleType.Increase)
            {
                if (Scale >= MaximumScale) return;

                Scale += GetAddedDeltaResolution(Scale);
            }
            else
            {
                if (Scale <= MinimumScale) return;

                Scale -= GetSubtractDeltaResolution(Scale);
            }
        }

        #endregion

        #region Private Methods

        private void ImagePathChanged(Uri source)
        {
            _imageSource = new Bitmap(source.AbsolutePath);

            //Image.Source = _imageSource;
            //PreviewImage.Source = _imageSource;

            ScaleChanged(Scale);
        }

        private void ControllerChanged(ImageViewerController controller)
        {
            _controller = controller;

            _controller?.Init(this);
        }

        //private void ImageEngine_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    _prevPoint = e.GetPosition(this);

        //    if (e.OriginalSource == Canvas || e.OriginalSource == ScrollViewer)
        //    {
        //        Mouse.Capture(this);
        //        _isTranslate = true;
        //    }
        //}

        //private void ImageEngine_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (_isTranslate)
        //    {
        //        var mousePos = e.GetPosition(this);

        //        ScrollViewer.ScrollToHorizontalOffset(ScrollViewer.HorizontalOffset - (mousePos.X - _prevPoint.X));
        //        ScrollViewer.ScrollToVerticalOffset(ScrollViewer.VerticalOffset - (mousePos.Y - _prevPoint.Y));

        //        _prevPoint = mousePos;

        //        DrawPreviewRectangle();

        //        Mouse.SetCursor(Cursors.Hand);
        //    }
        //}

        //private void ImageEngine_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    //Mouse.SetCursor(Cursors.Arrow);
        //    //Mouse.Capture(null);

        //    _isTranslate = false;
        //}

        #region Scalling

        private void ScaleChanged(decimal scale)
        {
            //var width = (double) (_imageSource.PixelWidth * scale / 100m);
            //var height = (double) (_imageSource.PixelHeight * scale / 100m);

            //Host.Width = width;
            //Host.Height = height;

            //Host.UpdateLayout();
            //ScrollViewer.UpdateLayout();

            //// TODO: ���������� �������� offset ����� �������, ����� 
            //// ��� ��������� �������� ����������� ����� ����������� ������������ �������
            //ScrollViewer.ScrollToHorizontalOffset(ScrollViewer.ExtentWidth / 2);
            //ScrollViewer.ScrollToVerticalOffset(ScrollViewer.ExtentHeight / 2);

            //Host.UpdateLayout();
            //ScrollViewer.UpdateLayout();

            //if (width > ScrollViewer.ViewportWidth || height > ScrollViewer.ViewportHeight)
            //{
            //    PreviewViewer.Visibility = Visibility.Visible;

            //    PreviewViewer.UpdateLayout();

            //    DrawPreviewRectangle();
            //}
            //else
            //{
            //    PreviewViewer.Visibility = Visibility.Collapsed;
            //}
        }

        //private void DrawPreviewRectangle()
        //{
        //    var left = PreviewCanvas.ActualWidth * ScrollViewer.HorizontalOffset / Host.Width;
        //    var top = PreviewCanvas.ActualHeight * ScrollViewer.VerticalOffset / Host.Height;

        //    var right = PreviewCanvas.ActualWidth *
        //                (ScrollViewer.HorizontalOffset + ScrollViewer.ViewportWidth) / Host.Width;
        //    var bottom = PreviewCanvas.ActualHeight *
        //                 (ScrollViewer.VerticalOffset + ScrollViewer.ViewportHeight) / Host.Height;

        //    PreviewRectangle.Width = right - left;
        //    PreviewRectangle.Height = bottom - top;

        //    Canvas.SetLeft(PreviewRectangle, left);
        //    Canvas.SetTop(PreviewRectangle, top);
        //}

        //private void ImageEngine_MouseWheel(object sender, MouseWheelEventArgs e)
        //{
        //    e.Handled = true;

        //    if (Keyboard.IsKeyDown(Key.LeftCtrl))
        //    {
        //        ToScale(e.Delta > 0 ? ScaleType.Increase : ScaleType.Decrease);
        //    }
        //    else
        //    {
        //        ScrollViewer.ScrollToVerticalOffset(ScrollViewer.VerticalOffset - e.Delta);

        //        DrawPreviewRectangle();
        //    }
        //}

        private static decimal GetAddedDeltaResolution(decimal resolution)
        {
            var decLog = Math.Log10((double) resolution);
            var truncate = Math.Truncate(decLog);

            if (decLog < 0 && decLog != truncate)
                truncate -= 1;

            return (decimal) Math.Pow(10, truncate);
        }

        private static decimal GetSubtractDeltaResolution(decimal resolution)
        {
            var decLog = Math.Log10((double) resolution);

            var truncate = Math.Truncate(decLog);

            if (decLog < 0 && decLog != truncate)
                truncate -= 1;

            return decLog == truncate
                ? (decimal) Math.Pow(10, truncate - 1)
                : (decimal) Math.Pow(10, truncate);
        }

        #endregion

        #endregion
    }
}