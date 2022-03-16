using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private string[] characters;

        public string[] Characters => characters;

        public GameObject GetEffect(string character)
        {
            var objName = characters.FirstOrDefault(e => e == character);
            return string.IsNullOrEmpty(objName) ? null : LoadObject(objName);
        }

        private static GameObject LoadObject(string effectName)
        {
            return Resources.Load<GameObject>($"Prefabs/{effectName}");
        }

#if UNITY_EDITOR
        private void Reset()
        {
            var objects = Resources.LoadAll<GameObject>("Prefabs");
            characters = new string[objects.Length];

            for (int i = 0; i < characters.Length; i++)
            {
                characters[i] = objects[i].name;
            }
        }
#endif
    }
}