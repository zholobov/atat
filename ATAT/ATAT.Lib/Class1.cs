using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ATAT.Lib
{
    public class Data
    {
        // 16384 x 16384 is able to fit 2GB file with lines length 10 symbols or more.
        // We are okay with such limitations.
        private const int MaxLinesPerBlock = 16384;
        private const int MaxBlocks = 16384;

        private Block[] _blocks;

        public class Block
        {
            private readonly string[] _lines = new string[MaxLinesPerBlock];
            private int _count;

            public void AppendLine(string s)
            {
                _lines[_count] = s;
                ++_count;
            }
        }
    }


    public interface IDataImporter
    {
        void Clear();
        void AppendLine(string s);
    }

    public interface IFilterSettings
    {
        List<IFilter> Filters { get; }
    }

    public interface ISearcher
    {
        int GetCount();
        IEnumerable<ILine> GetLinesRange(int from, int to);
    }

    /// <summary>
    /// Represents a single "filter" definition. Filters are organaized into
    /// more complex structures to supports complex filtering behaviors.
    /// A single filter by itself does not fully define filtering semantics -
    /// the whole list or tree or some other structure of filters does.
    /// </summary>
    public interface IFilter
    {
        string SearchString { get; set; }
    }

    /// <summary>
    /// Designed for rendering. It is not "live". When you get it you get snapshot of
    /// calculated data for rendering at the moment.
    /// </summary>
    public interface ILine
    {

    }
}
