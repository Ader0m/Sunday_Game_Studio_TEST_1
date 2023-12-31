﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Gallery
{
    /// <summary>
    /// Промежутожный скрипт между контроллером и картинкой. Создает и инициализирует обьекты картинок
    /// </summary>
    public class ViewPictures : MonoBehaviour, IViewPictures
    {
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;
        [SerializeField] private GameObject _imagePrefab;
        [SerializeField] private GameObject _scrollView;
        private List<GameObject> _images;
        private List<GameObject> _places;

        private void Awake()
        {
            _images = new();
            _places = new();
        }

        public void AddPicture(int imgNum)
        {
            if (_places.Count == 0)
                AddPlaceHolder();

            _places[0].GetComponent<Image>().sprite = GalleryStorage.Instance.GetSprite(imgNum);
            _places[0].GetComponent<IPlaceHolderTask>().SetImgNum(imgNum);
            _images.Add(_places[0]);
            _places.Remove(_places[0]);
        }

        public void AddPlaceHolder()
        {
            GameObject obj = Instantiate(_imagePrefab, _gridLayoutGroup.transform);
            _places.Add(obj);
        }

        public void AddPlaceHolderWithTask(int imgNum)
        {
            GameObject obj = Instantiate(_imagePrefab, _gridLayoutGroup.transform);
            obj.GetComponent<IPlaceHolderTask>().SetTask(imgNum);
            _images.Add(obj);
        }
    }
}