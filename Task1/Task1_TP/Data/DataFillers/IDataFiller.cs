using System;
using System.Collections.Generic;
using System.Text;

namespace Task1_TP.Data.DataFillers
{
    public interface IDataFiller
    {
        void Fill(IDataRepository dataRepository);
    }
}
