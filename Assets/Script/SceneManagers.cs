using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{

    public void ChangeToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Destroy(gameObject);
    }
    public void QuitApp()
    {
        Application.Quit();
        Destroy(gameObject); // Hapus salinan ganda GameManager
    }
}
