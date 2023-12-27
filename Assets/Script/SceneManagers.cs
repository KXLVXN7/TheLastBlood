using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{

    public void ChangeToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
