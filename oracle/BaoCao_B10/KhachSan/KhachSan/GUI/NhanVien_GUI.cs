using KhachSan.DAO;
using KhachSan.DTO;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KhachSan.GUI
{
    
    public partial class NhanVien_GUI : Form
    {
        private static string user = "HUUNAM66TEST";
        private static string password = "123";
        string connectionString = "DATA SOURCE=localhost:1521/XE;USER ID=" + user + ";PASSWORD=" + password;
        List<NhanVien_DTO> emp = NhanVien_DAO.Employee();
        public NhanVien_GUI()
        {
            InitializeComponent();
            employee_Load(emp);
            CBB_Employee_Load();
        }

         

        private void define_Column_Table()
        {
            table_employee.ColumnCount = 7;
            table_employee.Columns[0].HeaderText = "Mã Nhân Viên";
            table_employee.Columns[1].HeaderText = "Email";
            table_employee.Columns[2].HeaderText = "SDT";
            table_employee.Columns[3].HeaderText = "CMND";
            table_employee.Columns[4].HeaderText = "Họ tên";
            table_employee.Columns[5].HeaderText = "Ngày sinh";
            table_employee.Columns[6].HeaderText = "Chức vụ";
        }

         
        private void CBB_Employee_Load()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Value", typeof(int));
            table.Columns.Add("Text", typeof(string));
            table.Rows.Add(0, "Nhan vien");
            table.Rows.Add(1, "Quan ly");

            cbb_chucvu.DataSource = table;

            cbb_chucvu.DisplayMember = "Text";
            cbb_chucvu.ValueMember = "Text";

            
        }
        private void employee_Load(List<NhanVien_DTO> emp)
        {
            this.define_Column_Table();
            table_employee.Rows.Clear();
            if (emp != null)
            {
                foreach (NhanVien_DTO room in emp)
                {
                    table_employee.Rows.Add(new string[]
                    {
                        room.getMaNV(),
                        room.getEmail(),
                        room.getSDT(),
                        room.getCMND(),
                        room.getTenNV(),
                        room.getNgaySinh().ToString(),
                        room.getChucVu(),

                    });
                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {


            string maNV = txt_id.Text;
            string email = txt_email.Text;  
            string sdt = txt_numberPhone.Text;
            string cmnd = txt_cmnd.Text;
            string hoTen = txt_name.Text;
            DateTime ngaySinh = DateTime.Parse(dateTimePicker_birthDay.Text);
            string chucVu = cbb_chucvu.SelectedValue.ToString();

            if (NhanVien_DAO.insert_Employee(maNV, email, sdt, cmnd, hoTen, ngaySinh, chucVu))
            {
                this.reset_All();
            }
            else
            {
                MessageBox.Show("Thêm đầy đủ các trường!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void reset_All()
        {
            txt_id.Text = string.Empty;
            txt_email.Text = string.Empty;
            txt_numberPhone.Text = string.Empty;
            txt_cmnd.Text = string.Empty;
            txt_name.Text = string.Empty;
             
            List<NhanVien_DTO> emps = NhanVien_DAO.Employee();
            this.employee_Load(emps);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DataGridView table = table_employee;
            if (table.CurrentCell.Selected)
            {
                string maNV = table.CurrentRow.Cells[0].Value.ToString();
                string tenNV = table.CurrentRow.Cells[4].Value.ToString();
                if (MessageBox.Show("Đồng ý xoá nhân viên có mã:  " + maNV + ", tên: " + tenNV + " ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (NhanVien_DAO.xoa_Employee(maNV, DN.url + DN.User + "; PASSWORD = " + DN.pass))
                    {
                        this.reset_All();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi hệ thống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (txt_id.Text == "" || txt_email.Text == "" || txt_name.Text == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                string maNV = txt_id.Text;
                string email = txt_email.Text;
                string sdt = txt_numberPhone.Text;
                string cmnd = txt_cmnd.Text;
                string hoTen = txt_name.Text;
                DateTime ngaySinh = DateTime.Parse(dateTimePicker_birthDay.Text);
                string chucVu = cbb_chucvu.SelectedIndex.ToString();

                if (NhanVien_DAO.edit_Employee(maNV, email, sdt, cmnd, hoTen, ngaySinh, chucVu))
                {
                    this.reset_All();
                    MessageBox.Show("Thay đổi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Lỗi hệ thống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void table_employee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView table = sender as DataGridView;
            if (table.CurrentCell.Selected)
            {
                DataGridViewRow row = table.CurrentRow;
                txt_id.Text = row.Cells[0].Value.ToString();
                txt_email.Text = row.Cells[1].Value.ToString();
                txt_numberPhone.Text = row.Cells[2].Value.ToString();
                txt_cmnd.Text = row.Cells[3].Value.ToString();
                txt_name.Text = row.Cells[4].Value.ToString();
                dateTimePicker_birthDay.Text = row.Cells[5].Value.ToString();
                cbb_chucvu.Text = row.Cells[6].Value.ToString();
            }

             
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string employeeId = txt_id.Text.Trim();
            // Tạo kết nối Oracle
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                // Mở kết nối
                connection.Open();

                // Tạo Command để gọi function
                using (OracleCommand command = new OracleCommand("search_employee_by_id", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("p_employee_id", OracleDbType.NVarchar2).Value = employeeId;

                    OracleParameter pResult = new OracleParameter("p_refcursor", OracleDbType.RefCursor);
                    pResult.Direction = ParameterDirection.Output;
                    command.Parameters.Add(pResult);

                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        //List<NhanVien_DTO> emps = Employee_DAO.Employee();
                        //this.employee_Load(emps);
                        DataTable result = new DataTable();
                        adapter.Fill(result);

                        if (result.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy kết quả nào!");
                        }
                        else
                        {
                            string[] tencot = { "Mã Nhân Viên", "Email", "SDT", "CMND", "Họ tên", "Ngày sinh", "Chức vụ" };

                            foreach (string tencotxoa in tencot)
                            {
                                foreach (DataGridViewColumn column in table_employee.Columns)
                                {
                                    if (column.HeaderText == tencotxoa)
                                    {
                                        table_employee.Columns.Remove(column);
                                        break;
                                    }

                                }
                                table_employee.DataSource = result;
                            }

                        }
                    }
                }

            }
        }

        private void NhanVien_GUI_Load(object sender, EventArgs e)
        {

        }
    }
}
