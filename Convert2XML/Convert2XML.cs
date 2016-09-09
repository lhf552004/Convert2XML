using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;

namespace XLS2XML
{
    public enum delimiterEnum
    {
        semicolon = ';',
        tab = '\t',
        comma = ',',
        whiteSpace = ' '
    }

    public partial class Convert2XML : Form
    {
        public Convert2XML()
        {
            InitializeComponent();
        }
        private string outputFileName = "";
        private string outputFolderPath = System.Windows.Forms.Application.StartupPath;
        private string outputFileFullName = System.Windows.Forms.Application.StartupPath + "\\output.xml";
        private XmlDocument targetDoc;
        private string[,] units;
        private ulong fileID = 0;
        private int sheetIndex = 1;
        public char[] delimiters = new char[] {';','\t', ',' ,' '};
        private char delimiter;
       
        private void OpenExcelButton_Click(object sender, EventArgs e)
        {
            if (this.openExcelFileDialog.ShowDialog() == DialogResult.OK)
            {
                int count = 0;
                xmlProgressBar.Visible = true;
                string fullFileName = openExcelFileDialog.FileName;
                string fileName = fullFileName.Substring(fullFileName.LastIndexOf("\\") + 1);
                fileName = fileName.Substring(0, fileName.LastIndexOf("."));
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                Excel.Range range;
                int rCnt = 0;
                FileIDHandler handler = new FileIDHandler();
                fileID = handler.getFileID(fullFileName);
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(fullFileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(sheetIndex);

                range = xlWorkSheet.UsedRange;
                XmlWriterSettings setting = new XmlWriterSettings();
                setting.Indent = true;
                setting.IndentChars = "\t";
                setting.Encoding = Encoding.UTF8;
                using (XmlWriter writer = XmlWriter.Create(outputFileFullName, setting))
                {
                    writer.WriteStartElement("InputData");
                    writer.WriteAttributeString("FileID", fileID.ToString());
                    writer.WriteStartElement("Units");
                    writer.WriteStartElement("Unit");
                    writer.WriteAttributeString("Name", fileName);
                    writer.WriteAttributeString("Type", "Job");
                    writer.WriteAttributeString("Priority", "1");
                    writer.WriteStartElement("Comment");
                    writer.WriteEndElement();// end element for Comment
                    writer.WriteStartElement("Product");
                    writer.WriteRaw("Sorting");
                    writer.WriteEndElement();// end element for Product
                    count = range.Rows.Count;
                    xmlProgressBar.Maximum = count;
                    for (rCnt = 2; rCnt <= count; rCnt++)
                    {
                        //progessValue = ((rCnt - 1) / count) * 100;
                        //Console.Write("progessValue: " + progessValue + Environment.NewLine);
                        xmlProgressBar.Value = (rCnt - 1);
                        var area = (range.Cells[rCnt, 1] as Excel.Range).Value2.ToString();
                        var branch = (range.Cells[rCnt, 2] as Excel.Range).Value2.ToString();
                        var cardNumber = (range.Cells[rCnt, 3] as Excel.Range).Value2.ToString();
                        var noOfBranch = (range.Cells[rCnt, 4] as Excel.Range).Value2.ToString();
                        writer.WriteStartElement("Unit");
                        string name = "Card" + (rCnt - 1).ToString("0000");
                        writer.WriteAttributeString("Name", name);
                        writer.WriteAttributeString("Type", "Card");
                        writer.WriteStartElement("DataFields");
                        //data field Area
                        writer.WriteStartElement("DataField");
                        writer.WriteAttributeString("Name", "Area");
                        writer.WriteStartElement("Value");
                        writer.WriteAttributeString("InputFormat", "Text");
                        writer.WriteRaw(area);
                        writer.WriteEndElement();// end element for Value
                        writer.WriteEndElement();// end element for DataField
                        //data field Branch
                        writer.WriteStartElement("DataField");
                        writer.WriteAttributeString("Name", "Branch");
                        writer.WriteStartElement("Value");
                        writer.WriteAttributeString("InputFormat", "Text");
                        writer.WriteRaw(branch);
                        writer.WriteEndElement();// end element for Value
                        writer.WriteEndElement();// end element for DataField
                        //data field CardNumber
                        writer.WriteStartElement("DataField");
                        writer.WriteAttributeString("Name", "CardNumber");
                        writer.WriteStartElement("Value");
                        writer.WriteAttributeString("InputFormat", "Text");
                        writer.WriteRaw(cardNumber);
                        writer.WriteEndElement();// end element for Value
                        writer.WriteEndElement();// end element for DataField
                        //data field No.ofBranch
                        writer.WriteStartElement("DataField");
                        writer.WriteAttributeString("Name", "No.ofBranch");
                        writer.WriteStartElement("Value");
                        writer.WriteAttributeString("InputFormat", "Text");
                        writer.WriteRaw(noOfBranch);
                        writer.WriteEndElement();// end element for Value
                        writer.WriteEndElement();// end element for DataField

                        writer.WriteEndElement();// end element for DataFields
                        writer.WriteEndElement();// end element for Unit
                    }
                    writer.WriteEndElement();// end element for Unit at the top
                    writer.WriteEndElement();// end element for Units
                    writer.WriteEndElement();// end element for InputData
                    writer.WriteEndDocument();
                    writer.Flush();
                }
                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
                MessageBox.Show("读写完成!");
                xmlProgressBar.Value = 0;
                xmlProgressBar.Visible = false;
            }

        }
        private void writeToFile(string filePath, string text)
        {
            StreamWriter sw = new StreamWriter(filePath, false, Encoding.Unicode);
            sw.Write(text);
            sw.Flush();
            sw.Close();
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.openExcelFileDialog.FileName = "*.xls";
            this.openCsvFileDialog.FileName = "*.csv";
            outputPathLabel.Text = outputFileFullName;
            outputFileName = OutputFileNameText.Text;
            loadEncodingList();
            delimiter = (char)delimiterEnum.tab;
        }

        private void SheetIndexNum_ValueChanged(object sender, EventArgs e)
        {
            sheetIndex = (int)SheetIndexNum.Value;
        }

        private void OutputFileNameText_TextChanged(object sender, EventArgs e)
        {
            outputFileName = OutputFileNameText.Text;
            setOutputFileFullName();
        }
        private void setOutputFileFullName()
        {
            if (!string.IsNullOrEmpty(outputFileName))
            {
                if (!(outputFileName.EndsWith(".xml")))
                {
                    outputFileName = outputFileName + ".xml";
                }
            }
            else
            {
                MessageBox.Show("请输入文件名！");
                return;
            }

            if (!string.IsNullOrEmpty(outputFolderPath))
            {
                outputFileFullName = outputFolderPath + "\\" + outputFileName;
                outputPathLabel.Text = outputFileFullName;
            }
            else
            {
                MessageBox.Show("请选择路径！");
                return;
            }
           
        }

        private void SelectPathButton_Click(object sender, EventArgs e)
        {
            if (this.targetFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                outputFolderPath = targetFolderBrowserDialog.SelectedPath;
                setOutputFileFullName();
            }

        }

        private void OpenCsvButton_Click(object sender, EventArgs e)
        {
            if (this.openCsvFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fullFileName = openCsvFileDialog.FileName;
                string fileName = fullFileName.Substring(fullFileName.LastIndexOf("\\") + 1);
                fileName = fileName.Substring(0, fileName.LastIndexOf("."));
                StreamReader sr = new StreamReader(fullFileName, csvEncoding);
                string lineText;
                int i = 0;
                FileIDHandler handler = new FileIDHandler();
                fileID = handler.getFileID(fullFileName);
                xmlProgressBar.Visible = true;
                xmlProgressBar.Maximum = 100;
                xmlProgressBar.Value = 50;
                XmlWriterSettings setting = new XmlWriterSettings();
                setting.Indent = true;
                setting.IndentChars = "\t";
                setting.Encoding = Encoding.UTF8;
                using (XmlWriter writer = XmlWriter.Create(outputFileFullName, setting))
                {
                    writer.WriteStartElement("InputData");
                    writer.WriteAttributeString("FileID", fileID.ToString());
                    writer.WriteStartElement("Units");
                    writer.WriteStartElement("Unit");
                    writer.WriteAttributeString("Name", fileName);
                    writer.WriteAttributeString("Type", "Job");
                    writer.WriteAttributeString("Priority", "1");
                    writer.WriteStartElement("Comment");
                    writer.WriteEndElement();// end element for Comment
                    writer.WriteStartElement("Product");
                    writer.WriteRaw("Sorting");
                    writer.WriteEndElement();// end element for Product

                    while ((lineText = sr.ReadLine()) != null)
                    {
                        i++;
                        if (i == 1)
                        {
                            continue;
                        }
                        if (string.IsNullOrWhiteSpace(lineText))
                        {
                            //the line is white space or empty line, just keep it

                            continue;
                        }
                        string[] segments = lineText.Split(delimiter);
                        var area = segments[0];
                        var branch = segments[1];
                        var cardNumber = segments[2];
                        var noOfBranch = segments[3];
                        writer.WriteStartElement("Unit");
                        string name = "Card" + (i - 1).ToString("0000");
                        writer.WriteAttributeString("Name", name);
                        writer.WriteAttributeString("Type", "Card");
                        writer.WriteStartElement("DataFields");
                        //data field Area
                        writer.WriteStartElement("DataField");
                        writer.WriteAttributeString("Name", "Area");
                        writer.WriteStartElement("Value");
                        writer.WriteAttributeString("InputFormat", "Text");
                        writer.WriteRaw(area);
                        writer.WriteEndElement();// end element for Value
                        writer.WriteEndElement();// end element for DataField
                        //data field Branch
                        writer.WriteStartElement("DataField");
                        writer.WriteAttributeString("Name", "Branch");
                        writer.WriteStartElement("Value");
                        writer.WriteAttributeString("InputFormat", "Text");
                        writer.WriteRaw(branch);
                        writer.WriteEndElement();// end element for Value
                        writer.WriteEndElement();// end element for DataField
                        //data field CardNumber
                        writer.WriteStartElement("DataField");
                        writer.WriteAttributeString("Name", "CardNumber");
                        writer.WriteStartElement("Value");
                        writer.WriteAttributeString("InputFormat", "Text");
                        writer.WriteRaw(cardNumber);
                        writer.WriteEndElement();// end element for Value
                        writer.WriteEndElement();// end element for DataField
                        //data field No.ofBranch
                        writer.WriteStartElement("DataField");
                        writer.WriteAttributeString("Name", "No.ofBranch");
                        writer.WriteStartElement("Value");
                        writer.WriteAttributeString("InputFormat", "Text");
                        writer.WriteRaw(noOfBranch);
                        writer.WriteEndElement();// end element for Value
                        writer.WriteEndElement();// end element for DataField

                        writer.WriteEndElement();// end element for DataFields
                        writer.WriteEndElement();// end element for Unit
                    }
                    writer.WriteEndElement();// end element for Unit at the top
                    writer.WriteEndElement();// end element for Units
                    writer.WriteEndElement();// end element for InputData
                    writer.WriteEndDocument();
                    writer.Flush();
                }
                sr.Close();
                xmlProgressBar.Value = 100;
                MessageBox.Show("读写完成!");
                xmlProgressBar.Value = 0;
                xmlProgressBar.Visible = false;
            }

        }
        /// <summary>
        /// load encoding list
        /// </summary>
        private void loadEncodingList()
        {
            EncodingComboBox.Items.Clear();
            foreach (EncodingInfo ei in Encoding.GetEncodings())
            {
                //Encoding e = ei.GetEncoding();
                EncodingComboBox.Items.Add(ei.Name);
            }
            DelimiterComboBox.Items.Clear();
            foreach (var name in Enum.GetNames(typeof(delimiterEnum))) {
                DelimiterComboBox.Items.Add(name);
            }

        }
        private Encoding csvEncoding = Encoding.UTF8;
        private void EncodingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            csvEncoding = Encoding.GetEncoding(EncodingComboBox.Text);
        }

        private void DelimiterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            delimiter = (char)Enum.Parse(typeof(delimiterEnum), DelimiterComboBox.Text);
        }
    }
}
