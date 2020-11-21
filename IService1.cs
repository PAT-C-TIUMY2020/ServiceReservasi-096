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
        string editpemesanan(string IDPemesanan, string NamaCustomer);

        [OperationContract]
        string deletepemesanan(string IDPemesanan);

        [OperationContract]
        List<CekLokasi> ReviewLokasi();

        [OperationContract]
        List<DetailLokasi> DetailLokasi();

        [OperationContract]
        List<Pemesanan> Pemesanan();
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
