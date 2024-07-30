using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachSan.DTO
{
    public class NhanVien_DTO
    {

        private string maNV { get; set; }
        private string tenNV { get; set; }
        private string email { get; set; }
        private string sdt { get; set; }
        private string cmnd { get; set; }
        private DateTime ngaySinh { get; set; }
        private string chucVu { get; set; }

        public void setMaNV(string maNV)
        {
            this.maNV = maNV;
        }

        public string getMaNV()
        {
            return this.maNV;
        }

        public void setTenNV(string maNV)
        {
            this.tenNV = maNV;
        }

        public string getTenNV()
        {
            return this.tenNV;
        }

        public void setEmail(string maNV)
        {
            this.email = maNV;
        }

        public string getEmail()
        {
            return this.email;
        }

        public void setSDT(string maNV)
        {
            this.sdt = maNV;
        }

        public string getSDT()
        {
            return this.sdt;
        }


        public void setCMND(string maNV)
        {
            this.cmnd = maNV;
        }

        public string getCMND()
        {
            return this.cmnd;
        }

        public void setNgaySinh(DateTime maNV)
        {
            this.ngaySinh = maNV;
        }

        public DateTime getNgaySinh()
        {
            return this.ngaySinh;
        }

        public void setChucVu(string maNV)
        {
            this.chucVu = maNV;
        }

        public string getChucVu()
        {
            return this.chucVu;
        }
    }
}
