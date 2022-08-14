using UnityEngine;

namespace Lesson
{
    internal class Unit : MonoBehaviour
    {
        public string Type { get; set; }
        public Health Health { get; protected set; }
        public static Unit CreateUnit(string type, Health hp)
        {
            var unit = Instantiate(Resources.Load<Unit>("Unit"));
            unit.Type = type;
            unit.Health = hp;
            return unit;
        }
    }
}