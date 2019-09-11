﻿namespace Wincubate.FlyweightExamples
{
    /// <summary>
    /// See http://baresso.com/menukort/
    /// </summary>
    interface ICoffee
    {
        CoffeeKind Kind { get; }
        int Strength { get; }
        CoffeeSize Size { get; }
        string CustomerName { get; }

        void Serve();
    }
}
