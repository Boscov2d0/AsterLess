using System.IO;
using UnityEngine;

namespace Lesson
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private UnitsArray _unitsArray = new UnitsArray();

        void Start()
        {
            _unitsArray = Parse();
            ParseFabric.CreateAsteroidEnemy(_unitsArray);
        }
        UnitsArray Parse() 
        {
            string path = Path.Combine(Application.dataPath, "Data.json");

            if (!File.Exists(path))
            {
                string FileJSON = JsonUtility.ToJson("");
                File.WriteAllText(path, FileJSON);
            }

            string tempJSON = File.ReadAllText(path);
            var result = JsonUtility.FromJson<UnitsArray>(tempJSON);

            return result;
        }
    }
}