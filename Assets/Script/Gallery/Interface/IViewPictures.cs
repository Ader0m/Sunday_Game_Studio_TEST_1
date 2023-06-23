using UnityEngine;

namespace Assets.Script.Gallery
{
    public interface IViewPictures
    {
        public void AddPicture(Sprite sprite);

        public void AddPlaceHolder();

        public void AddPlaceHolderWithTask(int imgNum);
    }
}
