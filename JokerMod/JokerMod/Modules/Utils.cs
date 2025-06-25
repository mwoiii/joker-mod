using System;
using System.Collections.Generic;
using System.Linq;

namespace JokerMod.Modules {
    public static class Utils {
        public static Random rand = new Random();

        public static object RandomChoices(IEnumerable<object> choices, IEnumerable<float> weights) {
            List<float> cumWeights = new List<float>();
            float currentWeight = 0;

            foreach (float weight in weights) {
                currentWeight += weight;
                cumWeights.Add(currentWeight);
            }

            float choiceWeight = (float)rand.NextDouble() * currentWeight;

            int i = 0;
            foreach (var choice in choices) {
                if (choiceWeight <= cumWeights[i]) {
                    return choice;
                }
                i++;
            }

            Log.Warning("RandomChoices: Couldn't make a choice - returning null!");
            return null;
        }

        public static object RandomChoice(IEnumerable<object> choices) {
            IList<Object> list = choices as IList<object> ?? choices.ToList();
            if (list.Count > 0) {
                return list[rand.Next(list.Count)];
            }
            Log.Warning("RandomChoice: Got passed an empty enumerable - retuning null!");
            return null;
        }
    }
}
