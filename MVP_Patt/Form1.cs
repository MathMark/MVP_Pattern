using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP_Patt
{
    public interface IMainForm
    { 
        string FilePath { get; }
        string content { get; set; }
        string SymbolCount { get; set; }
        event EventHandler FileOpenClick;//event hasn't got any data
        event EventHandler FileSaveClick;
        event EventHandler ContentChanged;

    }
    public partial class MainForm : Form,IMainForm
    {
        public MainForm()
        {
            InitializeComponent();

            OpenButton.Click += OpenButton_Click;
            SaveButton.Click += SaveButton_Click;
            ContentTextBox.TextChanged += ContentTextBox_TextChanged;

            numFont.ValueChanged += NumFont_ValueChanged;
        }


        #region Events
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (FileSaveClick != null)
            {
                FileSaveClick(this, EventArgs.Empty);
            }
        }
        private void ContentTextBox_TextChanged(object sender, EventArgs e)
        {
            if(ContentChanged!=null)
            {
                ContentChanged(this, EventArgs.Empty);
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if(FileOpenClick!=null)
            {
                FileOpenClick(this, EventArgs.Empty);
            }
        }
        #endregion

        #region IMainForm realization

        public string FilePath
        {
            get
            {
               return pathTextBox.Text;
            }
        }

        public string content
        {
            get
            {
                return ContentTextBox.Text;
            }
            set
            {
                ContentTextBox.Text = value;
            }
        }

        public string SymbolCount
        {
            get
            {
                return CountLabel.Text;
            }
            set
            {
                CountLabel.Text = value.ToString();
            }
        }

        public event EventHandler FileOpenClick;
        public event EventHandler FileSaveClick;
        public event EventHandler ContentChanged;


        #endregion

        private void ChooseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Text Files|*.txt|All files|*.*";

            if(OFD.ShowDialog()==DialogResult.OK)
            {
                pathTextBox.Text = OFD.FileName;

                if (FileOpenClick != null)
                {
                    FileOpenClick(this, EventArgs.Empty);
                }
            }
        }

        private void NumFont_ValueChanged(object sender, EventArgs e)
        {
            ContentTextBox.Font = new Font("Calibri", (float)numFont.Value);
        }
    }
}
