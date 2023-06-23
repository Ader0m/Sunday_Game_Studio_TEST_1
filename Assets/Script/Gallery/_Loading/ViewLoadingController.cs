using System.Collections;
using UnityEngine;

namespace Assets.Script.Gallery._Loading
{
    public class ViewLoadingController : IViewLoadingController
    {
        private SceneController _sceneController;
        private float ballastTime = 2;

        public ViewLoadingController(SceneController sceneController)
        {
            _sceneController = sceneController;
        }

        public void StartLoading()
        {
            LoadFirstPictures();
            LoadBallast();
        }

        private void LoadBallast()
        {
            _sceneController.ViewLoadBar.StartLoadingBallastCoroutine(BallastLoad(ballastTime));
        }

        private void LoadFirstPictures()
        {            
            _sceneController.ViewController.ShowPicture(1);
            LoadingStorage.Instance.SetProgress(0.2f);
            _sceneController.ViewController.ShowPicture(2);
            LoadingStorage.Instance.SetProgress(0.4f);
        }

        IEnumerator BallastLoad(float time)
        {
            float updateTime = 0.1f;
            float step = LoadingStorage.Instance.GetProgress() / time * updateTime;

            while (LoadingStorage.Instance.GetProgress() < 1)
            {
                LoadingStorage.Instance.AddProgress(step);
                yield return new WaitForSeconds(updateTime);
            }
        }
    }
}
