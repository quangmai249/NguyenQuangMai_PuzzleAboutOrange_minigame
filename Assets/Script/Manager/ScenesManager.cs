using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : SingletonGeneric<ScenesManager>
{
    public void ChangeToSceneByName(string name)
    {
        switch (name)
        {
            case NameTag.HOME_SCENE:
                SceneManager.LoadScene(NameTag.HOME_SCENE);
                break;
            case NameTag.LEVEL_SCENE:
                SceneManager.LoadScene(NameTag.LEVEL_SCENE);
                break;
            default:
                SceneManager.LoadScene(name);
                break;
        }
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Level 1") == 0)
            PlayerPrefs.SetInt("Level 1", 1);
        PlayerPrefs.Save();

        Debug.Log("Level 1" + "\t" + PlayerPrefs.GetInt("Level 1"));

    }
}
