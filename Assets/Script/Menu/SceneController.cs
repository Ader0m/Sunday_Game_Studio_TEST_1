using Assets.Script.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Menu
{
    public class SceneController: MonoBehaviour
    {
        private void Awake()
        {
            Orientation.OrientationFree(false);
        }
    }
}
