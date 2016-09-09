using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BuildMonitorTest;

namespace BuildMonitorTestTest {
    [TestFixture]
    public class MaterieelTest {
        [Test]
        public void InstantieHeeftZelfdeEigenschappenAlsPrototype() {
            Materieel proto = new Materieel(100,100);

            Materieel instantie = new Materieel(proto);

            Assert.AreEqual(proto.PassagiersCapaciteit,instantie.PassagiersCapaciteit);
            Assert.AreEqual(proto.MaximumSnelheid,instantie.MaximumSnelheid);
        }
    }
}
