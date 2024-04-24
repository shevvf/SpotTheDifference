using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Framework.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> ForEach<TSource>(this IEnumerable<TSource> collection, Action<TSource> action)
        {
            for (int i = collection.Count() - 1; i >= 0; i--)
            {
                action(collection.ElementAtOrDefault(i));
            }

            return collection;
        }

        public static IEnumerable<TSource> ForEach<TSource>(this IEnumerable<TSource> collection, Action<TSource, int> action)
        {
            for (int i = 0; i < collection.Count(); i++)
            {
                action(collection.ElementAtOrDefault(i), i);
            }

            return collection;
        }

        public static TSource Choose<TSource>(this IEnumerable<TSource> collection)
        {
            return collection.ElementAtOrDefault(Random.Range(0, collection.Count()));
        }

        public static TSource Choose<TSource>(this IEnumerable<TSource> collection, params float[] weights)
        {
            collection = collection.Take(weights.Length);
            var total = weights.Take(collection.Count()).Sum();
            var rand = Random.Range(0.0f, total);

            for (int i = 0; i < collection.Count(); i++)
            {
                if (rand < weights[i]) return collection.ElementAtOrDefault(i);
                else rand -= weights[i];
            }

            return collection.LastOrDefault();
        }

        public static TSource Choose<TSource>(this IEnumerable<TSource> collection, AnimationCurve curve)
        {
            var weights = new float[collection.Count()];
            for (int i = 0; i < collection.Count(); i++)
            {
                weights[i] = curve.Evaluate(i / (float)collection.Count());
            }

            return collection.Choose(weights);
        }

        public static IEnumerable<TSource> ChooseSet<TSource>(this IEnumerable<TSource> collection, int count)
        {
            for (int numLeft = collection.Count(); numLeft > 0; numLeft--)
            {
                float prob = count / (float)numLeft;

                if (Random.value <= prob)
                {
                    count--;
                    yield return collection.ElementAtOrDefault(numLeft - 1);

                    if (count == 0) break;
                }
            }
        }

        public static IEnumerable<TSource> Shuffle<TSource>(this IEnumerable<TSource> collection)
        {
            var list = collection.ToList();
            for (int i = 0; i < list.Count(); i++)
            {
                int j = Random.Range(0, list.Count());
                yield return list[j];
                list[j] = list[i];
            }
        }

        public static TSource Closest<TSource>(this IEnumerable<TSource> collection, Vector3 position) where TSource : MonoBehaviour
        {
            var closest = collection.FirstOrDefault();
            float closestDistance = float.MaxValue;
            foreach (var item in collection)
            {
                float distance = Vector3.Distance(position, item.transform.position);
                if (distance < closestDistance)
                {
                    closest = item;
                    closestDistance = distance;
                }
            }

            return closest;
        }

        public static IEnumerable<TSource> Add<TSource>(this IEnumerable<TSource> collection, TSource element)
        {
            return collection.Concat(new[] { element });
        }

        public static void PrintCollection<TSource>(this IEnumerable<TSource> collection)
        {
            Debug.Log(string.Join(", ", collection.Select(x => x.ToString())));
        }

        public static TSource MaxBy<TSource, TResult>(this IEnumerable<TSource> collection, Func<TSource, TResult> selector) where TResult : IComparable<TResult>
        {
            if (!collection.Any()) return default;
            return collection.Aggregate((x, y) => selector(x).CompareTo(selector(y)) > 0 ? x : y);
        }

        public static TSource MinBy<TSource, TResult>(this IEnumerable<TSource> collection, Func<TSource, TResult> selector) where TResult : IComparable<TResult>
        {
            if (!collection.Any()) return default;
            return collection.Aggregate((x, y) => selector(x).CompareTo(selector(y)) < 0 ? x : y);
        }
    }
}
