using System;
using System.Collections.Generic;
using System.Linq;

namespace Wincubate.BuilderLabs
{
    internal interface ICrustBuilder
    {
        ISauceBuilder WithCrust(CrustKind crust = CrustKind.Classic);
    }

    internal interface ISauceBuilder
    {
        ICheeseBuilder WithSauce();
        ICheeseBuilder WithoutSauce();
    }

    internal interface ICheeseBuilder
    {
        IToppingsBuilder AddCheese(CheeseKind cheese = CheeseKind.Regular);
    }

    internal interface IToppingsBuilder : IFinalBuilder
    {
        IToppingsBuilder AddTopping(ToppingKind topping);
        IFinalBuilder WithOregano();
    }

    internal interface IFinalBuilder
    {
        Pizza Build();
    }

    class FluentPizzaBuilder :
        ICrustBuilder,
        ISauceBuilder,
        ICheeseBuilder,
        IToppingsBuilder,
        IFinalBuilder
    {
        private Pizza _pizza;

        public ICrustBuilder Begin()
        {
            _pizza = new Pizza();
            return this;
        }

        ISauceBuilder ICrustBuilder.WithCrust(CrustKind crust)
        {
            _pizza.Crust = crust;
            return this;
        }

        ICheeseBuilder ISauceBuilder.WithSauce()
        {
            _pizza.HasSauce = true;
            return this;
        }

        ICheeseBuilder ISauceBuilder.WithoutSauce()
        {
            _pizza.HasSauce = false;
            return this;
        }

        IToppingsBuilder ICheeseBuilder.AddCheese(CheeseKind cheese)
        {
            _pizza.Cheese = cheese;
            return this;
        }

        IToppingsBuilder IToppingsBuilder.AddTopping(ToppingKind topping)
        {
            IEnumerable<ToppingKind> existingToppings = _pizza.Toppings;
            _pizza.Toppings = existingToppings.Union(new ToppingKind[] { topping });
            return this;
        }

        IFinalBuilder IToppingsBuilder.WithOregano()
        {
            _pizza.Oregano = true;
            return this;
        }

        Pizza IFinalBuilder.Build() => _pizza;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pizza hawaii = new FluentPizzaBuilder()
                .Begin()
                .WithCrust(CrustKind.Classic)
                .WithSauce()
                .AddCheese()
                .AddTopping(ToppingKind.Ham)
                .AddTopping(ToppingKind.Pineapple)
                .WithOregano()
                .Build();

            Console.WriteLine(hawaii);
        }
    }
}