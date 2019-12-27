using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain.Interface
{
    public interface IBlock
    {
        byte[] Data { get; }
        byte[] Hash { get; set; }
        byte[] PrevHash { get; set; }
        int Nonce { get; set; }

        DateTime TimeStamp { get; }
    }

}
