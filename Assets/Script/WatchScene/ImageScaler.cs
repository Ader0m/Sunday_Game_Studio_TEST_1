using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ImageScaler : MonoBehaviour
{
    [SerializeField] private Image _image;
    
    void Update()
    {
        ScaleImage();
    }

    /// <summary>
    /// Так как все изображения квадратные устанавливаем в оба параметра устанавливаем ширину
    /// </summary>
    private void ScaleImage()
    {
        _image.rectTransform.sizeDelta = new Vector2(Screen.height, Screen.height);
    }
}
