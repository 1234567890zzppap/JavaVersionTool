using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace JavaVersionCovert
{
    public partial class Form1 : Form
    {
      
        public string InputDir;
        public string[] InputFiles;
        public string VersionInput;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Class Files|*.class";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                   
                    InputDir = openFileDialog.FileName;
                    InputFiles = openFileDialog.FileNames;

                   /* foreach (string file in InputFiles)
                    {
                        Console.WriteLine(file);
                    }
                    */
                }
            
        }
        public string CheckVersion(string input)
        {

            string VersionInfo = "";
            input = input.ToUpper().Replace(" ","");
            string Check = input.Length >= 4 ? input.Substring(input.Length - 4) : input;
            Console.WriteLine(Check);
            VersionInfo = "Java 等级：" + Convert.ToInt32(Check,16) +"\r\n";
            if (Convert.ToInt32(Check, 16) >= 45 && Convert.ToInt32(Check, 16) <= 67)
            {
                int tmp = Convert.ToInt32(Check, 16);
                tmp = tmp - 44;
                if (tmp <= 8)
                { VersionInfo = VersionInfo + "所需的JVM版本：Java 1."+tmp; }
                else
                { VersionInfo = VersionInfo + "所需的JVM版本：Java "+tmp; }
            }
            else
            { VersionInfo = VersionInfo + "所需的JVM版本：未知"; }
            return VersionInfo;
            
        
        }
        public void CovertToHex()
        {
            if (radioButton1.Checked)
            {
                if (comboBox1.Text == "Java 1.1")
                {
                    VersionInput = "0000002D".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 1.2")
                {
                    VersionInput = "0000002E".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 1.3")
                {
                    VersionInput = "0000002F".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 1.4")
                {
                    VersionInput = "00000030".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 1.5")
                {
                    VersionInput = "00000031".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 1.6")
                {
                    VersionInput = "00000032".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 1.7")
                {
                    VersionInput = "00000033".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 1.8")
                {
                    VersionInput = "00000034".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 9")
                {
                    VersionInput = "00000035".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 10")
                {
                    VersionInput = "00000036".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 11")
                {
                    VersionInput = "00000037".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 12")
                {
                    VersionInput = "00000038".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 13")
                {
                    VersionInput = "00000039".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 14")
                {
                    VersionInput = "0000003A".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 15")
                {
                    VersionInput = "0000003B".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 16")
                {
                    VersionInput = "0000003C".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 17")
                {
                    VersionInput = "0000003D".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 18")
                {
                    VersionInput = "0000003E".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 19")
                {
                    VersionInput = "0000003F".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 20")
                {
                    VersionInput = "00000040".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 21")
                {
                    VersionInput = "00000041".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 22")
                {
                    VersionInput = "00000042".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
                if (comboBox1.Text == "Java 23")
                {
                    VersionInput = "00000043".Trim().ToUpper();
                    Console.WriteLine(VersionInput);
                }
              
              
            }
            if (radioButton2.Checked)
            { VersionInput = (textBox2.Text + textBox3.Text).Trim().ToUpper();
            Console.WriteLine(VersionInput);
            }
        
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
            CovertToHex();
            Task.Factory.StartNew(() =>
    {
        if (InputFiles == null)
        {
            MessageBox.Show("请输入文件");
            return;
        }

        string[] paths = InputFiles;
        List<string> validFiles = new List<string>();
        foreach (string rawPath in paths)
        {
            string path = rawPath.Trim();
            if (File.Exists(path))
                validFiles.Add(path);
            else
                Console.WriteLine("警告：文件不存在 -> " + path);
        }

        if (validFiles.Count == 0)
        {
            MessageBox.Show("没有可处理的有效文件。");
            return;
        }


        string hexInput = VersionInput;

        if (hexInput.Length != 8)
        {
            MessageBox.Show("错误：输入必须是 8 个十六进制字符（即 4 字节）！");
            return;
        }

        byte[] newBytes = new byte[4];
        try
        {
            for (int i = 0; i < 4; i++)
            {
                newBytes[i] = Convert.ToByte(hexInput.Substring(i * 2, 2), 16);
            }
        }
        catch
        {
            MessageBox.Show("错误：无效的十六进制字符串！");
            return;
        }

        Parallel.ForEach(validFiles, file =>
    {
        try
        {
            string tmp = "";
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.ReadWrite))
            {
                if (fs.Length < 8)
                {
                    tmp = tmp + ("跳过文件（不足8字节）：" + file + "\r\n");
                    return;
                }

                tmp = tmp + ("\r\n处理文件：" + file + "\r\n");
                if (checkBox1.Checked)
                {
                    if (File.Exists(file + ".bak"))
                    {
                        if (checkBox2.Checked)
                        {
                            File.Copy(file, file + ".bak", true);
                        }
                    }
                    else
                    {
                        File.Copy(file, file + ".bak");
                    }
                }
                // 显示前4个字节
                byte[] first8 = new byte[8];
                fs.Read(first8, 0, 8);
                tmp = tmp + ("原始前8字节：");
                for (int i = 0; i < 8; i++)
                    tmp = tmp + String.Format("{0:X2} ", first8[i]);

                // 修改偏移4～7
                fs.Seek(4, SeekOrigin.Begin);
                fs.Write(newBytes, 0, 4);
                fs.Flush();

                // 验证修改结果
                fs.Seek(0, SeekOrigin.Begin);
                fs.Read(first8, 0, 8);
                tmp = tmp + ("\r\n修改后前8字节：");
                for (int i = 0; i < 8; i++)
                    tmp = tmp + String.Format("{0:X2} ", first8[i]);
                tmp = tmp + ("\r\n修改成功！\r\n");
                this.Invoke((Action)(() =>
                {
                    textBox1.AppendText(tmp);
                }));

            }
        }
        catch (Exception ex)
        {
            this.Invoke((Action)(() =>
            {
                MessageBox.Show("错误处理文件 " + file + " ：" + ex.Message);
            }));

        }
    });


    });
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
         if (radioButton1.Enabled)
            {
             textBox2.ReadOnly = true;
             textBox3.ReadOnly = true;

            }
             if (!radioButton1.Enabled)
             {
                 textBox2.ReadOnly = false;
                 textBox3.ReadOnly = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Enabled)
            {textBox2.ReadOnly = false;
             textBox3.ReadOnly = false;

            }
             if (!radioButton2.Enabled )
            {textBox2.ReadOnly = true;
             textBox3.ReadOnly = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                if (InputFiles == null)
                {
                    MessageBox.Show("请输入文件");
                    return;
                }

                string[] paths = InputFiles;
                List<string> validFiles = new List<string>();
                foreach (string rawPath in paths)
                {
                    string path = rawPath.Trim();
                    if (File.Exists(path))
                        validFiles.Add(path);
                    else
                        Console.WriteLine("警告：文件不存在 -> " + path);
                }

                if (validFiles.Count == 0)
                {
                    MessageBox.Show("没有可处理的有效文件。");
                    return;
                }
                Parallel.ForEach(validFiles, file =>
                {
                    try
                    {
                        string tmp = "";
                        string tmp1 = "";
                        using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.ReadWrite))
                        {
                            if (fs.Length < 8)
                            {
                                tmp = tmp + ("跳过文件（不足8字节）：" + file + "\r\n");
                                return;
                            }

                            tmp = tmp + ("\r\n当前文件：" + file + "\r\n");
                            // 显示前4个字节
                            byte[] first8 = new byte[8];
                            fs.Read(first8, 0, 8);
                            tmp = tmp + ("原始前8字节：");
                            for (int i = 0; i < 8; i++)
                            {
                                tmp1 = tmp1 +String.Format("{0:X2} ", first8[i]);
                                tmp = tmp + String.Format("{0:X2} ", first8[i]);
                            }
                            tmp = tmp +"\r\n"+ CheckVersion(tmp1);

                           
                            this.Invoke((Action)(() =>
                            {
                                textBox1.AppendText(tmp+"\r\n");
                            }));

                        }
                    }
                    catch (Exception ex)
                    {
                        this.Invoke((Action)(() =>
                        {
                            MessageBox.Show("错误处理文件 " + file + " ：" + ex.Message);
                        }));

                    }
                });


            });

        }
    }
}
