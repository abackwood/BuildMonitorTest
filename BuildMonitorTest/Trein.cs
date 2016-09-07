using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildMonitorTest {
    public class Trein {
        private LinkedList<Station> traject;
        private double trajectAfstand;

        public int Serienummer { get; private set; }
        public int Ritnummer { get; private set; }
        public int PassagiersCapaciteit { get; private set; }
        public int AantalPassagiers { get; private set; }
        public LinkedList<Station> Traject {
            get { return new LinkedList<Station>(traject); }
        }
        public double TrajectAfstand { get; private set; }

        public Trein(int serienummer, int ritnummer, int passagiersCapaciteit, params Station[] trajectArray) {
            this.Serienummer = serienummer;
            this.Ritnummer = ritnummer;
            this.PassagiersCapaciteit = passagiersCapaciteit;
            this.AantalPassagiers = 0;

            traject = new LinkedList<Station>();
            for (int i = 0; i < trajectArray.Length; i++) {
                traject.AddLast(trajectArray[i]);
            }
            HerberekenTrajectAfstand();
        }

        public void HerberekenTrajectAfstand() {
            if (traject.Count == 0) {
                trajectAfstand = 0;
                return;
            }

            LinkedList<Station>.Enumerator en = traject.GetEnumerator();
            trajectAfstand = 0;

            // Zet het huidige station op het eerste station en begin vanaf het tweede
            en.MoveNext();
            Station huidigStation = en.Current;

            Station vorigStation;
            while(en.MoveNext()) {
                vorigStation = huidigStation;
                huidigStation = en.Current;
                Console.WriteLine("(" + vorigStation.PositieX + "," + vorigStation.PositieY + ") => (" + huidigStation.PositieX + "," + huidigStation.PositieY);

                trajectAfstand += vorigStation.AfstandTot(huidigStation);
            }
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

        public Trein GenereerVolgendeTrein() {
            return new Trein(Serienummer, Ritnummer + 1, PassagiersCapaciteit);
        }
    }
}
