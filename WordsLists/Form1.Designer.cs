namespace WordsLists
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_EN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_FR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_NL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_load = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button_quickSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_EN,
            this.Column_FR,
            this.Column_NL,
            this.Column_class,
            this.Notes});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 397);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // Column_EN
            // 
            this.Column_EN.HeaderText = "EN";
            this.Column_EN.Name = "Column_EN";
            // 
            // Column_FR
            // 
            this.Column_FR.HeaderText = "FR";
            this.Column_FR.Name = "Column_FR";
            // 
            // Column_NL
            // 
            this.Column_NL.HeaderText = "NL";
            this.Column_NL.Name = "Column_NL";
            // 
            // Column_class
            // 
            this.Column_class.HeaderText = "Class";
            this.Column_class.Name = "Column_class";
            // 
            // Notes
            // 
            this.Notes.HeaderText = "Notes";
            this.Notes.Name = "Notes";
            // 
            // button_load
            // 
            this.button_load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_load.Location = new System.Drawing.Point(12, 415);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(75, 23);
            this.button_load.TabIndex = 2;
            this.button_load.Text = "Load list";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_save.Location = new System.Drawing.Point(93, 415);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 3;
            this.button_save.Text = "Save list";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button_quickSave
            // 
            this.button_quickSave.Location = new System.Drawing.Point(174, 415);
            this.button_quickSave.Name = "button_quickSave";
            this.button_quickSave.Size = new System.Drawing.Size(75, 23);
            this.button_quickSave.TabIndex = 4;
            this.button_quickSave.Text = "Quick save";
            this.button_quickSave.UseVisualStyleBackColor = true;
            this.button_quickSave.Click += new System.EventHandler(this.button_quickSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_quickSave);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "WordsLists";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button_quickSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_EN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_FR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_NL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_class;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
    }
}

