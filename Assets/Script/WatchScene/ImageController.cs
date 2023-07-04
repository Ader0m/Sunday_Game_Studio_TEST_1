using Assets.Script;
using Assets.Script.Gallery;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script.Tools;

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
    /// ��� ��� ��� ����������� ���������� ������������� � ��� ��������� ������������� ������
    /// </summary>
    private void ScaleImage()
    {
        _image.rectTransform.sizeDelta = new Vector2(Screen.height, Screen.height);
    }
}
