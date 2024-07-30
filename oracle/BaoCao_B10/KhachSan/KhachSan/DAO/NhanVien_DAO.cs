using KhachSan.DTO;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachSan.DAO
{
    internal class NhanVien_DAO:dataProvider
    {
        public static List<NhanVien_DTO> Employee()
        {
            List<NhanVien_DTO> emp = new List<NhanVien_DTO>();
            OracleDataReader result = get_Employee(DN.url + DN.User + "; PASSWORD = " + DN.pass);
            if (result != null)
            {
                while (result.Read())
                {
                    NhanVien_DTO employee = new NhanVien_DTO();
                    employee.setMaNV(result.GetString(0));
                    employee.setEmail(result.GetString(1));
                    employee.setSDT(result.GetString(2));
                    employee.setCMND(result.GetString(3));
                    employee.setTenNV(result.GetString(4));
                    employee.setNgaySinh(result.GetDateTime(5));
                    employee.setChucVu(result.GetString(6));


                    emp.Add(employee);
                }

                CloseConnection();
                result.Close();

                return emp;
            }
            return null;
        }

        public static bool insert_Employee(string maNV, string email, string sdt, string CMND, string hoten, DateTime ngaysinh, string chucvu)
        {
            bool result = add_Employee(maNV, email, sdt, CMND, hoten, ngaysinh, chucvu, DN.url + DN.User + "; PASSWORD = " + DN.pass);
            CloseConnection();
            return result;
        }

        public static bool edit_Employee(string maNV, string email, string sdt, string CMND, string hoten, DateTime ngaysinh, string chucvu)
        {
            bool result = update_Employee(maNV, email,  sdt, CMND, hoten, ngaysinh, chucvu, DN.url + DN.User + "; PASSWORD = " + DN.pass);
            CloseConnection();
            return result;
        }
        public static bool delete_Employee(string maNV)
        {
            bool result = xoa_Employee(maNV, DN.url + DN.User + "; PASSWORD = " + DN.pass);
            CloseConnection();
            return result;
        }
    }
}
