using KhachSan.DAO;
using KhachSan.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KhachSan.GUI
{
    public partial class KhachHang_GUI : Form
    {
        public KhachHang_GUI()
        {
            InitializeComponent();
            btn_delete.Enabled = false;
            btn_edit.Enabled = false;

            comboBox_sex.DataSource = new string[]
            {
                "Nam", "Nữ"
            };

            cbb_search.DataSource = new string[]
            {
                "Theo mã khách", "Theo họ tên", "Theo sdt", "Theo cmnd"
            };


            this.load_table_KhachHang(null);
        }

        private void define_column_table()
        {
            table_customer.ColumnCount = 5;
            table_customer.Columns[0].HeaderText = "Mã khách hàng";
            table_customer.Columns[1].HeaderText = "Tên khách hàng";
            table_customer.Columns[2].HeaderText = "SDT";
            table_customer.Columns[3].HeaderText = "CMND";
            table_customer.Columns[4].HeaderText = "Giới tính";
        }

        private void load_table_KhachHang(List<KhachHang_DTO> list)
        {
            define_column_table();
            table_customer.Rows.Clear();


            if (list != null)
            {
                foreach (KhachHang_DTO khach in list)
                {
                    table_customer.Rows.Add(new string[]
                    {
                        khach.getMaKH(),
                        khach.getTenKH(),
                        khach.getSDT(),
                        khach.getCMND(),
                        khach.getGioiTinh()
                    });
                }
            }
            else
            {
                List<KhachHang_DTO> list_KH = KhachHang_DAO.getKhachHang();
                foreach (KhachHang_DTO khach in list_KH)
                {
                    table_customer.Rows.Add(new string[]
                    {
                        khach.getMaKH(),
                        khach.getTenKH(),
                        khach.getSDT(),
                        khach.getCMND(),
                        khach.getGioiTinh()
                    });
                }
            }
        }

        private void customer_Load(object sender, EventArgs e)
        {

        }

        private List<TextBox> l_text()
        {
            List<TextBox> list = new List<TextBox>();
            list.Add(txt_cmnd);
            list.Add(txt_id);
            list.Add(txt_name);
            list.Add(txt_numberPhone);
            return list;
        }

        private void reset_All()
        {
            List<TextBox> list = this.l_text();
            foreach (TextBox text in this.l_text())
            {
                text.Text = string.Empty;
            }
            txt_search.Text = string.Empty;
            txt_id.Focus();
            this.load_table_KhachHang(null);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            List<TextBox> ltext = this.l_text();
            foreach (TextBox text in ltext)
            {
                if (text.Text == "")
                {
                    MessageBox.Show("Hãy nhập đầy đủ dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string maKH = this.txt_id.Text;
            string hotenKH = this.txt_name.Text;
            string sdt = this.txt_numberPhone.Text;
            string cmnd = this.txt_cmnd.Text;
            string gioiTinh = this.comboBox_sex.Text;

            if (KhachHang_DAO.add_new_khachHang(maKH, hotenKH, sdt, cmnd, gioiTinh))
            {
                this.load_table_KhachHang(null);
            }
            else
            {
                MessageBox.Show("Lỗi hệ thống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_numberPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            char[] vietnameseSigns = new char[] { 'ắ', 'ằ', 'ẳ', 'ẵ', 'ặ', 'ấ', 'ầ', 'ẩ', 'ẫ', 'ậ', 'ế', 'ề', 'ể', 'ễ', 'ệ', 'ố', 'ồ', 'ổ', 'ỗ', 'ộ', 'ớ', 'ờ', 'ở', 'ỡ', 'ợ', 'ứ', 'ừ', 'ử', 'ữ', 'ự', 'ắ', 'ằ', 'ẳ', 'ẵ', 'ặ', 'đ', 'Đ' };


            if (vietnameseSigns.Contains(e.KeyChar))
            {

                e.Handled = true;
            }
        }


        private void search()
        {
            string searchTheo = "";
            string valueCbbSearch = cbb_search.Text;
            if (valueCbbSearch == "Theo mã khách")
            {
                searchTheo = "Ma_KH";
            }
            else if (valueCbbSearch == "Theo họ tên")
            {
                searchTheo = "HoTen";
            }
            else if (valueCbbSearch == "Theo sdt")
            {
                searchTheo = "SDT";
            }
            else
            {
                if (valueCbbSearch == "Theo cmnd")
                {
                    searchTheo = "CMND";
                }
            }

            List<KhachHang_DTO> list = KhachHang_DAO.search_KhachHang(searchTheo, txt_search.Text);
            this.load_table_KhachHang(list);
        }

        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            this.search();
        }

        private void cbb_search_TextChanged(object sender, EventArgs e)
        {
            this.search();
        }


        private void table_customer_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            DataGridView table = sender as DataGridView;
            if (table.CurrentCell.Selected)
            {
                DataGridViewRow row = table.CurrentRow;
                txt_id.Text = row.Cells[0].Value.ToString();
                txt_name.Text = row.Cells[1].Value.ToString();
                txt_numberPhone.Text = row.Cells[2].Value.ToString();
                txt_cmnd.Text = row.Cells[3].Value.ToString();
                comboBox_sex.Text = row.Cells[4].Value.ToString() == "Nữ" ? "Nữ" : "Nam";
                btn_edit.Enabled = true;
                btn_delete.Enabled = true;
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (txt_id.Text == "")
            {
                MessageBox.Show("Mã khách hàng phải được nhập !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (MessageBox.Show("Đồng ý xoá " + txt_id.Text + ": " + txt_name.Text + " ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    if (KhachHang_DAO.xoaKH(txt_id.Text.Trim()))
                    {
                        MessageBox.Show("Xóa thành công.");
                        this.reset_All();
                    }
                    else
                        MessageBox.Show("Xóa thất bại !!!");
                }

            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            List<TextBox> ltext = this.l_text();
            foreach (TextBox text in ltext)
            {
                if (text.Text == "")
                {
                    MessageBox.Show("Hãy nhập đầy đủ dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (KhachHang_DAO.suaKH(txt_id.Text.Trim(), txt_name.Text.Trim(), txt_numberPhone.Text.Trim(), txt_cmnd.Text.Trim(), comboBox_sex.Text.Trim()))
            {
                MessageBox.Show("Sửa thành công.");
                this.load_table_KhachHang(null);
            }
            else
                MessageBox.Show("Sửa thất bại !!!");

        }
    }
}
