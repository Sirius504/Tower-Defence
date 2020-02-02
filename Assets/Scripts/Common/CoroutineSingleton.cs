using System.Collections;
using UnityEngine;


namespace TowerDefence.Common
{
    public static class CoroutineSingleton
    {
        private static MonoBehaviour monoBehaviour;

        public static void StartCoroutine(IEnumerator routine)
        {
            if (monoBehaviour == null)
            {
                var gameObject = new GameObject("Coroutines");
                monoBehaviour = gameObject.AddComponent<CoroutinesBehaviour>();
            }
            monoBehaviour.StartCoroutine(routine);
        }
    }

    public class CoroutinesBehaviour : MonoBehaviour
    {

    } 
}

