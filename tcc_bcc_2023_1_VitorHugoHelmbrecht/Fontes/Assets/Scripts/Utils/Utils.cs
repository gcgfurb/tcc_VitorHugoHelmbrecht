using System;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public static class Utils
    {
        public static EItems CurrentItem;
        public static Vector3 FinalAngle;
        public static string NextScene;
        public static Color Color;

        public static bool IsInRange(this Vector3 vector3, Vector3 compareTo, float range) {
            bool inXRange = compareTo.x.IsInRange(vector3.x, range);
            bool inYRange = compareTo.y.IsInRange(vector3.y, range);
            bool inZRange = compareTo.z.IsInRange(vector3.z, range);

            return inXRange && inYRange && inZRange;
        }

        private static bool IsInRange(this float number, float compareTo, float range) {
            var biggestNumber = Math.Round(number + range);
            var lowestNumber = Math.Round(number - range);
            var roundedCompareTo = Math.Round(compareTo);

            return biggestNumber >= roundedCompareTo && lowestNumber <= roundedCompareTo;
        }
    }
}
