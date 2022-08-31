using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSaveGet
{
    internal class Ogrenci
    {
        int _id;
        int _numara;
        string _ad;
        string _soyad;
        string _telefon;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Ad
        {
            get
            {
                return _ad;
            }

            set
            {
                _ad = value;
            }
        }

        public string Soyad
        {
            get
            {
                return _soyad;
            }

            set
            {
                _soyad = value;
            }
        }

        public string Telefon
        {
            get
            {
                return _telefon;
            }

            set
            {
                _telefon = value;
            }
        }

        public int Numara
        {
            get
            {
                return _numara;
            }

            set
            {
                _numara = value;
            }
        }
    }
}
