using LVController;

namespace LVController
{
    public partial class Form1 : Form
    {
        private LVControllerSystem controller;
        public Form1()
        {
            InitializeComponent();
        }
        private void RefreshUI()
        {
            ControlButton.BackColor = controller.isRunning ? Color.Red : Color.LightGreen;
            ControlButton.Text = controller.isRunning ? "Stop" : "Start";
        }
        public async void InitSystem()
        {
            controller = new();
            controller.ScreenReceived += buffer =>
            {
                using MemoryStream ms = new(buffer);
                using Image img = Image.FromStream(ms);

                Bitmap bitmap = new Bitmap(img);

                ScreenBox.BeginInvoke((Action)(() =>
                {
                    Image? old = ScreenBox.Image;
                    ScreenBox.Image = bitmap;
                    old?.Dispose();
                }));
                RefreshUI();
            };
            RefreshUI();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void ControlButton_Click(object sender, EventArgs e)
        {
            _ = controller.Start();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            InitSystem();
        }
    }
}
