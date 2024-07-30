using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Security.Policy;
using System.Data;
using System.Windows.Forms;


namespace KhachSan.DAO
{

    public class dataProvider
    {
        private static OracleConnection connect = null;
       

        protected static OracleDataReader getResult(string query,String URL)
        {
            try
            {
                connect = new OracleConnection(URL);
                connect.Open();

                OracleCommand command = new OracleCommand(query, connect);
                return command.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        //ROOM

        protected static bool add_ROOM(string maPhong, string tenPhong, float giaPhong, float phiDatPhong, String URL)
        {
            try
            {
                connect = new OracleConnection(URL);
                connect.Open();
                OracleCommand command = new OracleCommand("ADD_ROOM", connect);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("Ma_Phong", OracleDbType.Varchar2).Value = maPhong;
                command.Parameters.Add("Ten_Phong", OracleDbType.Varchar2).Value = tenPhong;
                command.Parameters.Add("Gia", OracleDbType.BinaryFloat).Value = giaPhong;
                command.Parameters.Add("Phi_Dat_Phong", OracleDbType.BinaryFloat).Value = phiDatPhong;
                int result = command.ExecuteNonQuery();
                CloseConnection();
                command.Clone();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        protected static bool edit_ROOM(string maPhong, string tenPhong, float giaPhong, float phiDatPhong, String URL)
        {
            try
            {
                connect = new OracleConnection(URL);
                connect.Open();
                OracleCommand cmd = new OracleCommand("EDIT_ROOM", connect);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_ma_phong", OracleDbType.Varchar2).Value = maPhong;
                cmd.Parameters.Add("p_ten_phong", OracleDbType.NVarchar2).Value = tenPhong;
                cmd.Parameters.Add("p_gia", OracleDbType.Decimal).Value = giaPhong;
                cmd.Parameters.Add("p_phi_dat_phong", OracleDbType.Decimal).Value = phiDatPhong;
                cmd.ExecuteNonQuery();
                CloseConnection();
                cmd.Clone();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        protected static bool xoa_ROOM(string maPhong, String URL)
        {
            try
            {
                connect = new OracleConnection(URL);
                connect.Open();
                OracleCommand command = new OracleCommand("XOA_ROOM", connect);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("Ma_Phong", OracleDbType.Varchar2).Value = maPhong;
                int result = command.ExecuteNonQuery();
                CloseConnection();
                command.Clone();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        protected static OracleDataReader get_ROOM(String URL)
        {
            try
            {
                connect = new OracleConnection(URL);
                connect.Open();

                OracleCommand command = new OracleCommand("display_room_info_func", connect);
                command.CommandType = CommandType.StoredProcedure;

                //OracleParameter outParameter = new OracleParameter();
                //outParameter.ParameterName = "p_cursor";
                //outParameter.Direction = ParameterDirection.Output;
                //outParameter.OracleDbType = OracleDbType.RefCursor;

                //command.Parameters.Add(outParameter);

                command.Parameters.Add("table_cursor", OracleDbType.RefCursor).Direction= ParameterDirection.ReturnValue;

                return command.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        protected static void CloseConnection()
        {
            if (connect != null)
            {
                connect.Close();
            }
        }
      

        //LOGIN

        public static String kt(String user,String pass, String URL)
        {
            string procedureName = "check_account";
            String p="";
            connect = new OracleConnection(URL);
            

            OracleCommand command = new OracleCommand(procedureName, connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("p_user", OracleDbType.Varchar2).Value = user;
            command.Parameters.Add("p_password", OracleDbType.Varchar2).Value = pass;
            command.Parameters.Add("p_result", OracleDbType.Int32).Direction = ParameterDirection.Output;
            try
            {
                

                connect.Open();
                command.ExecuteNonQuery();
                p= Convert.ToString(command.Parameters["p_result"].Value);

              
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi khi có ngoại lệ xảy ra
                    Console.WriteLine("ERROR:"+ex.Message);
                }
            return p;
        }
        public static void getName(String user, String URL)
        {
            string procedureName = "get_nhanvien_name";
            String p = "";
            connect = new OracleConnection(URL);


            OracleCommand command = new OracleCommand(procedureName, connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("p_nhanvien_id", OracleDbType.Varchar2).Value = user;
            command.Parameters.Add("p_nhanvien_name", OracleDbType.NVarchar2).Direction = ParameterDirection.Output;
            try
            {


                connect.Open();
                command.ExecuteNonQuery();
                p = command.Parameters["p_nhanvien_id"].Value.ToString();
                if (p.Equals(""))
                {
                    Console.WriteLine("Lỗi gì zị");
                }
                else
                {
                    Console.WriteLine("Tên:"+p.Trim());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
      
        public static int check_connectDBA(String use,String pass)
        {
            int y= 9999;
            try
            {
                connect = new OracleConnection(DN.url+ use + ";PASSWORD=" + pass);
                connect.Open();
                MessageBox.Show("Thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                y = 1;

            }
            catch { MessageBox.Show("Nhập sai tên đăng nhập hoặc mật khẩu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            return y;
        }



        //KHACH HANG


        protected static OracleDataReader get_KhachHang(String URL)
        {
            try
            {
                connect = new OracleConnection(URL);
                connect.Open();

                OracleCommand command = new OracleCommand("get_table_KhachHang_func", connect);
                command.CommandType = CommandType.StoredProcedure;

                //OracleParameter outParameter = new OracleParameter();
                //outParameter.ParameterName = "table_cursor";
                //outParameter.OracleDbType = OracleDbType.RefCursor;
                //outParameter.Direction = ParameterDirection.ReturnValue;

                //command.Parameters.Add(outParameter);

                command.Parameters.Add("table_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.ReturnValue;


                return command.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        protected static bool add_KH(string maKH, string tenKH, string sdt, string cmnd, string gioiTinh, String URL)
        {
            try
            {
                connect = new OracleConnection(URL);
                connect.Open();

                OracleCommand command = new OracleCommand("add_KhachHang", connect);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("maKH", OracleDbType.Varchar2).Value = maKH;
                command.Parameters.Add("tenKH", OracleDbType.NVarchar2).Value = tenKH;
                command.Parameters.Add("sdt", OracleDbType.Varchar2).Value = sdt;
                command.Parameters.Add("cmnd", OracleDbType.Varchar2).Value = cmnd;
                command.Parameters.Add("gioiTinh", OracleDbType.NVarchar2).Value = gioiTinh;
                command.Parameters.Add("result", OracleDbType.Int32).Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();

                return int.Parse(command.Parameters["result"].Value.ToString()) == 1 ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }




        public static bool suaKhachHang(string maKh, string hoTen, string sdt, string cmnd, string gioiTinh, String URL)
        {
            try
            {
                connect = new OracleConnection(URL);
                connect.Open();
                OracleCommand cmd = new OracleCommand("UPDATE_KHACHHANG", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_ma_kh", OracleDbType.Varchar2).Value = maKh;
                cmd.Parameters.Add("p_hoten", OracleDbType.Varchar2).Value = hoTen;
                cmd.Parameters.Add("p_sdt", OracleDbType.Varchar2).Value = sdt;
                cmd.Parameters.Add("p_cmnd", OracleDbType.Varchar2).Value = cmnd;
                cmd.Parameters.Add("p_gioi_tinh", OracleDbType.Varchar2).Value = gioiTinh;
                cmd.ExecuteNonQuery();
                CloseConnection();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }



        public static bool xoaKhachHang(string maKh, String URL)
        {
            try
            {
                connect = new OracleConnection(URL);
                connect.Open();
                OracleCommand cmd = new OracleCommand("DELETE_KHACHHANG", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_ma_kh", OracleDbType.Varchar2).Value = maKh;
                cmd.ExecuteNonQuery();
                CloseConnection();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }






        //=============================employee=============================
        public static OracleDataReader get_Employee(String URL)
        {
            try
            {
                connect = new OracleConnection(URL);
                connect.Open();

                OracleCommand command = new OracleCommand("display_NhanVien_info_func", connect);
                command.CommandType = CommandType.StoredProcedure;

                //OracleParameter outParameter = new OracleParameter();
                //outParameter.ParameterName = "nv_cursor";
                //outParameter.Direction = ParameterDirection.Output;
                //outParameter.OracleDbType = OracleDbType.RefCursor;

                //command.Parameters.Add(outParameter);

                command.Parameters.Add("table_cursor", OracleDbType.RefCursor).Direction= ParameterDirection.ReturnValue;

                return command.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static bool add_Employee(string maNV, string email, string sdt, string CMND, string hoten, DateTime ngaysinh, string chucvu, String URL)
        {
            try
            {
                connect = new OracleConnection(URL);
                connect.Open();
                OracleCommand command = new OracleCommand("them_nhanvien", connect);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("MA_NV", OracleDbType.Varchar2).Value = maNV;
                command.Parameters.Add("EMAIL", OracleDbType.Varchar2).Value = email;
                command.Parameters.Add("SDT", OracleDbType.Varchar2).Value = sdt;
                command.Parameters.Add("CMND", OracleDbType.Varchar2).Value = CMND;
                command.Parameters.Add("HOTEN", OracleDbType.NVarchar2).Value = hoten;
                command.Parameters.Add("NGAYSINH", OracleDbType.Date).Value = ngaysinh;
                command.Parameters.Add("CHUCVU", OracleDbType.NVarchar2).Value = chucvu;

                int result = command.ExecuteNonQuery();
                CloseConnection();
                command.Clone();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool xoa_Employee(string maNV, String URL)
        {
            try
            {
                connect = new OracleConnection(URL);
                connect.Open();
                OracleCommand command = new OracleCommand("xoa_nhanvien", connect);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_Ma_NV", OracleDbType.Varchar2).Value = maNV;
                int result = command.ExecuteNonQuery();
                CloseConnection();
                command.Clone();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool update_Employee(string maNV, string email, string sdt, string CMND, string hoten, DateTime ngaysinh, string chucvu, String URL)
        {
            try
            {
                connect = new OracleConnection(URL);
                connect.Open();
                OracleCommand command = new OracleCommand("sua_nhanvien", connect);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("p_Ma_NV", OracleDbType.Varchar2).Value = maNV;
                command.Parameters.Add("p_Email", OracleDbType.Varchar2).Value = email;
                command.Parameters.Add("p_SDT", OracleDbType.Varchar2).Value = sdt;
                command.Parameters.Add("p_CMND", OracleDbType.Varchar2).Value = CMND;
                command.Parameters.Add("p_HoTen", OracleDbType.NVarchar2).Value = hoten;
                command.Parameters.Add("p_NgaySinh", OracleDbType.Date).Value = ngaysinh;
                command.Parameters.Add("p_ChucVu", OracleDbType.NVarchar2).Value = chucvu;

                command.ExecuteNonQuery();
                CloseConnection();
                command.Clone();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        protected static bool edit_ROOM1(string maPhong, string tenPhong, float giaPhong, float phiDatPhong, String URL)
        {
            try
            {
                connect = new OracleConnection(URL);
                connect.Open();
                OracleCommand cmd = new OracleCommand("EDIT_ROOM", connect);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_ma_phong", OracleDbType.Varchar2).Value = maPhong;
                cmd.Parameters.Add("p_ten_phong", OracleDbType.NVarchar2).Value = tenPhong;
                cmd.Parameters.Add("p_gia", OracleDbType.Decimal).Value = giaPhong;
                cmd.Parameters.Add("p_phi_dat_phong", OracleDbType.Decimal).Value = phiDatPhong;
                cmd.ExecuteNonQuery();
                CloseConnection();
                cmd.Clone();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

    }
}

