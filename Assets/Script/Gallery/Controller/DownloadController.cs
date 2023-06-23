using System.Collections;
using System.Collections.Generic;
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
        /// <param name="i"></param>
        public void LoadPicture(int i)
        {
            StartCoroutine(DownloadImage(url + $"{i}.jpg"));           
        }

        /// <summary>
        /// Проверяет скачена ли картинка, если нет, качает и добавляет в список скаченных.
        /// </summary>
        /// <param name="i"></param>
        public void SafetyLoadPicture(int i)
        {
            if (!GalleryStorage.Instance.alsoDownload.Contains(i))
            {
                GalleryStorage.Instance.alsoDownload.Add(i);
                StartCoroutine(DownloadImage(url + $"{i}.jpg"));                
            }               
        }

        public void AbortDownloads()
        {
            StopAllCoroutines();
        }

        /// <summary>
        /// Also save image when successful download
        /// </summary>
        /// <param name="MediaUrl"></param>
        /// <returns></returns>
        private IEnumerator DownloadImage(string MediaUrl)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
            yield return request.SendWebRequest();
            if (!string.IsNullOrEmpty(request.error))
            {
                Debug.Log(request.error);
            }
            else
            {
                Texture2D texture2D = ((DownloadHandlerTexture)request.downloadHandler).texture;
                GalleryStorage.Instance.AddSprite(Sprite.Create(texture2D, new Rect(0.0f, 0.0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100.0f));
            }
        }
    }
}