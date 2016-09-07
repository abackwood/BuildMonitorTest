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
            VulPrototypesIn();
        }

        public Materieel MaakMaterieelVanType(string type) {
            return new Materieel(prototypes[type]);
        }

        private void VulPrototypesIn() {
            prototypes["sprinter"] = new Materieel(100,60);
            prototypes["intercity"] = new Materieel(200,120);
            prototypes["hispeed"] = new Materieel(140,260);
        }
    }
}
