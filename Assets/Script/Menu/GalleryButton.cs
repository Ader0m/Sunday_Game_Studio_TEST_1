using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryButton : MonoBehaviour
{
    public void OnClick()
    {
        LoadGalleryScene();
    }

    private void LoadGalleryScene()
    {
        SceneManager.LoadScene(1);
    }
}
