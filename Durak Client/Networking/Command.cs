﻿using System.Collections.Generic;
using Durak_Client.DataType;

namespace Durak_Client.Networking
{
    public class Command
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int DeckCardsLeft { get; set; } // Amounts of card that available on the desc
        public int EnemyPlayerCardsLeft { get; set; }
        public CardType BottomCard { get; set; } // Trump card
        public int PlayerId { get; set; } // Current player Id
        public List<CardType> Cards { get; set; } // Cards that applied to command
        public List<CardCouplet> CardCouplets { get; set; }
    }
}