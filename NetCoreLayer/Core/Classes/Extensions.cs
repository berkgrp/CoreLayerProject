using Core.Interfaces;
using System;

namespace Core.Classes
{
    internal class Extensions : IExtensions
    {
        private readonly Random random = new Random();
        public string RandomNumberGeneratorAsString()
        {
            return Convert.ToString(random.Next(10000000, 99999999));
        }
    }
}
