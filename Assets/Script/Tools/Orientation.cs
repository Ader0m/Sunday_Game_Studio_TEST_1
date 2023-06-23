using UnityEngine;

namespace Assets.Script.Tools
{
    public static class Orientation
    {
        public static void OrientationFree(bool flag)
        {
            if (flag)
            {
                Screen.autorotateToLandscapeLeft = true;
                Screen.autorotateToLandscapeRight = true;
                Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToPortrait = true;                
            }
            else
            {
                Screen.autorotateToLandscapeLeft = false;
                Screen.autorotateToLandscapeRight = false;
                Screen.autorotateToPortraitUpsideDown = false;
                Screen.autorotateToPortrait = true;                
            }
        }
    }
}
