using System.Collections.Generic;
using System.Linq;

namespace geneticAlgorithm
{
    public class Map
    {
        public byte Byte;
        public char Char;

        public Map(byte b, char c)
        {
            Byte = b;
            Char = c;
        }
        public static Map Copy(Map m) => new Map(m.Byte,m.Char);
    }
    public class Gene
    {
        public Map GeneMap;
        private const int GeneCount = 27;

        public Gene Copy() => new Gene() {GeneMap = Map.Copy(GeneMap)};

        private static readonly List<Map> EncodingMap = new List<Map>()
        {
            new Map(0x00, '0'),
            new Map(0x01, '1'),
            new Map(0x02, '2'),
            new Map(0x03, '3'),
            new Map(0x04, '4'),
            new Map(0x05, '5'),
            new Map(0x06, '6'),
            new Map(0x07, '7'),
            new Map(0x08, '8'),
            new Map(0x09, '9'),
            new Map(0x0a, 'a'),
            new Map(0x0b, 'b'),
            new Map(0x0c, 'c'),
            new Map(0x0d, 'd'),
            new Map(0x0e, 'e'),
            new Map(0x0f, 'f'),
            new Map(0x10, 'g'),
            new Map(0x11, 'h'),
            new Map(0x12, 'i'),
            new Map(0x13, 'j'),
            new Map(0x14, 'k'),
            new Map(0x15, 'l'),
            new Map(0x16, 'm'),
            new Map(0x17, 'n'),
            new Map(0x18, 'o'),
            new Map(0x19, 'p'),
            new Map(0x1a, 'q'),
            new Map(0x1b, 'r'),
            new Map(0x1c, 's'),
            new Map(0x1d, 't'),
            new Map(0x1e, 'u'),
            new Map(0x1f, 'v'),
            new Map(0x20, 'w'),
            new Map(0x21, 'x'),
            new Map(0x22, 'y'),
            new Map(0x23, 'z'),
            new Map(0x24, ' '),
        };

        private static int MapLength => EncodingMap.Count;

        private void Assign(int index) { GeneMap = EncodingMap[index]; }
        //private static byte Encode(int index) => EncodingMap[index].Byte;
        private static char Decode(byte b) => EncodingMap.First(m => m.Byte == b).Char;

        public Gene() => Mutate();
        
        //format a cleanly written gene:
        public override string ToString() => Decode(GeneMap.Byte).ToString();
        
        //independant of target solution
        public static List<Gene> ChromosomeFactory()
        {
            var chromosome = new List<Gene>();
            for (var i = 0; i < GeneCount; i++)
                chromosome.Add(new Gene());
           // Console.WriteLine(Write(chromosome));
            return chromosome;
        }

        public void Mutate() => Assign(Rand.Random(0, MapLength));
        
        /*
        private static string Write(List<Gene> genome)
        {
            var sb=new StringBuilder();
            foreach (var g in genome)
            {
                sb.Append(g.ToString());
            }
            return sb.ToString();
        }
        */

    }
}
