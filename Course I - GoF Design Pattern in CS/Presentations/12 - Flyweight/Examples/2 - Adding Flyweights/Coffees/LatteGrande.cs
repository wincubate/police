﻿namespace Wincubate.FlyweightExamples
{
    class LatteGrande : Coffee
    {
        public LatteGrande()
            : base(CoffeeKind.Latte, 1, CoffeeSize.Regular)
        {
        }
    }
}
