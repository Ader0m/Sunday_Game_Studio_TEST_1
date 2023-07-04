using Assets.Script.Gallery;
using Assets.Script.Tools;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    [SerializeField] private Image _image;

    private void Awake()
    {
        int num = FindAnyObjectByType<MessageBox>().ImageNum;
        Debug.Log($"Trying get {num}");
        _image.sprite = GalleryStorage.Instance.GetSprite(num);
    }

    void Update()
    {
        ScaleImage();
    }

    /// <summary>
    /// Так как все изображения квадратные устанавливаем в оба параметра устанавливаем высоту.
    /// </summary>
    private void ScaleImage()
    {
        _image.rectTransform.sizeDelta = new Vector2(Screen.height, Screen.height);
    }
}
