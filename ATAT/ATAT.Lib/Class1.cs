using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATAT.Lib
{
    public class Data
    {
        // 16384 x 16384 is able to fit 2GB file with lines length 10 symbols or more.
        // We are okay with such limitations.
        private const int MaxLinesPerBlock = 16384;
        private const int MaxBlocks = 16384;

        private Block[] _blocks;
    }

    public class Block
    {
        private string[] _lines;
    }
}
