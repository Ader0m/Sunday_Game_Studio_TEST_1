using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Gallery
{
    public class ScrollListener : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;
        [SerializeField] private SceneController _sceneController;

        public void OnScroll(float value)
        {
            if (value <= 0)
            {
                _sceneController.ViewController.ShowPicture(_gridLayoutGroup.transform.childCount + 1);
            }
        }
    }
}
