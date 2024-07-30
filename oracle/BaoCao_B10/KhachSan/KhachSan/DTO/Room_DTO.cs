using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachSan.DTO
{
    public class Room_DTO
    {
        private string maPhong { get; set; }
        private string tenPhong { get; set; }
        private double giaPhong { get; set; }
        private double phiDatPhong { get; set; }
        private int tinhTrang { get; set; }

        public Room_DTO() {
            this.maPhong = "";
            this.tenPhong = "";
            this.giaPhong = 0;
            this.phiDatPhong = 0;
            this.tinhTrang = 0;
        }


        public void setMaPhong(string maPhong)
        {
            this.maPhong = maPhong;
        }

        public string getMaPhong()
        {
            return this.maPhong;
        }

        public void setTenPhong(string tenPhong)
        {
            this.tenPhong = tenPhong;
        }

        public string getTenPhong()
        {
            return this.tenPhong;
        }

        public void setGiaPhong(double giaPhong)
        {
            this.giaPhong = giaPhong;    
        }

        public double getGiaPhong()
        {
            return this.giaPhong;
        }

        public void setPhiDatPhong(double phiDatPhong)
        {
            this.phiDatPhong = phiDatPhong;
        }

        public double getPhiDatPhong()
        {
            return this.phiDatPhong;
        }

        public void setTinhTrang(int tinhTrang)
        {
            this.tinhTrang = tinhTrang;
        }

        public int getTinhTrang()
        {
            return this.tinhTrang;
        }
    }
}
