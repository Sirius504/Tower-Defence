using UnityEngine;

namespace TowerDefence.Common
{
    public class ApplicationQuit : MonoBehaviour
    {
        public void CloseApp()
        {
            Application.Quit(0);
        }
    } 
}
