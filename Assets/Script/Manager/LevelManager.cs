using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Transform lsLevel;
    private void Awake()
    {
        foreach (Transform item in lsLevel.transform)
        {
            Level level = item.gameObject.GetComponent<Level>();

            if (level != null)
            {
                Debug.Log(level.LevelName + "\t" + PlayerPrefs.GetInt(level.LevelName));

                if (PlayerPrefs.GetInt(level.LevelName, 0) == 0)
                    level.IsUnlocked = false;
                else
                    level.IsUnlocked = true;
            }
        }
    }

    private void Start()
    {

    }
}
