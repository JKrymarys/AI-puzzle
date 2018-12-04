using System;

namespace AI_puzzle
{

// na poczatku chcialem zrobic osobne pole, ale chyba jednak nie bedzie to mialo najmnniejszego sensu
// niemniej zostawiam te kawalki kodu na wszelki wypadek XD

    class Field
    {
        public int Position {get;}
        public Field(int value)
        {
            this.Position = value;
        }
    }
}
