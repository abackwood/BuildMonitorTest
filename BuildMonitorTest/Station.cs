using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildMonitorTest {
    public class Station {
        public double PositieX { get; private set; }
        public double PositieY { get; private set; }

        public Station(double x, double y) {
            this.PositieX = x;
            this.PositieY = y;
        }

        public double AfstandTot(Station station) {
            double afstandX = station.PositieX - PositieX;
            double afstandY = station.PositieY - PositieY;
            return Math.Sqrt(afstandX * afstandX + afstandY * afstandY);
        }
    }
}
