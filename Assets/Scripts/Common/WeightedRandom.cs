using System;
using System.Collections.Generic;
using System.Linq;

namespace TowerDefence.Common
{
    public class WeightedRandom<T>
    {
        private Random random;
        private readonly Dictionary<T, int> weights;
        public IReadOnlyDictionary<T, int> Weights => weights;

        public WeightedRandom(Dictionary<T, int> weights)
        {
            this.weights = weights ?? throw new ArgumentNullException(nameof(weights));
            if (weights.Count == 0)
                throw new ArgumentException(nameof(weights), "Empty weights dictionary");
            foreach (var weight in weights)
                if (weight.Value < 0)
                    throw new ArgumentOutOfRangeException(nameof(weights), "Negative weight found.");
            random = new Random();
        }

        public T DrawRandom()
        {
            return GetRandomValue(weights);
        }

        public List<T> DrawNRandom(int amount, bool allowCopies = false)
        {
            var result = new List<T>();
            var pool = new Dictionary<T, int>(weights);
            for (int i = 0; i < amount; i++)
            {
                var item = GetRandomValue(pool);
                result.Add(item);
                if (!allowCopies)
                    pool.Remove(item);
            }
            return result;
        }


        private T GetRandomValue(Dictionary<T, int> weights)
        {
            int currentWeight = weights.Values.Sum();
            int randomValue = random.Next(0, currentWeight);
            T result = default;
            foreach (var probability in weights.OrderBy(w => random.Next()))
            {
                result = probability.Key;
                currentWeight -= probability.Value;
                if (currentWeight <= 0)
                    break;
            }
            return result;
        }
    }
}
