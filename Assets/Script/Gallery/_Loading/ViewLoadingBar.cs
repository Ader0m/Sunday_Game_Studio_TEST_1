using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Gallery._Loading
{
    public class ViewLoadingBar : MonoBehaviour, IViewLoadingBar
    {
        // set in inspector
        [SerializeField] private Text _loadText;
        [SerializeField] private Image _loadImage;
        [SerializeField] private GameObject _loadCanvas;
        [SerializeField] private GameObject _galleryCanvas;
        private float _loadProgress;

        public void Update()
        {
            ShowLogick();
            CheckFinishDownload();
        }

        private void CheckFinishDownload()
        {
            if (LoadingStorage.Instance.GetProgress() >= 1)
            {
                SwapCanvas();
            }
        }

        private void SwapCanvas()
        {
            _loadCanvas.SetActive(false);
            _galleryCanvas.SetActive(true);
        }

        private void ShowLogick()
        {
            _loadProgress = LoadingStorage.Instance.GetProgress();

            _loadText.text = (_loadProgress * 100).ToString() + "%";
            _loadImage.fillAmount = _loadProgress;
        }

        public void StartLoadingBallastCoroutine(IEnumerator cor)
        {
            StartCoroutine(cor);
        }
    }
}