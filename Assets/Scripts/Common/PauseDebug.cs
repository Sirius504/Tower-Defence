using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Common
{
    public class PauseDebug : MonoBehaviour
    {
        public void Pause()
        {
            Debug.Break();
        }
    } 
}
