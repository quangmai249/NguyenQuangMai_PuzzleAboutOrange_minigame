using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public void ButtonLevelScene()
    {
        ScenesManager.Instance.ChangeToSceneByName(NameTag.LEVEL_SCENE);
    }

    public void ButtonHomeScene()
    {
        ScenesManager.Instance.ChangeToSceneByName(NameTag.HOME_SCENE);
    }

    public void ButtonGameplay(Button button)
    {
        SceneManager.LoadScene(button.name);
    }

    public void ButtonReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ButtonExit()
    {
        Debug.Log("Exited game");
        Application.Quit();
    }
}
