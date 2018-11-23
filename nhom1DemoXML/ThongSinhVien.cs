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
        // nut thoat
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (dataSet.Tables.Count > 0) return;
                dataSet.ReadXml("../../sinhvien.xml", XmlReadMode.Auto);
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
                dataSet.WriteXml("../../sinhvien.xml", XmlWriteMode.IgnoreSchema);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xảy ra khi ghi file: " + ex.ToString());
            }
        }

        private void gridSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int t = gridSach.CurrentCell.RowIndex;
            tbMa.Text = gridSach.Rows[t].Cells[0].Value.ToString();
            tbTen.Text = gridSach.Rows[t].Cells[1].Value.ToString();
            tbLop.Text = gridSach.Rows[t].Cells[2].Value.ToString();
            tbNoisinh.Text = gridSach.Rows[t].Cells[3].Value.ToString();
        }
        private int chon = 0;
        //nut sua
        private void btnSua_Click(object sender, EventArgs e)
        {

            chon = 2;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

        }
        //Button thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            chon = 1;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }
        //nut xoa
        private void btnXoa_Click(object sender, EventArgs e)
        {       
                DialogResult = MessageBox.Show("Bạn có chắc muốn xóa!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (DialogResult == DialogResult.OK)
                {
                    
                }
        }
        //nut luu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (chon == 1) // gọi Button Thêm
            {
                
            }
            else if (chon == 2)// gọi Button Sửa 
            {
                
            }
            else
            {
                chon = 0;
            }
        }
    }
}
