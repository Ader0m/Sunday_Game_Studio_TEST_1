using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;

namespace Assets.Script.Gallery
{
    public class AutoContentScaler: MonoBehaviour
    {
        [SerializeField] private RectTransform _content;
        [SerializeField] private GridLayoutGroup _layoutGroup;
        /// <summary>
        /// ТЗ
        /// </summary>
        private const int sizeX = 1;

        public void SetViewPortCount()
        {
            _content.sizeDelta = new Vector2(sizeX, _layoutGroup.transform.childCount * (_layoutGroup.cellSize.y + _layoutGroup.spacing.y));
        }

        public void Update()
        {
            SetViewPortCount();
        }
    }
}
