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
    public partial class ThongTinSinhVien : Form
    {
        private DataSet dataSet;
        private bool editInterface = false;
        private bool EditInterface
        {
            get { return editInterface; }
            set
            {
                gridviewSV.ReadOnly = !value;
                btnThem.Enabled = !value;
                btnSua.Text = value ? "HỦY" : "SỬA";
                btnXoa.Enabled = !value;
                btnTim.Enabled = !value;
                btnWrite.Enabled = !value;
                btnRead.Enabled = !value;
                tbMa.Enabled = !value;
                tbTen.Enabled = !value;
                tbLop.Enabled = !value;
                tbNoisinh.Enabled = !value;
                tbTim.Enabled = !value;
            }
        }
        private bool EmptyTextBox
        {
            get
            {
                if (tbMa.Text.Length > 0 || tbTen.Text.Length > 0 || tbLop.Text.Length > 0 ||
                    tbNoisinh.Text.Length > 0) return false;
                else return true;
            }
            set
            {
                if (value)
                {
                    tbMa.Text = "";
                    tbTen.Text = "";
                    tbLop.Text = "";
                    tbNoisinh.Text = "";
                }
            }
        }
        public ThongTinSinhVien()
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
                if (dataSet.Tables.Count > 0) dataSet = new DataSet();
                dataSet.ReadXml("../../SinhVien.xml", XmlReadMode.Auto);
                gridviewSV.DataSource = dataSet.Tables[0];
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
                dataSet.WriteXml("../../SinhVien.xml", XmlWriteMode.IgnoreSchema);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xảy ra khi ghi file: " + ex.ToString());
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (gridviewSV.ReadOnly)
                EditInterface = true;
            else
                EditInterface = false;
        }
        //Button thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dataSet == null || EmptyTextBox)
            {
                MessageBox.Show("Nhập đủ thông tin vào textbox!");
                return;
            }
            else
            {
                dataSet.Tables[0].Rows.Add(tbMa.Text, tbTen.Text, tbLop.Text, tbNoisinh.Text);
                EmptyTextBox = true;
            }
        }
        //nut xoa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gridviewSV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hãy chọn dòng cần xóa!");
                return;
            }
            DialogResult = MessageBox.Show("Bạn có chắc muốn xóa!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                dataSet.Tables[0].Rows.RemoveAt(gridviewSV.SelectedRows[0].Index);
            }
        }

        private void ThongSinhVien_Load(object sender, EventArgs e)
        {
            EditInterface = false;
        }
    }
}
