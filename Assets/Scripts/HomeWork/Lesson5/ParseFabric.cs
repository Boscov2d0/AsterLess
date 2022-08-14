using UnityEngine;

internal abstract class ParseFabric : MonoBehaviour
{
    public static Asteroid CreateAsteroidEnemy(UnitsArray unitsArray)
    {
        for (int i = 0; i < unitsArray.objects.Length; i++) {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
            enemy.name = unitsArray.objects[i].unit.type;
            enemy.Health = int.Parse(unitsArray.objects[i].unit.health);
            return enemy; 
        }
        return null;
    }
}