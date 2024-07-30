using KhachSan.DTO;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhachSan.DAO
{
    public class Room_DAO : dataProvider
    {
        public static List<Room_DTO> ROOM()
        {
            OracleDataReader result = get_ROOM(DN.url + DN.User + "; PASSWORD = " + DN.pass);
            if (result != null)
            {
                List<Room_DTO> l_Room = new List<Room_DTO>();
                while (result.Read())
                {
                    Room_DTO room = new Room_DTO();
                    room.setMaPhong(result.GetString(0));
                    room.setTenPhong(result.GetString(1));
                    room.setGiaPhong(float.Parse(result.GetString(2)));
                    room.setPhiDatPhong(float.Parse(result.GetString(3)));
                    room.setTinhTrang(int.Parse(result.GetString(4)));

                    l_Room.Add(room);   
                }

                CloseConnection();
                result.Close();

                return l_Room;
            }

            return null;
        }

        public static bool insert_Room(string maPhong, string tenPhong, float giaPhong, float phiDatPhong)
        {
            bool result = add_ROOM(maPhong, tenPhong, giaPhong, phiDatPhong, DN.url + DN.User + "; PASSWORD = " + DN.pass);
            CloseConnection();
            return result;
        }

        public static bool edit_Room(string maPhong, string tenPhong, float giaPhong, float phiDatPhong)
        {
            bool result = edit_ROOM(maPhong, tenPhong, giaPhong, phiDatPhong, DN.url + DN.User + "; PASSWORD = " + DN.pass);
            CloseConnection();
            return result;
        }

        public static bool delete_Room(string maPhong)
        {
            bool result = xoa_ROOM(maPhong, DN.url + DN.User + "; PASSWORD = " + DN.pass);
            CloseConnection();
            return result;
        }
        public static List<Room_DTO> timKiemTheoTen(string tenPhong)
        {
            List<Room_DTO> list = new List<Room_DTO>();
            try
            {
                string query = "select * from room where Ten_Phong like N'%" + tenPhong + "%'";
                OracleDataReader result = getResult(query, DN.url + DN.User + "; PASSWORD = " + DN.pass);
                while (result.Read())
                {
                    Room_DTO room = new Room_DTO();
                    room.setMaPhong(result.GetString(0));
                    room.setTenPhong(result.GetString(1));
                    room.setGiaPhong(float.Parse(result.GetString(2)));
                    room.setPhiDatPhong(float.Parse(result.GetString(3)));
                    room.setTinhTrang(int.Parse(result.GetString(4)));
                    list.Add(room);

                }
                CloseConnection();
                result.Close();
            }
            catch
            {
                Console.WriteLine("Không thể lấy dữ liệu bảng!");
            }
            return list;
        }
        public static List<Room_DTO> timKiemTheoMa(string maPhong)
        {
            List<Room_DTO> list = new List<Room_DTO>();
            try
            {
                string query = "select * from room where Ma_Phong like N'%" + maPhong + "%'";
                OracleDataReader result = getResult(query, DN.url + DN.User + "; PASSWORD = " + DN.pass);
                while (result.Read())
                {
                    Room_DTO room = new Room_DTO();
                    room.setMaPhong(result.GetString(0));
                    room.setTenPhong(result.GetString(1));
                    room.setGiaPhong(float.Parse(result.GetString(2)));
                    room.setPhiDatPhong(float.Parse(result.GetString(3)));
                    room.setTinhTrang(int.Parse(result.GetString(4)));
                    list.Add(room);

                }
                CloseConnection();
                result.Close();
            }
            catch
            {
                Console.WriteLine("Không thể lấy dữ liệu bảng!");
            }
            return list;
        }
    }
}
