using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildMonitorTest;

namespace BuildMonitorTestTest {
    [TestClass]
    public class MaterieelTest {
        [TestMethod]
        public void KopieHeeftZelfdeKenmerkenAlsPrototype() {
            MaterieelManager manager = new MaterieelManager();
            Materieel prototype = new Materieel(100,100);

            manager.RegistreerPrototype("testType",prototype);
            Materieel materieel = manager.MaakMaterieelVanType("testType");

            Assert.AreEqual(prototype.PassagiersCapaciteit,materieel.PassagiersCapaciteit);
            Assert.AreEqual(prototype.MaximumSnelheid,prototype.MaximumSnelheid);
        }
    }
}
