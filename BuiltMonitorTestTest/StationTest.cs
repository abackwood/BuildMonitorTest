using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuildMonitorTest;

namespace BuildMonitorTestTest {
    [TestClass]
    public class StationTest {
        [TestMethod]
        public void AfstandIsEuclidischeAfstand() {
            Station station1 = new Station(1,1);
            Station station2 = new Station(2,2);

            double afstand = station1.AfstandTot(station2);

            Assert.AreEqual(Math.Sqrt(2),afstand,0.001);
        }

        [TestMethod]
        public void AfstandIsAltijdPositief() {
            Station s = new Station(0,0);
            Station s1 = new Station(1,0);
            Station s2 = new Station(-1,0);
            Station s3 = new Station(0,1);
            Station s4 = new Station(0,-1);

            double afstand1 = s.AfstandTot(s1);
            double afstand2 = s.AfstandTot(s2);
            double afstand3 = s.AfstandTot(s3);
            double afstand4 = s.AfstandTot(s4);

            Assert.IsTrue(afstand1 > 0 && afstand2 > 0 && afstand3 > 0 && afstand4 > 0);
        }
    }
}
