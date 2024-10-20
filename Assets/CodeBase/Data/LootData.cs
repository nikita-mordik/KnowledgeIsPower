﻿using System;

namespace CodeBase.Data
{
    [Serializable]
    public class LootData
    {
        public int Collected;
        public Action Changed;

        public void Collect(Loot loot)
        {
            Collected += loot.MoneyValue;
            Changed?.Invoke();
        }
        
        public void Add(int lootValue)
        {
            Collected += lootValue;
            Changed?.Invoke();
        }
    }
}