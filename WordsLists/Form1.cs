using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordsLists
{
    public partial class Form1 : Form
    {
        private Dictionary<int, Item> unsortedFilesList2 = new Dictionary<int, Item>();
        private List<Item> wordsList = new List<Item>();
        private bool reverseSorting = false;
        private int[] previousCell = new int[2];
        private string lastSaveFile = "";

        class Item
        {
            public int ID;
            public string EN;
            public string FR;
            public string NL;
            public string GR; // group
            public string CT; // notes
        }

        public enum Columns : byte
        {
            EN,
            FR,
            NL,
            GR,
            CT
        }

        public Form1()
        {
            InitializeComponent();

            // wordsList.Add(new Item { ID = 0, EN = "aaa", FR = "mot_0_fr", NL = "word_0_nl", JP = "wado_0_jp", GR = "class0", NT = "" }); 

            listView_refresh(dataGridView1);

            // dataGridView1.Columns[0].HeaderText = "test";
        }

        #region Utilities
        private static bool debugConsoleWrite = true;
        private static List<string> LogQ1 = new List<string>();

        public static void WriteCsv(List<string> in_, string file)
        {
            var fileOut = new FileInfo(file);
            if (File.Exists(file))
                File.Delete(file);

            int i = -1;
            try
            {
                using (var csvStream = fileOut.OpenWrite())
                using (var csvWriter = new StreamWriter(csvStream))
                {
                    foreach (var a in in_)
                    {
                        csvStream.Position = csvStream.Length;
                        csvWriter.WriteLine(a);
                        i++;
                    }
                }
            }
            catch
            { }

        }

        private static List<string> ReadCsv(string filename)
        {
            var output = new List<string>();

            using (var reader = new StreamReader(filename))
            {
                var line = "";
                while (line != null)
                {
                    line = reader.ReadLine();
                    output.Add(line);
                }

                if (output.Last() == null)
                    output.RemoveAt(output.Count - 1);
            }

            return output;
        }

        public static void Log1(string in_, bool force = false)
        {
            LogQ1.Add(in_);
            if (debugConsoleWrite || force)
                Console.WriteLine($"{in_}");
        }

        private void WordsListCleanup()
        {
            var a = ReadCsv(@"C:\Users\Vanguard\Documents\2019 words.csv");
            var b = new Dictionary<string, string>();

            foreach (var c in a)
            {
                var d = c.Split(",".ToCharArray());

                if (!b.ContainsKey(d[0]))
                {
                    if (d.Length > 1)
                        b.Add(d[0], d[1]);
                    else
                        b.Add(d[0], "");
                }
                else
                    if (b[d[0]] == "")
                    b[d[0]] = d[1];

            }

            foreach (var c in b)
            {
                if (c.Value == "")
                    Log1($"{c.Key}");
                else
                    Log1($"{c.Key},{c.Value}");

            }

            WriteCsv(LogQ1, @"C:\Users\Vanguard\Documents\2019words_new.csv");
            ;
        }

        #endregion

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var a = e.Column;

            var b = new List<Item>();

            // There's probably a much shorter way to do this
            if (a == 0) // column
            {
                b = wordsList.OrderBy(x => x.EN).ToList();

                if (reverseSorting)
                    b = wordsList.OrderBy(x => x.EN).Reverse().ToList();
            }
            else if (a == 1)
            {
                b = wordsList.OrderBy(x => x.FR).ToList();

                if (reverseSorting)
                    b = wordsList.OrderBy(x => x.FR).Reverse().ToList();
            }
            else if (a == 2)
            {
                b = wordsList.OrderBy(x => x.NL).ToList();

                if (reverseSorting)
                    b = wordsList.OrderBy(x => x.NL).Reverse().ToList();
            }
            else if (a == 3)
            {
                b = wordsList.OrderBy(x => x.GR).ToList();

                if (reverseSorting)
                    b = wordsList.OrderBy(x => x.GR).Reverse().ToList();
            }

            reverseSorting = !reverseSorting;

            wordsList = new List<Item>();

            foreach (var c in b)
                wordsList.Add(c);

            listView_refresh(dataGridView1);
        }

        private void listView_refresh(DataGridView listView)
        {
            listView.DataSource = null;
            listView.Rows.Clear();

            var i = -1;
            foreach (var item in wordsList)
            {
                i++;
                listView.Rows.Add();
                listView.Rows[i].Cells[0].Value = $"{item.EN}";
                listView.Rows[i].Cells[1].Value = $"{item.FR}";
                listView.Rows[i].Cells[2].Value = $"{item.NL}";
                listView.Rows[i].Cells[3].Value = $"{item.GR}";
                listView.Rows[i].Cells[4].Value = $"{item.CT}";
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            previousCell = new int[] { dataGridView1.CurrentCell.RowIndex, dataGridView1.CurrentCell.ColumnIndex };

            VerifyDuplicates();
        }

        private void VerifyDuplicates()
        {
            var found = false;

            var prevCellRow = previousCell[0];
            var prevCellCol = previousCell[1];

            if (prevCellCol > 2)
                return;

            for (int rowIndex = 0; rowIndex < dataGridView1.Rows.Count - 2; rowIndex++)
            {
                if (dataGridView1.Rows[rowIndex].Cells[prevCellCol].Value == null)
                    continue;

                if (dataGridView1.Rows[rowIndex].Cells[prevCellCol].FormattedValue.ToString() == "")
                    continue;

                if (dataGridView1.Rows[prevCellRow].Cells[prevCellCol].FormattedValue.ToString() == "")
                    continue;

                if (prevCellRow == rowIndex && prevCellCol == previousCell[1])
                    continue;

                var cell = dataGridView1.Rows[rowIndex].Cells[prevCellCol];

                var c = cell.FormattedValue.ToString();

                var d = dataGridView1.Rows[prevCellRow].Cells[prevCellCol].FormattedValue.ToString();

                if (c == d)
                {
                    dataGridView1.Rows[prevCellRow].Cells[prevCellCol].ErrorText = "Duplicate";
                    found = true;
                }
            }

            if (!found)
                dataGridView1.Rows[prevCellRow].Cells[prevCellCol].ErrorText = "";

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            previousCell = new int[] { dataGridView1.CurrentCell.RowIndex, dataGridView1.CurrentCell.ColumnIndex };
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            wordsList.Clear();

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            if (openFileDialog1.FileName == null)
                return;

            openFileDialog1.ShowDialog();

            if (!openFileDialog1.FileName.Contains("\\"))
                return;

            var lines = ReadCsv(openFileDialog1.FileName);

            foreach (var line in lines)
            {
                var split = line.Split(",".ToCharArray());
                var EN = "";
                var FR = "";
                var NL = "";
                var GR = "";
                var CT = "";

                // This is so nasty
                if (split.Length > 0)
                    EN = split[0];
                if (split.Length > 1)
                    FR = split[1];
                if (split.Length > 2)
                    NL = split[2];
                if (split.Length > 3)
                    GR = split[3];
                if (split.Length > 4)
                    CT = split[4];

                wordsList.Add(new Item {
                    EN = EN,
                    FR = FR,
                    NL = NL,
                    GR = GR,
                    CT = CT });

            }

            listView_refresh(dataGridView1);

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == null)
                return;

            lastSaveFile = saveFileDialog1.FileName;

            button_quickSave_Click(null, null);

        }

        private void button_quickSave_Click(object sender, EventArgs e)
        {
            if (lastSaveFile == "")
                lastSaveFile = $"{Directory.GetCurrentDirectory()}\\temp.csv";

            if (File.Exists(lastSaveFile))
                File.Delete(lastSaveFile);

            LogQ1 = new List<string>();

            Log1("EN,FR,NL,Group,Notes");

            for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
            {
                Log1(
                    $"{dataGridView1.Rows[row].Cells[(int)Columns.EN].FormattedValue.ToString()}," +
                    $"{dataGridView1.Rows[row].Cells[(int)Columns.FR].FormattedValue.ToString()}," +
                    $"{dataGridView1.Rows[row].Cells[(int)Columns.NL].FormattedValue.ToString()}," +
                    $"{dataGridView1.Rows[row].Cells[(int)Columns.GR].FormattedValue.ToString()}," +
                    $"{dataGridView1.Rows[row].Cells[(int)Columns.CT].FormattedValue.ToString()}" +
                    "");
            }

            WriteCsv(LogQ1, lastSaveFile);
        }

    }
}
