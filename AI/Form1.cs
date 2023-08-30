using Emgu;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.Util;
namespace AI
{
    public partial class Form1 : Form
    {
        private string filePath = string.Empty;
        private string lang = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                pictureBox1.Image= Image.FromFile(filePath);
            }
            else
            {
                MessageBox.Show("You did not choose a picture","Choose a picture", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(filePath)|| String.IsNullOrWhiteSpace(filePath))
                {
                    throw new Exception("You didnt choose a picture");
                }
                else if (toolStripComboBox1.SelectedItem == null)
                {
                    throw new Exception("You didnt choose a language");

                }
                else
                {
                    Tesseract tesseract = new Tesseract(@"C:\Users\User\Desktop\testdata", lang,OcrEngineMode.TesseractLstmCombined);
                    tesseract.SetImage(new Image<Bgr,byte>(filePath));
                    tesseract.Recognize();
                    richTextBox1.Text = tesseract.GetUTF8Text();
                    tesseract.Dispose();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex == 0) lang = "eng";
            if (toolStripComboBox1.SelectedIndex == 1) lang = "rus";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}