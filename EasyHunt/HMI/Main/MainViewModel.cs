using EasyHunt.StructureClass;
using IronOcr;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyHunt.HMI.Main
{
    public class MainViewModel
    {
        public MainModel Model { get; set; }

        public MainView View { get; set; }

        #region Initialize
        
        public MainViewModel()
        {
            //Program path : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "EasyHunt", "Screens");
            Model = new MainModel();
            View = new MainView();
            View.DataContext = Model;
            InitializeCommands();
            View.Show();
            Model.MyProp = $"{View.ActualHeight} x {View.ActualWidth}";
            View.SizeChanged += View_SizeChanged;
        }

        private void InitializeCommands()
        {
            Model.ScreenCommand = new Command(ExecuteScreenCommand);
        }

        #endregion

        #region ScreenCommand

        private void ExecuteScreenCommand(object obj)
        {
            View.Hide();
            Thread.Sleep(100);
            CaptureScreen();
            View.Show();
            ReadText();
        }

        #endregion

        private void View_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            //Model.MyProp = $"{View.ActualHeight} x {View.ActualWidth}";
        }

        private void CaptureScreen()
        {
            Rectangle rect = new Rectangle((int)Convert.ToDouble(View.Left), (int)Convert.ToDouble(View.Top), (int)Convert.ToDouble(View.ActualWidth), (int)Convert.ToDouble(View.ActualHeight));

            Bitmap printscreen = new Bitmap(rect.Width, rect.Height);

            Graphics graphics = Graphics.FromImage(printscreen as Image);

            graphics.CopyFromScreen(rect.X, rect.Y, 0, 0, rect.Size, CopyPixelOperation.SourceCopy);

            printscreen.Save(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "EasyHunt", "Screens", "image.jpg"), ImageFormat.Jpeg);
        }

        private void ReadText()
        {
            var ironOcr = new IronTesseract();
            ironOcr.Language = OcrLanguage.French;
            var result = ironOcr.Read(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "EasyHunt", "Screens", "image.jpg"));
            Model.MyProp = result.Text;
        }
    }
}
