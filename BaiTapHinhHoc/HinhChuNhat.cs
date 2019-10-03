using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapHinhHoc
{
    class HinhChuNhat : HinhHoc
    {
        private float cd;
        private float cr;

        public HinhChuNhat()
        {
        }

        public HinhChuNhat(float cd , float cr)
        {
            Cd = cd;
            Cr = Cr;
        }

        public float Cd { get => cd; set => cd = value; }
        public float Cr { get => cr; set => cr = value; }

        public override float CV()
        {
            return (Cd + Cr) * 2;
        }

        public override float DT()
        {
            return Cd * Cr;
        }
    }
}
