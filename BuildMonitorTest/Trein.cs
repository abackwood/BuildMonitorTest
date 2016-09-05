using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildMonitorTest {
    public class Trein {
        public int Serienummer { get; private set; }
        public int Ritnummer { get; private set; }
        public int PassagiersCapaciteit { get; private set; }
        public int AantalPassagiers { get; private set; }

        public Trein(int serienummer, int ritnummer, int passagiersCapaciteit) {
            this.Serienummer = serienummer;
            this.Ritnummer = ritnummer;
            this.PassagiersCapaciteit = passagiersCapaciteit;
            this.AantalPassagiers = 0;
        }

        public void VeranderAantalPassagiers(int delta) {
            if (AantalPassagiers + delta < 0) {
                throw new ArgumentException("Meer passagiers verwijderd dan aantal in de trein");
            }
            else if (AantalPassagiers + delta > PassagiersCapaciteit) {
                throw new ArgumentException("Meer passagiers toegevoegd dan capaciteit");
            }

            AantalPassagiers += delta;
        }

        public Trein genereerVolgendeTrein() {
            return new Trein(Serienummer,Ritnummer + 1, PassagiersCapaciteit);
        }
    }
}
