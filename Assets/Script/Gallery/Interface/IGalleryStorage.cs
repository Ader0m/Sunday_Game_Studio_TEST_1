using UnityEngine;

namespace Assets.Script.Gallery
{
    public interface IGalleryStorage
    {
        public void AddSprite(int imgNum, Sprite s);
        public void RemoveSprite(int imgNum);
        public Sprite GetSprite(int imgNum);
        public bool CheckDownloaded(int imgNum);
        public void ClearData();
    }
}
