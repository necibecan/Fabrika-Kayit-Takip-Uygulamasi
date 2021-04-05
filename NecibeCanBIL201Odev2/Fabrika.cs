using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NecibeCanBIL201Odev2
{
    class Fabrika
    {
        public string FabrikaAdi { get; set; }
        public string Adres { get; set; }
        public List<Calisan> Calisanlar { get; set; }

        public void IseAl(Calisan calisan)
        {
            Calisanlar.Add(calisan);
        }
        public void IstenCikar(int index)
        {
            Calisanlar.RemoveAt(index);
        }
    }
}
