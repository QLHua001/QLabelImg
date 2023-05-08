using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LabelImg
{

    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // 递归遍历指定目录下的文件和子目录
        private void TraverseDirectory(string path, List<string> filelist)
        {
            try
            {
                // 遍历当前目录下的所有文件
                foreach (string filePath in Directory.GetFiles(path))
                {
                    Console.WriteLine(filePath);  // 处理当前文件
                    filelist.Add(filePath);
                }

                // 遍历当前目录下的所有子目录
                foreach (string subDirPath in Directory.GetDirectories(path))
                {
                    TraverseDirectory(subDirPath, filelist);  // 递归遍历子目录
                }
            }
            catch (Exception ex)
            {
                // 处理访问目录时的异常
                Console.WriteLine(ex.Message);
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                List<string> files = new List<string>();
                TraverseDirectory(this.folderBrowserDialog1.SelectedPath, files);
                this.listBox1.Items.Clear();
                foreach(string file in files)
                {
                    this.listBox1.Items.Add(file); 
                }
                this.listBox1.SelectedIndex = 0;
                Image image = Image.FromFile(this.listBox1.SelectedItem.ToString());
                this.pictureBox1.Image = image;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image image = Image.FromFile(this.listBox1.SelectedItem.ToString());
            this.pictureBox1.Image = image;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
