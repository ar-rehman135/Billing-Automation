namespace Billing_Automation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public class Form1 : Form
    {
        private WindowsFormsSynchronizationContext mUiContext;
        private IContainer components = null;
        private Label label1;
        private TextBox textBox1;
        private DataGridView grdCases;
        private Button button1;
        private DataGridViewTextBoxColumn invoiceNum;
        private DataGridViewTextBoxColumn colStatus;
        private Label label2;
        private TextBox textBox2;
        private Button button2;
        private FolderBrowserDialog folderBrowserDialog1;

        public Form1()
        {
            this.InitializeComponent();
            this.PopulateLastSelectedFolder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string invoiceno = this.textBox1.Text;
            if (string.IsNullOrEmpty(invoiceno))
            {
                MessageBox.Show("invoice number required");
            }
            else
            {
                string dir = this.textBox2.Text;
                if (string.IsNullOrEmpty(dir))
                {
                    MessageBox.Show("Directory required");
                }
                else
                {
                    object[] values = new object[] { invoiceno, "Processing..." };
                    int rowNum = this.grdCases.Rows.Add(values);
                    this.mUiContext = new WindowsFormsSynchronizationContext();
                    new Thread(() => this.processInvoice(dir, invoiceno, rowNum)).Start();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox2.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textBox2.Text))
            {
                try
                {
                    FileStream stream = File.Open("app.config", FileMode.OpenOrCreate);
                    StreamWriter writer = new StreamWriter(stream);
                    writer.WriteLine(this.textBox2.Text);
                    writer.Close();
                    stream.Close();
                }
                catch
                {
                }
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.grdCases = new DataGridView();
            this.invoiceNum = new DataGridViewTextBoxColumn();
            this.colStatus = new DataGridViewTextBoxColumn();
            this.button1 = new Button();
            this.label2 = new Label();
            this.textBox2 = new TextBox();
            this.button2 = new Button();
            this.folderBrowserDialog1 = new FolderBrowserDialog();
            ((ISupportInitialize) this.grdCases).BeginInit();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x19, 0x19);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice no";
            this.label1.Click += new EventHandler(this.label1_Click);
            this.textBox1.Location = new Point(0x70, 0x16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0xce, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
            this.grdCases.AllowUserToAddRows = false;
            this.grdCases.AllowUserToDeleteRows = false;
            this.grdCases.AllowUserToResizeColumns = false;
            this.grdCases.AllowUserToResizeRows = false;
            this.grdCases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[] { this.invoiceNum, this.colStatus };
            this.grdCases.Columns.AddRange(dataGridViewColumns);
            this.grdCases.Location = new Point(0x1c, 90);
            this.grdCases.MultiSelect = false;
            this.grdCases.Name = "grdCases";
            this.grdCases.RowHeadersVisible = false;
            this.grdCases.Size = new Size(0x1c6, 0xba);
            this.grdCases.TabIndex = 20;
            this.invoiceNum.HeaderText = "Invoice";
            this.invoiceNum.Name = "invoiceNum";
            this.invoiceNum.Width = 150;
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 0x11b;
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 300;
            this.button1.Location = new Point(0x17a, 20);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x66, 0x17);
            this.button1.TabIndex = 0x15;
            this.button1.Text = "Process Invoice";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x19, 0x3b);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x49, 13);
            this.label2.TabIndex = 0x16;
            this.label2.Text = "Source Folder";
            this.textBox2.Location = new Point(0x70, 0x38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(0xce, 20);
            this.textBox2.TabIndex = 0x17;
            this.button2.Location = new Point(0x17a, 0x35);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x66, 0x17);
            this.button2.TabIndex = 0x18;
            this.button2.Text = "Select Folder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x202, 0x127);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.grdCases);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label1);
            base.Name = "Form1";
            this.Text = "Billing Automation";
            base.FormClosed += new FormClosedEventHandler(this.Form1_FormClosed);
            ((ISupportInitialize) this.grdCases).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void PopulateLastSelectedFolder()
        {
            try
            {
                FileStream stream = File.Open("app.config", FileMode.Open);
                StreamReader reader = new StreamReader(stream);
                this.textBox2.Text = reader.ReadLine().Trim();
                reader.Close();
                stream.Close();
            }
            catch
            {
            }
        }

        private InvoiceInfo processContentAndGetVariables(string content, int rowNum)
        {
            List<string> list = content.Split("\n".ToCharArray()).ToList<string>();
            char[] separator = new char[] { ' ' };
            string[] strArray = list[list.FindIndex(x => x.Contains("Date Invoice #")) + 1].Split(separator);
            string str2 = strArray[0];
            string str3 = strArray[1];
            char[] chArray2 = new char[] { ' ' };
            string loadN = list[list.FindIndex(x => x.Contains("Load Number BOL #")) + 1].Split(chArray2)[0];
            char[] chArray3 = new char[] { ' ' };
            string str7 = list[list.FindIndex(x => x.Contains("Total")) - 1].Split(chArray3)[0].Substring(1);
            int num4 = list.FindIndex(x => x.Contains("Bill To"));
            char[] chArray4 = new char[] { ' ' };
            string[] strArray4 = list[num4 + 6].Split(chArray4);
            return new InvoiceInfo(str2, str3, loadN, str7, list[num4 + 2], strArray4[strArray4.Length - 1]);
        }

        private void processInvoice(string dir, string invoiceno, int rowNum)
        {
            WindowsFormsSynchronizationContext mUiContext = this.mUiContext;
            SendOrPostCallback d = new SendOrPostCallback(this.UpdateGridText);
            string filename = dir + Path.DirectorySeparatorChar.ToString() + invoiceno + ".pdf";
            InvoiceInfo objA = this.ReadPDF(filename, rowNum);
            if (!ReferenceEquals(objA, null))
            {
                objA.invFile = filename;
                Tuple<bool, string> tuple = objA.ValidateReadedData(invoiceno);
                if (!tuple.Item1)
                {
                    mUiContext.Post(d, new Tuple<int, string>(rowNum, tuple.Item2));
                }
                else
                {
                    Tuple<bool, string> tuple2 = objA.FindFiles(dir, objA);
                    if (!tuple2.Item1)
                    {
                        mUiContext.Post(d, new Tuple<int, string>(rowNum, tuple2.Item2));
                    }
                    else
                    {
                        InvoicePrcessor prcessor = new InvoicePrcessor();
                        string str2 = prcessor.ProcessInvoice(objA);
                        mUiContext.Post(d, new Tuple<int, string>(rowNum, str2));
                        prcessor.Dispose();
                    }
                }
            }
        }

        private InvoiceInfo ReadPDF(string filename, int rowNum)
        {
            InvoiceInfo info;
            string str = new PDFParser().ExtractText(filename);
            if (!string.IsNullOrEmpty(str))
            {
                info = this.processContentAndGetVariables(str, rowNum);
            }
            else
            {
                this.grdCases[1, rowNum].Value = "Unable to read PDF file";
                info = null;
            }
            return info;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                this.button1_Click(this.button1, null);
            }
        }

        private void UpdateGridText(object userData)
        {
            Tuple<int, string> tuple = (Tuple<int, string>) userData;
            this.grdCases[1, tuple.Item1].Value = tuple.Item2;
        }

        [Serializable, CompilerGenerated]
        private sealed class <>c
        {
            public static readonly Form1.<>c <>9 = new Form1.<>c();
            public static Predicate<string> <>9__9_0;
            public static Predicate<string> <>9__9_1;
            public static Predicate<string> <>9__9_2;
            public static Predicate<string> <>9__9_3;

            internal bool <processContentAndGetVariables>b__9_0(string x) => 
                x.Contains("Date Invoice #");

            internal bool <processContentAndGetVariables>b__9_1(string x) => 
                x.Contains("Load Number BOL #");

            internal bool <processContentAndGetVariables>b__9_2(string x) => 
                x.Contains("Total");

            internal bool <processContentAndGetVariables>b__9_3(string x) => 
                x.Contains("Bill To");
        }
    }
}

