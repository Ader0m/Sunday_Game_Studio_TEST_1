using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Gallery
{
    /// <summary>
    /// Устанавливает размер ячейки в зависимости от размера _ScrolView(телефона)
    /// </summary>
    public class LoyoutGroupScaler : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;
        [SerializeField] private RectTransform _ScrolView;
        private float width;
        private float height;
        /// <summary>
        /// Значения подобраны руками
        /// </summary>
        private int offsetY = 25;

        private void Awake()
        {
            width = _ScrolView.rect.width;
            height = _ScrolView.rect.height;

            _gridLayoutGroup.cellSize = new Vector2((int)width, (int)height / 2 - offsetY / 2);
        }
    }
}