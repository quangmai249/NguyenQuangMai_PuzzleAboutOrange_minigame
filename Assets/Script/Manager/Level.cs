using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] bool isUnlocked;
    [SerializeField] string levelName;
    [SerializeField] GameObject imgLock;

    private void Awake()
    {
        this.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = this.name;
    }

    private void Start()
    {
        levelName = gameObject.name;

        imgLock = this.transform.GetChild(0).gameObject;

        isUnlocked = PlayerPrefs.GetInt(levelName) == 1 ? true : false;

        if (isUnlocked)
        {
            imgLock.SetActive(false);
        }
        else
        {
            imgLock.SetActive(true);
        }

        this.GetComponent<Button>().interactable = isUnlocked;
    }

    public bool IsUnlocked { get => isUnlocked; set => isUnlocked = value; }
    public string LevelName { get => levelName; set => levelName = value; }
}