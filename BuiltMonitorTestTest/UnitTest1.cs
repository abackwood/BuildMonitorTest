using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildMonitorTest;

namespace BuildMonitorTestTest {
    [TestClass]
    public class TreinTest {

        [TestMethod]
        public void AantalPassagiersWordtCorrectVerhoogd() {
            Trein trein = new Trein(1,1,100);
            int oudAantal = trein.AantalPassagiers;
            int verandering = 5;
            int verwachtAantal = oudAantal + verandering;

            trein.VeranderAantalPassagiers(verandering);

            Assert.AreEqual(verwachtAantal, trein.AantalPassagiers);
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentException))]
        public void AantalPassagiersKanNietNegatiefZijn() {
            Trein trein = new Trein(1,1,100);
            trein.VeranderAantalPassagiers(5);

            trein.VeranderAantalPassagiers(-10);
        }

        [TestMethod]
        [ExpectedException (typeof (ArgumentException))]
        public void AantalPassagiersKanNietBovenCapaciteitZijn() {
            Trein trein = new Trein(1,1,100);

            trein.VeranderAantalPassagiers(105);
        }

        [TestMethod]
        public void GenererenVolgendeTreinResetAantalPassagiers() {
            Trein trein = new Trein(1,1,100);
            trein.VeranderAantalPassagiers(5);

            Trein volgendeTrein = trein.genereerVolgendeTrein();

            Assert.AreEqual(0, volgendeTrein.AantalPassagiers);
        }

        [TestMethod]
        public void VolgendeTreinHeeftZelfdeCapaciteit() {
            Trein trein = new Trein(1,1,100);
            trein.VeranderAantalPassagiers(5);

            Trein volgendeTrein = trein.genereerVolgendeTrein();

            Assert.AreEqual(100, volgendeTrein.PassagiersCapaciteit);
        }
    }
}
