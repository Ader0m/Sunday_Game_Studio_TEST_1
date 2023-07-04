using UnityEngine;

namespace Assets.Script.Gallery
{
    /// <summary>
    /// Запускает процессы отображения картинок.
    /// </summary>
    public class ViewController : IGalleryViewController
    {
        private IViewPictures _viewPictures;
        private IDownloadController _loadController;

        public ViewController(IViewPictures viewPuctures, IDownloadController loadController)
        {
            _viewPictures = viewPuctures;
            _loadController = loadController;
        }

        public void ShowPicture(int imgNum)
        {
            if (GalleryStorage.Instance.CheckDownloaded(imgNum))
            {
                _viewPictures.AddPicture(imgNum);
                Debug.Log($"Use storaged {imgNum} picture");
            }
            else
            {
                _loadController.SafetyLoadPicture(imgNum);
                _viewPictures.AddPlaceHolderWithTask(imgNum);
                Debug.Log($"Start Load {imgNum} picture");
            }
        }
    }
}
