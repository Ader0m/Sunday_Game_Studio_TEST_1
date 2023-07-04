using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Script.Tools;

namespace Assets.Script.Gallery
{
    /// <summary>
    /// Управление отображением на объекте самой картинки. 
    /// Умеет ждать загрузки картинки, просматривая хранилище.
    /// При нажатии загружает сцену просмотра картинки.
    /// </summary>
    public class PlaceHolderTask : MonoBehaviour, IPlaceHolderTask
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private int _imgNum;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _text = GetComponentInChildren<TextMeshProUGUI>();
        }

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
            GalleryStorage.Instance.Notify += OnLoad;
            SetImgNum(imgNum);
        }

        private void OnLoad(int newImgNum)
        {
            if (_imgNum == newImgNum)
            {
                try
                {
                    Sprite sp = GalleryStorage.Instance.GetSprite(_imgNum);
                    _image.sprite = sp;
                    GalleryStorage.Instance.Notify -= OnLoad;
                }
                catch
                {
                    _text.text = GalleryStorage.Instance.GetError(_imgNum);
                }
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
