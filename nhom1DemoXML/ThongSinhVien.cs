using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace nhom1DemoXML
{
    public partial class ThongSinhVien : Form
    {
        public ThongSinhVien()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            
                try
                {
                    XmlReader xmlFile;
         
                xmlFile = XmlReader.Create("E:/TAI LIEU DAI HOC/HOC KI 7/CONG NGHE XML VA UNG DUNG/BAI GIUA KI NHOM/PROJECT/nhom1DemoXML/test.xml", new XmlReaderSettings());
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXml(xmlFile);
                    gridSach.DataSource = dataSet.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xảy ra khi đọc file: " + ex.ToString());
                }
            
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            //try
            //{
                
            //    XmlWriter xmlFile;

            //    xmlFile = XmlWriter.Create("E:/TAI LIEU DAI HOC/HOC KI 7/CONG NGHE XML VA UNG DUNG/BAI GIUA KI NHOM/PROJECT/nhom1DemoXML/test.xml", new XmlWriterSettings());
            //    DataSet dataSet = new DataSet();
            //    gridSach.DataSource = dataSet.Tables[0];
            //    dataSet.WriteXml(xmlFile, XmlWriteMode.IgnoreSchema);
                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi xảy ra khi ghi file: " + ex.ToString());
            //}
        }
    }
}
