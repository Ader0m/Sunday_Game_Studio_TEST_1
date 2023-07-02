using Assets.Script.Gallery;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

namespace Assets.Script.Gallery
{
    public class ViewController : IGalleryViewController
    {
        private IViewPictures _viewPictures;
        private IDownloadController _loadController;

        public ViewController(IViewPictures viewPuctures, IDownloadController loadController)
        {
            _viewPictures = viewPuctures;
            _loadController = loadController;
        }

        public void ShowPicture(int i)
        {
            if (!GalleryStorage.Instance.alsoDownload.Contains(i))
            {
                _loadController.LoadPicture(i);
                GalleryStorage.Instance.alsoDownload.Add(i);
                _viewPictures.AddPlaceHolderWithTask(i - 1);
                Debug.Log($"Start Load {i} picture");
            }            
            else
            {
                _viewPictures.AddPicture(i - 1);
                Debug.Log($"Use storaged {i} picture");
            }
        }
    }
}
