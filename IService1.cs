using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceReservasi
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string pemesanan(string IDPemesanan, string NamaCustomer, string Notelpon, int JumlahPemesanan, string IDLokasi);

        [OperationContract]
        string editpemesanan(string IDPemesanan, string NamaCustomer, string No_telpon);

        [OperationContract]
        string deletepemesanan(string IDPemesanan);

        [OperationContract]
        List<CekLokasi> ReviewLokasi();

        [OperationContract]
        List<DetailLokasi> DetailLokasi();

        [OperationContract]
        List<Pemesanan> Pemesanan();

        [OperationContract]
        string Login(string username, string pasword);

        [OperationContract]
        string Register(string username, string pasword, string kategori);

        [OperationContract]
        string UpdateRegister(string username, string pasword, string kategori, int id);

        [OperationContract]
        string DeleteRegister(string username);

        [OperationContract]
        List<DataRegister> DataRegist();
    }

    public class DataRegister
    {
        [DataMember(Order =1)]
        public int id { get; set; }
        [DataMember(Order = 2)]
        public string username { get; set; }
        [DataMember(Order = 3)]
        public string password { get; set; }
        [DataMember(Order = 4)]
        public string kategori { get; set; }
    }

    [DataContract]
    public class DetailLokasi
    {
        [DataMember]
        public string IDlokasi { get; set; }

        [DataMember]
        public string NamaLokasi { get; set; }

        [DataMember]
        public string DeskripsiFull { get; set; }

        [DataMember]
        public int Kuota { get; set; }
    }

    [DataContract]
    public class Pemesanan
    {
        [DataMember]
        public string IDPemesanan { get; set; }

        [DataMember]
        public string NamaCustomer { get; set; }

        [DataMember]
        public string NoTelpon { get; set; }

        [DataMember]
        public int JumlahPemesanan { get; set; }

        [DataMember]
        public string IDLokasi { get; set; }
    }

    [DataContract]
    public class CekLokasi
    {
        [DataMember]
        public string IDlokasi { get; set; }

        [DataMember]
        public string NamaLokasi { get; set; }

        [DataMember]
        public string DeskripsiSingkat { get; set; }

    }

}
