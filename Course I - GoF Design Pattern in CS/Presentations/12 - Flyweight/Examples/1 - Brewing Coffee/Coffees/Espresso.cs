﻿namespace Wincubate.FlyweightExamples
{
    class Espresso : Coffee
    {
        public Espresso( string customerName )
            : base(CoffeeKind.Espresso, 5, CoffeeSize.Small, customerName)
        {
        }
    }
}
