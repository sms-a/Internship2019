using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SpellChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
               
                openFileDialog1.DefaultExt = "txt";
                openFileDialog1.Filter = "Текстовый документ (*.TXT, *.LOG)|*.TXT;*.LOG|Все файлы (*.*)|*";
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fread = File.OpenRead(openFileDialog1.FileName))
                    {
                        byte[] buf = new byte[fread.Length];
                        fread.Read(buf, 0, buf.Length);
                        sourceText.Text = Encoding.Default.GetString(buf);
                    }
                    checkedText.Text = SpellChecker.SpellCheck(sourceText.Text);
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = "";
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.Filter = "Текстовый документ (*.TXT)|*.TXT";
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fwrite = new FileStream(fileName, FileMode.OpenOrCreate))
                    {
                        byte[] buf = Encoding.Default.GetBytes(checkedText.Text);
                        fwrite.Write(buf, 0, buf.Length);
                    }
                }
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа, проверяющая строку с учетом словаря известных слов. Для каждого слова в строке\nпрограмма пытается подобрать замену.\n\nСмолев Александр, гр.6313\nЗадание по летней практике", "SpellChecker");
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            if (sourceText.Text.Contains("===")) {
                labelError.Text = "";
                checkedText.Text = SpellChecker.SpellCheck(sourceText.Text);
            }
            else labelError.Text = "Неверный формат входной строки";
        }
    }
}
