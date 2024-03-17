using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poligon
{
    internal class poligon
    {
        public int broj_temena;
        public tacka[] teme;
        public poligon()
        {
            teme = new tacka[broj_temena];
        }
        public poligon(int n)
        {
            broj_temena = n;
            teme = new tacka[broj_temena];
        }
        public Boolean konveksan()
        {
            int plusevi = 0;
            for (int i = 0; i < teme.Length; i++)
            {
                vektor prvi = new vektor(teme[i], teme[(i + 1) % broj_temena]);
                vektor drugi = new vektor(teme[(i + 1) % broj_temena], teme[(i + 2) % broj_temena]);
                if (vektor.VP(prvi, drugi) > 0) plusevi++;
            }
            if ((plusevi == 0) || plusevi == broj_temena) return true;
            else return false;
        }
        public double obim()
        {
            double obim = 0;
            for (int i = 0; i < broj_temena; i++)
            {
                vektor novi = new vektor(teme[i], teme[(i + 1) % broj_temena]);
                obim += novi.duzina();
            }
            return obim;
        }
        public double Povrsina()
        {
            double povrsina = 0;
            for (int i = 0; i < teme.Length; i++)
            {
                tacka A = teme[i];
                tacka B = teme[(i + 1) % broj_temena];
                povrsina = povrsina + (A.x * B.y - B.x * A.y);
            }
            return Math.Abs(povrsina) / 2;

        }
    }

    internal class ravan:poligon
    {
        static public int SIS(vektor AB, tacka C, tacka D)
        {
            vektor AC = new vektor(AB.pocetak, C);
            vektor AD = new vektor(AB.pocetak, D);
            double k1 = vektor.VP(AB, AC);
            double k2 = vektor.VP(AB, AD);
            if (k1 * k2 > 0) return 0;
            else if (k1 * k2 == 0) return 1;
            else return 2;
        }
        static public Boolean presek(vektor AB, vektor CD)
        {
            if (SIS(AB, CD.pocetak, CD.kraj) * SIS(CD, AB.pocetak, AB.kraj) > 0) return true;
            else return false;
        }
    }
}

