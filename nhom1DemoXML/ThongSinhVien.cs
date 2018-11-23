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
        private DataSet dataSet;
        public ThongSinhVien()
        {
            InitializeComponent();
            dataSet = new DataSet();
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
                if (dataSet.Tables.Count > 0) return;
                dataSet.ReadXml("../../test.xml", XmlReadMode.Auto);
                gridSach.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xảy ra khi đọc file: " + ex.ToString());
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                dataSet.WriteXml("../../test.xml", XmlWriteMode.IgnoreSchema);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xảy ra khi ghi file: " + ex.ToString());
            }
        }
    }
}
