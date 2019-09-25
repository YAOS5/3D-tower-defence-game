using UnityEngine;
using UnityEngine.SceneManagement;

public class backswitch : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
