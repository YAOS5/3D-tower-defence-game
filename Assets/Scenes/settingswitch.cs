using UnityEngine;
using UnityEngine.SceneManagement;

public class settingswitch : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("SettingScene");
    }
}
