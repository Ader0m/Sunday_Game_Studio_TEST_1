using Assets.Script.Tools;
using UnityEngine;

namespace Assets.Script.Menu
{
    public class SceneController : MonoBehaviour
    {
        private void Awake()
        {
            Orientation.OrientationFree(false);
        }
    }
}
