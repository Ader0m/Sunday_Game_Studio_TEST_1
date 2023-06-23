using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Gallery
{
    public class PlaceHolderTask : MonoBehaviour, IPlaceHolderTask
    {
        [SerializeField] private Image _image;
        private int _imgNum;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void Task(int imgNum)
        {
            GalleryStorage.Instance.Sprites.CollectionChanged += OnLoad;
            _imgNum = imgNum;
        }

        public void OnLoad(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.Action == NotifyCollectionChangedAction.Add)
            {
                try
                {
                    Sprite sp = GalleryStorage.Instance.GetSprite(_imgNum - 1);
                    _image.sprite = sp;
                    GalleryStorage.Instance.Sprites.CollectionChanged -= OnLoad;
                }
                catch { ; }
            }
        }
    }
}
