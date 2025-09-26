using System.Drawing;
using System.Windows.Forms;

namespace SxDobleFactor.Methods
{
    public class QrPopup : Form
    {
        public QrPopup(Image qrImage)
        {
            this.Text = "Código QR";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ClientSize = new Size(250, 250);

            var pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = qrImage,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            this.Controls.Add(pictureBox);
        }
    }


}
