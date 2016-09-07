using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildMonitorTest {
    public class Materieel {
        public int PassagiersCapaciteit { get; private set; }
        public double MaximumSnelheid { get; private set; }

        public Materieel(int capaciteit, double maximumSnelheid) {
            this.PassagiersCapaciteit = capaciteit;
            this.MaximumSnelheid = maximumSnelheid;
        }
    }
}
