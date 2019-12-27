using Blockchain.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blockchain.Model
{
    public class BlockChain : IEnumerable<IBlock>
    {
        private List<IBlock> _items = new List<IBlock>();

        public BlockChain(byte[] difficulty, IBlock genesis)
        {
            Difficulty = difficulty;
            genesis.Hash = genesis.MineHash(difficulty);
            Items.Add(genesis);
        }

        public void Add(IBlock item)
        {
            if(Items.LastOrDefault() != null)
            {
                item.PrevHash = Items.LastOrDefault()?.Hash;
            }

            item.Hash = item.MineHash(Difficulty);
            Items.Add(item);
        }

        public List<IBlock> Items
        {
            get => _items;
            set =>  _items = value;
        }

        public int Count => Items.Count;

        public IBlock this[int index]
        {
            get => Items[index];
            set => Items[index] = value;
        }

        public byte[] Difficulty { get; }
        public IEnumerator<IBlock> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
