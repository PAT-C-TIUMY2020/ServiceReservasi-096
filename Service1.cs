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

        public List<CekLokasi> ReviewLokasi()
        {
            throw new NotImplementedException();
        }
    }
}
