﻿using System;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData;
        public State HeroState;
        public Stats HeroStats;
        public KillData KillData;
        public LeftLoot LeftLoot;
        public PurchaseData PurchaseData;

        public PlayerProgress(string initialLevel)
        {
            WorldData = new WorldData(initialLevel);
            HeroState = new State();
            HeroStats = new Stats();
            KillData = new KillData();
            LeftLoot = new LeftLoot();
            PurchaseData = new PurchaseData();
        }
    }
}