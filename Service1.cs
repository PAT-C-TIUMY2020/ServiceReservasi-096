using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceReservasi
{
    public class Service1 : IService1
    {
        string constr = "Data Source=DESKTOP-OHHGQ54; Initial Catalog=WCFReservasi; Persist Security Info=True; User ID=sa; Password=afinzajagoan";
        SqlConnection connection;
        SqlCommand com;

        public List<DataRegister> DataRegist()
        {
            List<DataRegister> list = new List<DataRegister>();
            try
            {
                string sql = "select ID_login, Username, Password, Kategori from dbo.Login";
                connection = new SqlConnection(constr);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DataRegister data = new DataRegister();
                    data.id = reader.GetInt32(0);
                    data.username = reader.GetString(1);
                    data.password = reader.GetString(2);
                    data.kategori = reader.GetString(3);
                    list.Add(data);
                }
                connection.Close();
            }
            catch (Exception ep)
            {
                ep.ToString();
            }
            return list;

        }

        public string deletepemesanan(string IDPemesanan)
        {
            string a = "gagal";
            try
            {
                string sql = "delete from dbo.Pemesanan where ID_reservasi = '" + IDPemesanan + "'";
                connection = new SqlConnection(constr);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "sukses";

            }
            catch (Exception ep)
            {
                Console.WriteLine(ep);
            }
            return a;
        }

        public string DeleteRegister(string username)
        {
            int id = 0;
            string sql = "select ID_login from dbo.Login where Username = '" + username + "'";
            connection = new SqlConnection(constr);
            com = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                id = reader.GetInt32(0);
            }
            connection.Close();
            string sql2 = "delete from dbo.Login where ID_login = " + id + "";
            connection = new SqlConnection(constr);
            com = new SqlCommand(sql2, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();

            return "sukses";
        }

        public List<DetailLokasi> DetailLokasi()
        {
            List<DetailLokasi> lokasiFull = new List<DetailLokasi>();
            try
            {
                string sql = "select ID_lokasi, Nama_lokasi, Deskripsi_full, Kuota from dbo.Lokasi";
                connection = new SqlConnection(constr);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DetailLokasi data = new DetailLokasi();
                    data.IDlokasi = reader.GetString(0);
                    data.NamaLokasi = reader.GetString(1);
                    data.DeskripsiFull = reader.GetString(2);
                    data.Kuota = reader.GetInt32(3);
                    lokasiFull.Add(data);

                }
            } catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return lokasiFull;
        }

        public string editpemesanan(string IDPemesanan, string NamaCustomer, string No_telpon)
        {
            string a = "gagal";
            try
            {
                string sql = "update dbo.Pemesanan set Nama_Customer = '" + NamaCustomer + "', No_telpon = '" + No_telpon + "' where ID_reservasi = '" + IDPemesanan + "'";
                connection = new SqlConnection(constr);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "sukses";

            }
            catch (Exception ep)
            {
                Console.WriteLine(ep);
            }
            return a;
        }

        public string Login(string username, string pasword)
        {
            string kategori = "";
            string sql = "select Kategori from dbo.Login where Username='" + username + "' and Password='" + pasword + "'";
            connection = new SqlConnection(constr);
            com = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                kategori = reader.GetString(0);
            }

            return kategori;
        }

        public string pemesanan(string IDPemesanan, string NamaCustomer, string Notelpon, int JumlahPemesanan, string IDLokasi)
        {
            string a = "gagal";
            try
            {
                string sql = "insert into dbo.Pemesanan values('" + IDPemesanan + "', '" + NamaCustomer + "', '" + Notelpon + "', " + JumlahPemesanan + ", '" + IDLokasi + "')";
                connection = new SqlConnection(constr);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                string sql2 = "update dbo.Lokasi set Kuota = Kuota - " + JumlahPemesanan + "where ID_lokasi = '" + IDLokasi + "'";
                connection = new SqlConnection(constr);
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "sukses";

            } catch(Exception ep)
            {
                Console.WriteLine(ep);
            }
            return a;
        }

        public List<Pemesanan> Pemesanan()
        {
            List<Pemesanan> pemesanas = new List<Pemesanan>();
            try
            {
                string sql = "select ID_reservasi, Nama_customer, No_telpon, Jumlah_pemesanan, Nama_Lokasi from dbo.Pemesanan p join dbo.Lokasi l on p.ID_lokasi = l.ID_lokasi";
                connection = new SqlConnection(constr);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Pemesanan data = new Pemesanan();
                    data.IDPemesanan = reader.GetString(0);
                    data.NamaCustomer = reader.GetString(1);
                    data.NoTelpon = reader.GetString(2);
                    data.JumlahPemesanan = reader.GetInt32(3);
                    data.IDLokasi = reader.GetString(4);
                    pemesanas.Add(data);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return pemesanas;
        }

        public string Register(string username, string pasword, string kategori)
        {
            try
            {
                string sql = "insert into dbo.Login values ('" + username + "', '" + pasword + "', '" + kategori + "')";
                connection = new SqlConnection(constr);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                return "sukses";
            } catch (Exception e)
            {
                return e.ToString();
            }
        }

        public List<CekLokasi> ReviewLokasi()
        {
            throw new NotImplementedException();
        }

        public string UpdateRegister(string username, string pasword, string kategori, int id)
        {
            try
            {
                string sql = "update dbo.Login set Username = '" + username + "', Password = '" + pasword + "', Kategori = '" + kategori + "' where ID_login = " + id + "";
                connection = new SqlConnection(constr);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                return "sukses";

            }
            catch (Exception ep)
            {
                return ep.ToString();
            }
        }
    }
}
