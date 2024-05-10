using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lepegetes
{
    internal class Babu
    {
        int babuSzama;
        System.Windows.Point pozicio;
        Button babu;
        public Babu(int babuSzama, System.Windows.Point pozicio, Button babu)
        {
            this.BabuSzama = babuSzama;
            this.Pozicio = pozicio;
            this.UjBabu = babu;
        }

        public int BabuSzama { get => babuSzama; set => babuSzama = value; }
        public System.Windows.Point Pozicio { get => pozicio; set => pozicio = value; }
        public Button UjBabu { get => babu; set => babu = value; }
    }
}
