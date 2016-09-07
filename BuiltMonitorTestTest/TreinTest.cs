using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildMonitorTest;

namespace BuildMonitorTestTest {
    [TestClass]
    public class TreinTest {
        public static Trein MaakStandaardTrein() {
            Materieel materieel = new Materieel(100,100);
            return new Trein(1,1,materieel);
        }

        [TestMethod]
        public void AantalPassagiersWordtCorrectVerhoogd() {
            Trein trein = MaakStandaardTrein();
            int oudAantal = trein.AantalPassagiers;
            int verandering = 5;
            int verwachtAantal = oudAantal + verandering;

            trein.VeranderAantalPassagiers(verandering);

            Assert.AreEqual(verwachtAantal, trein.AantalPassagiers);
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentException))]
        public void AantalPassagiersKanNietNegatiefZijn() {
            Trein trein = MaakStandaardTrein();
            trein.VeranderAantalPassagiers(5);

            trein.VeranderAantalPassagiers(-10);
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentException))]
        public void AantalPassagiersKanNietBovenCapaciteitZijn() {
            Trein trein = MaakStandaardTrein();

            trein.VeranderAantalPassagiers(105);
        }

        [TestMethod]
        public void VolgendeTreinResetAantalPassagiers() {
            Trein trein = MaakStandaardTrein();
            trein.VeranderAantalPassagiers(5);

            Trein volgendeTrein = trein.GenereerVolgendeTrein();

            Assert.AreEqual(0, volgendeTrein.AantalPassagiers);
        }

        [TestMethod]
        public void VolgendeTreinHeeftZelfdeCapaciteit() {
            Trein trein = MaakStandaardTrein();

            Trein volgendeTrein = trein.GenereerVolgendeTrein();

            Assert.AreEqual(100, volgendeTrein.Materieel.PassagiersCapaciteit);
        }

        [TestMethod]
        public void VolgendeTreinHeeftHogerRitnummer() {
            Trein trein = MaakStandaardTrein();

            Trein volgendeTrein = trein.GenereerVolgendeTrein();

            Assert.IsTrue(trein.Ritnummer < volgendeTrein.Ritnummer);
        }

        [TestMethod]
        public void TrajectAantalWordtJuistAAngemaaktInConstructor() {
            Station station1 = new Station(0,0);
            Station station2 = new Station(1,0);
            Station station3 = new Station(1,1);
            Materieel materieel = new Materieel(100,100);
            Trein trein = new Trein(1,1,materieel,station1,station2,station3);

            int aantalStations = trein.Traject.Count;

            Assert.AreEqual(3,aantalStations);
        }

        [TestMethod]
        public void TrajectAfstandIsNulBijLeegTraject() {
            Trein trein = MaakStandaardTrein();

            Assert.AreEqual(0,trein.TrajectAfstand);
        }

        [TestMethod]
        public void TrajectAfstandIsSomVanAfstanden() {
            Station station1 = new Station(0,0);
            Station station2 = new Station(1,0);
            Station station3 = new Station(1,1);
            Materieel materieel = new Materieel(100,100);
            Trein trein = new Trein(1,1,materieel,station1,station2,station3);

            Assert.AreEqual(2,trein.TrajectAfstand);
        }
    }
}
