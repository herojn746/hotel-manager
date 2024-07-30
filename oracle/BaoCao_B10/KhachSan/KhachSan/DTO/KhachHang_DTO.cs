using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachSan.DTO
{
    public class KhachHang_DTO
    {
        private string maKH { get; set; }
        private string tenKH { get; set; }
        private string sdt { get; set; }
        private string cmnd { get; set;}
        private string gioiTinh { get; set; }

        public void setMaKH(string maKH)
        {
            this.maKH = maKH;
        }

        public string getMaKH()
        {
            return this.maKH;
        }

        public void setTenKH(string maKH)
        {
            this.tenKH = maKH;
        }

        public string getTenKH()
        {
            return this.tenKH;
        }

        public void setSDT(string maKH)
        {
            this.sdt = maKH;
        }

        public string getSDT()
        {
            return this.sdt;
        }

        public void setCMND(string maKH)
        {
            this.cmnd = maKH;
        }

        public string getCMND()
        {
            return this.cmnd;
        }

        public void setGioiTinh(string maKH)
        {
            this.gioiTinh = maKH;
        }

        public string getGioiTinh()
        {
            return this.gioiTinh;
        }
    }
}
