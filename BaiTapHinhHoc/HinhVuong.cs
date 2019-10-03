using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapHinhHoc
{
    class HinhVuong : HinhChuNhat
    {
        private float canh;

        public HinhVuong(float canh)
        {
            Canh = canh;
        }

        public HinhVuong(float cd, float cr) : base(cd, cr)
        {
            Cd = cd;
            Cr = cr;
        }

        public float Canh { get => canh; set => canh = value; }

        public override float CV()
        {
            return Canh * 4;
        }

        public override float DT()
        {
            return Canh * Canh;
        }
    }
}
