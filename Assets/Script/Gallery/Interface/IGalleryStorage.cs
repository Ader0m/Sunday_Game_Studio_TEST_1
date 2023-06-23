using UnityEngine;

namespace Assets.Script.Gallery
{
    public interface IGalleryStorage
    {
        public void AddSprite(Sprite s);
        public void RemoveSprite(int i);
        public Sprite GetSprite(int i);
        public void ClearData();
    }
}
