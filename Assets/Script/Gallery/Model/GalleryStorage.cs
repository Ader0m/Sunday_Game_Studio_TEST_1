using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Assets.Script.Gallery
{
    /// <summary>
    /// Singltone
    /// </summary>
    public class GalleryStorage : IGalleryStorage
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

        public ObservableCollection<Sprite> Sprites { get; private set; }
        public List<int> alsoDownload = new List<int>();

        public GalleryStorage()
        {
            if (Sprites == null)
            {
                Sprites = new();
            }
            _instance = this;
        }

        public void AddSprite(Sprite s)
        {
            Sprites.Add(s);
        }

        public void RemoveSprite(int i)
        {
            Sprites.RemoveAt(i);
        }

        public Sprite GetSprite(int i)
        {
            return Sprites[i];
        }

        public void ClearData()
        {
            Sprites.Clear();
        }
    }
}
