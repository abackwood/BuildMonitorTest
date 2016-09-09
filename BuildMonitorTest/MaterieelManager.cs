using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildMonitorTest {
    public class MaterieelManager {
        private Dictionary<string,Materieel> prototypes;

        public MaterieelManager() {
            prototypes = new Dictionary<string,Materieel>();
        }

        public Materieel MaakMaterieelVanType(string type) {
            return new Materieel(prototypes[type]);
        }

        public void RegistreerPrototype(string type, Materieel prototype) {
            prototypes[type] = prototype;
        }
    }
}
