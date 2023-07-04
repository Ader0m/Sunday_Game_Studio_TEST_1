using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Script.Gallery
{
    public class DownloadController : MonoBehaviour, IDownloadController
    {
        private string url = "http://data.ikppbb.com/test-task-unity-data/pics/";

        /// <summary>
        /// Server have only 66 pictures
        /// </summary>
        public void LoadAll()
        {
            for (int i = 1; i < 67; i++)
                SafetyLoadPicture(i);
        }

        /// <summary>
        /// Только лишь запускает загрузку картинки
        /// </summary>
        /// <param name="imgNum"></param>
        public void LoadPicture(int imgNum)
        {
            StartCoroutine(DownloadImage(url + $"{imgNum}.jpg", imgNum));
        }

        /// <summary>
        /// Проверяет скачена ли картинка, если нет, качает и добавляет в список скаченных.
        /// </summary>
        /// <param name="imgNum"></param>
        public void SafetyLoadPicture(int imgNum)
        {
            if (!GalleryStorage.Instance.CheckDownloaded(imgNum))
            {
                StartCoroutine(DownloadImage(url + $"{imgNum}.jpg", imgNum));
            }
        }

        public void AbortDownloads()
        {
            StopAllCoroutines();
        }

        /// <summary>
        /// Сохраняет при успешной загрузке картинку в хранилище
        /// Сохраняет ошибку при не успешной загрузке в хранилище
        /// </summary>
        /// <param name="MediaUrl"></param>
        /// <param name="imgNum"></param>
        /// <returns></returns>
        private IEnumerator DownloadImage(string MediaUrl, int imgNum)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
            yield return request.SendWebRequest();
            if (!string.IsNullOrEmpty(request.error))
            {
                Debug.Log(request.error);
                GalleryStorage.Instance.AddError(imgNum, request.error);
            }
            else
            {
                Texture2D texture2D = ((DownloadHandlerTexture)request.downloadHandler).texture;
                GalleryStorage.Instance.AddSprite(imgNum,
                    Sprite.Create(texture2D, new Rect(0.0f, 0.0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100.0f));
            }
        }
    }
}