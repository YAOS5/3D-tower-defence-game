using UnityEngine;
using UnityEngine.SceneManagement;

public class newgameswitch : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
