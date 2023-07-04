using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Gallery
{
    /// <summary>
    /// Singltone. Класс реализует интерфейс хранилища картинок и хранилища ошибок.
    /// Так же запускает эвент при появлении новой картинки или ошибки.
    /// </summary>
    public class GalleryStorage : IGalleryStorage, IErrorStorage
    {
        #region Singltone
        public static GalleryStorage Instance
        {
            get
            {
                return _instance;
            }
        }
        private static GalleryStorage _instance;
        #endregion

        public delegate void AddEvent(int imgNum);
        public event AddEvent Notify;

        private Dictionary<int, Sprite> _sprites = new();
        private Dictionary<int, string> _errorDownload;

        public GalleryStorage()
        {
            _sprites = new();
            _errorDownload = new();
            _instance = this;
        }

        public void AddSprite(int imgNum, Sprite s)
        {
            _sprites[imgNum] = s;
            if (Notify != null)
            {
                Notify.Invoke(imgNum);
            }
        }

        public void RemoveSprite(int imgNum)
        {
            _sprites.Remove(imgNum);
        }

        public Sprite GetSprite(int imgNum)
        {
            return _sprites[imgNum];
        }

        public void ClearData()
        {
            _sprites.Clear();
        }

        public bool CheckDownloaded(int imgNum)
        {
            return _sprites.ContainsKey(imgNum);
        }

        public string GetError(int imgNum)
        {
            Debug.Log($"DICTIONARY READ ERROR n{imgNum} er{_errorDownload[imgNum]}");
            return _errorDownload[imgNum];
        }

        public void AddError(int imgNum, string error)
        {
            Debug.Log($"DICTIONARY ADD ERROR n{imgNum} er{error}");
            _errorDownload[imgNum] = error;
            if (Notify != null)
            {
                Notify.Invoke(imgNum);
            }
        }
    }
}
