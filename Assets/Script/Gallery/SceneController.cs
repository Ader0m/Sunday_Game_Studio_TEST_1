using Assets.Script.Gallery._Loading;
using Assets.Script.Tools;
using UnityEngine;

namespace Assets.Script.Gallery
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private GameObject _galleryCanvas;

        #region Gallery

        public IDownloadController DownloadController;

        public IViewPictures ViewPictures;
        public IGalleryViewController ViewController;
        public IGalleryStorage GalleryStor;

        #endregion

        #region LoadingBar

        public IViewLoadingBar ViewLoadBar;
        public IViewLoadingController ViewLoadController;
        public ILoadingStorage LoadingStorage;

        #endregion

        private void Awake()
        {
            Orientation.OrientationFree(false);

            DownloadController = GetComponent<DownloadController>();
            ViewPictures = GetComponentInChildren<ViewPictures>();
            ViewController = new ViewController(ViewPictures, DownloadController);
            if (GalleryStorage.Instance == null) 
                GalleryStor = new GalleryStorage();
            else
                GalleryStor = GalleryStorage.Instance;

            ViewLoadBar = GetComponentInChildren<ViewLoadingBar>();
            ViewLoadController = new ViewLoadingController(this);
            LoadingStorage = new LoadingStorage();
        }

        private void Start()
        {
            _galleryCanvas.SetActive(false);

            DownloadController.SafetyLoadPicture(3);
            DownloadController.SafetyLoadPicture(4);
            ViewLoadController.StartLoading();
        }

        
    }
}
