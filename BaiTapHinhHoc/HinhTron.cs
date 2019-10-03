using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapHinhHoc
{
    class HinhTron : HinhHoc
    {
        public const float PI = 3.14f;
        private float bk;

        public HinhTron(float bk)
        {
            Bk = bk;
        }

        public HinhTron()
        {
        }

        public float Bk { get => bk; set => bk = value; }

        public override float CV()
        {
            return 2 * PI * Bk;
        }

        public override float DT()
        {
            return PI * Bk * Bk;
        }
    }
}
