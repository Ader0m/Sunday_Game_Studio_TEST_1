using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Gallery
{
    public class LoyoutGroupScaler : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;
        [SerializeField] private RectTransform _ScrolView;
        private float width;
        private float height;
        private int offsetX = 25;
        private int offsetY = 25;

        private void Awake()
        {
            width = _ScrolView.rect.width;
            height = _ScrolView.rect.height;

            _gridLayoutGroup.cellSize = new Vector2((int)width, (int)height / 2 - offsetY / 2);
        }
    }
}