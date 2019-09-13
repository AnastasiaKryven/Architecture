using DataControl;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using System.Xml.Serialization;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;


namespace Main
{
    public partial class MainForm : Form
    {
        Controller data;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            data = new Controller(views1);
        }

        XmlSerializer xml = new XmlSerializer(typeof(Controller));
        BinaryFormatter bin = new BinaryFormatter();
        DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Controller));


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = Environment.CurrentDirectory + @"\data.xml";
            using (FileStream file = new FileStream(filename, FileMode.Create))
            {
                xml.Serialize(file, data);

                file.Close();
            }
        }

        private void bINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = Environment.CurrentDirectory + @"\data.bin";
            using (FileStream file = new FileStream(filename, FileMode.Create))
            {
                bin.Serialize(file, data);
                json.WriteObject(file, data);

                file.Close();
            }
        }

        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = Environment.CurrentDirectory + @"\data.json";
            using (FileStream file = new FileStream(filename, FileMode.Create))
            {
                json.WriteObject(file, data);

                file.Close();
            }
        }

        private void xMLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string filename = Environment.CurrentDirectory + @"\data.xml";
            using (FileStream file = new FileStream(filename, FileMode.Open))
            {
                data = (Controller)xml.Deserialize(file);

                data.Binding(views1);

                file.Close();
            }
        }

        private void bINToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string filename = Environment.CurrentDirectory + @"\data.bin";
            using (FileStream file = new FileStream(filename, FileMode.Open))
            {
                data = (Controller)bin.Deserialize(file);

                data.Binding(views1);

                file.Close();
            }
        }

        private void jSONToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string filename = Environment.CurrentDirectory + @"\data.json";
            using (FileStream file = new FileStream(filename, FileMode.Open))
            {
                data = (Controller)json.ReadObject(file);

                data.Binding(views1);

                file.Close();
            }
        }

#pragma warning disable CS0169 // Поле "MainForm.wordapp" никогда не используется.
        private Microsoft.Office.Interop.Word.Application wordapp;
#pragma warning restore CS0169 // Поле "MainForm.wordapp" никогда не используется.
#pragma warning disable CS0169 // Поле "MainForm.worddoc" никогда не используется.
        private Microsoft.Office.Interop.Word._Document worddoc;
#pragma warning restore CS0169 // Поле "MainForm.worddoc" никогда не используется.


        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveExcel(GetSaveFilePath("excel files|*.xls"));    
        }

        
        private string GetSaveFilePath(string filter)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = filter;
                saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
            throw new Exception("Ошибка работы с файлом");
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveWord(GetSaveFilePath("word files|*.doc"));
        }

       

        private void wordTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveWordTable(GetSaveFilePath("word files|*.doc"));
        }

       
    }
}

    

