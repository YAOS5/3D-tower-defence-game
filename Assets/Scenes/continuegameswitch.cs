using UnityEngine;
using UnityEngine.SceneManagement;

public class continuegameswitch : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
