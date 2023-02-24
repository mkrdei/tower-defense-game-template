using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Util
{
    public static class Extensions
    {
        private static Dictionary<string, LayerMask> nameToLayer = new Dictionary<string, LayerMask>();

        public static bool TryCallFunctionWithComponent<T>(this Collider collider, Action<T> action)
        {
            if (collider.TryGetComponent<T>(out T component))
            {
                action(component);
                return true;
            }
            return false;
        }

        public static Color With(this Color c, float? r = null, float? g = null, float? b = null, float? a = null) => new Color(r ?? c.r, g ?? c.g, b ?? c.b, a ?? c.a);

        public static Vector3 With(this Vector3 v, float? x = null, float? y = null, float? z = null) => new Vector3(x ?? v.x, y ?? v.y, z ?? v.z);

        public static bool Contains(this LayerMask layerMask, LayerMask other) => (layerMask & other) != 0;

        public static bool Contains(this LayerMask layerMask, int layer) => (layerMask & (1 << layer)) != 0;

        public static bool OnLayer(this GameObject gameObject, LayerMask layerMask) => layerMask.Contains(gameObject.layer);

        public static bool OnLayer(this GameObject gameObject, int layer) => gameObject.layer == layer;

        public static bool OnLayer(this GameObject gameObject, string layerName)
        {
            LayerMask layerMask;
            if (!nameToLayer.TryGetValue(layerName, out layerMask))
            {
                layerMask = LayerMask.GetMask(layerName);
                nameToLayer[layerName] = layerMask;
            }
            return gameObject.OnLayer(layerMask);
        }

        public static T Sample<T>(this T[] arr)
        {
            if (arr.Length == 0)
            {
                Debug.LogError("Can't sample from an empty collection");
                return default(T);
            }
            int index = UnityEngine.Random.Range(0, arr.Length);
            return arr[index];
        }

        public static T Sample<T>(this List<T> list)
        {
            if (list.Count == 0)
            {
                Debug.LogError("Can't sample from an empty collection");
                return default(T);
            }
            int index = UnityEngine.Random.Range(0, list.Count);
            return list[index];
        }

        public static T Pop<T>(this List<T> list)
        {
            T first = list[0];
            list.RemoveAt(0);
            return first;
        }

        public static void RotateTowards(this Transform transform, Transform to, float rotationSpeed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(to.position - transform.position, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
        }

        public static void RotateTowards<T>(this T from, Transform to, float rotationSpeed) where T : MonoBehaviour => from.transform.RotateTowards(to, rotationSpeed);

        public static void RotateTowards<T>(this Transform transform, T to, float rotationSpeed) where T : MonoBehaviour => transform.RotateTowards(to.transform, rotationSpeed);

        public static void RotateTowards(this GameObject gameObject, Transform to, float rotationSpeed) => gameObject.transform.RotateTowards(to, rotationSpeed);

        public static void RotateTowards(this Transform transform, GameObject to, float rotationSpeed) => transform.RotateTowards(to.transform, rotationSpeed);

        public static void RotateTowards<T>(this T from, T to, float rotationSpeed) where T : MonoBehaviour => from.transform.RotateTowards(to.transform, rotationSpeed);

        public static float ProjectionDistance(this Vector3 vectorToProject, Vector3 on)
        {
            return Vector3.Dot(vectorToProject, on.normalized);
        }

        public static T GetMax<T>(this T flaggedEnumValue) where T : Enum
        {
            return (T)Enum.GetValues(flaggedEnumValue.GetType())
                .Cast<Enum>()
                .Where(flaggedEnumValue.HasFlag)
                .Max();
        }

        public static IEnumerable<T> Cycle<T>(this IEnumerable<T> list)
        {
            bool empty = true;
            while (true)
            {
                foreach (T e in list)
                {
                    empty = false;
                    yield return e;
                }
                if (empty)
                    break;
            }
        }
    }
}