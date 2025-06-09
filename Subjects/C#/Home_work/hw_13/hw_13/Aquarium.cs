using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_13
{
   

    public class Aquarium
    {
        private List<SeaCreature> inhabitants = new List<SeaCreature>();

        public void AddInhabitant(SeaCreature creature)
        {
            inhabitants.Add(creature);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (SeaCreature creature in inhabitants)
            {
                yield return creature;
            }
        }
    }

}
