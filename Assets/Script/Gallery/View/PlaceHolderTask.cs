using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Script.Gallery
{
    public class PlaceHolderTask : MonoBehaviour, IPlaceHolderTask
    {
        [SerializeField] private Image _image;
        [SerializeField] private int _imgNum;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }
        
        /// <summary>
        /// Номер начиная 0
        /// </summary>
        public void SetImgNum(int imgNum)
        {
            _imgNum = imgNum;
        }

        /// <summary>
        /// Запускает отслеживание загружающихся картинок, запоминает номер
        /// </summary>
        /// <param name="imgNum"></param>
        public void SetTask(int imgNum)
        {
            GalleryStorage.Instance.Sprites.CollectionChanged += OnLoad;
            SetImgNum(imgNum);
        }

        private void OnLoad(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.Action == NotifyCollectionChangedAction.Add)
            {
                try
                {
                    Sprite sp = GalleryStorage.Instance.GetSprite(_imgNum);
                    _image.sprite = sp;
                    GalleryStorage.Instance.Sprites.CollectionChanged -= OnLoad;
                }
                catch { ; }
            }
        }

        public void OnClick(BaseEventData eventData)
        {
            PointerEventData eventData1 = eventData as PointerEventData;

            if (eventData1.dragging == false) 
            {
                FindAnyObjectByType<MessageBox>().ImageNum = _imgNum;
                SceneManager.LoadScene(2);
            }               
        }
    }
}
