using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CSCompile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool textchange = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textchange)
            {
                MessageBox.Show("Please Write Some C0de in the box.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                richTextBox1.Text = "";
                CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
                string Output = "Out.exe";
                Button ButtonObject = (Button)sender;

                System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
                //Make sure we generate an EXE, not a DLL
                parameters.GenerateExecutable = true;
                parameters.OutputAssembly = Output;
                CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, TextBox1.Text);

                if (results.Errors.Count > 0)
                {
                    label2.ForeColor = Color.Red;
                    label2.Text = "Built Failed!";
                    richTextBox1.ForeColor = Color.Red;
                    foreach (CompilerError CompErr in results.Errors)
                    {
                        richTextBox1.Text = richTextBox1.Text +
                                    "Line number " + CompErr.Line +
                                    ", Error Number: " + CompErr.ErrorNumber +
                                    ", '" + CompErr.ErrorText + ";" +
                                    Environment.NewLine + Environment.NewLine;
                    }
                }
                else
                {
                    //Successful Compile
                    label2.ForeColor = Color.Blue;
                    label2.Text = "Built Successfully!";
                    //If we clicked run then launch our EXE

                    string folderPath = string.Empty;
                    // folderBrowserDialog1.ShowDialog();
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        folderPath = folderBrowserDialog1.SelectedPath;
                        File.Copy("Out.exe", folderPath + @"\CompiledAssembly.exe");
                        File.Delete("Out.exe");
                    }
                }
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textchange)
            {
                MessageBox.Show("Please Write Some C0de in the box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                richTextBox1.Text = "";
                CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
                string Outputs = "Out.exe";
                Button ButtonObject = (Button)sender;

                System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
                //Make sure we generate an EXE, not a DLL
                parameters.GenerateExecutable = true;
                parameters.OutputAssembly = Outputs;
                CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, TextBox1.Text);

                if (results.Errors.Count > 0)
                {
                    label2.ForeColor = Color.Red;
                    label2.Text = "Built Failed!";
                    richTextBox1.ForeColor = Color.Red;
                    foreach (CompilerError CompErr in results.Errors)
                    {
                        richTextBox1.Text = richTextBox1.Text +
                                    "Line number " + CompErr.Line +
                                    ", Error Number: " + CompErr.ErrorNumber +
                                    ", '" + CompErr.ErrorText + ";" +
                                    Environment.NewLine + Environment.NewLine;
                    }
                }
                else
                {
                    //Successful Compile
                    label2.ForeColor = Color.Blue;
                    label2.Text = "Built Successfully!";
                    //If we clicked run then launch our EXE
                    Process process = new Process();
                    // Configure the process using the StartInfo properties.
                    process.StartInfo.FileName = "Out.exe";
                    process.Start();
                    process.WaitForExit();
                    File.Delete("Out.exe");
                }
            }
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            textchange = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextBox1.Text = @"
using System;

public class Compile
{
    public static void Main(string[] args)
    {
        Console.WriteLine(DateTime.Today.ToString());
        Console.ReadLine();
    }
}";
            textchange = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextBox1.Text = @"

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CSCompile
{
    public partial class FMDemo : Form
    {
        public FMDemo()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 23);
            this.button1.Name = ""button1"";
            this.button1.Size = new System.Drawing.Size(188, 64);
            this.button1.TabIndex = 0;
            this.button1.Text = ""<<THE Useless Button>>"";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FMDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 115);
            this.Controls.Add(this.button1);
            this.Name = ""FMDemo"";
            this.Text = ""Demo Form"";
            this.ResumeLayout(false);

        }
        private void FMDemo_Load(object sender, EventArgs e)
        {

        }
    }
}
";
            textchange = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

