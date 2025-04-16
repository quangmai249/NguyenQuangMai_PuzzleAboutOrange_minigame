using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [Header("Node Block")]
    [SerializeField] int numNodeBlock;
    [SerializeField] GameObject nodeBlock;
    [SerializeField] GameObject obstaclesParent;
    [SerializeField] List<int> posNodeBlock;

    [Header("Node Orange")]
    [SerializeField] List<int> nodeIndex;
    [SerializeField] List<int> posNodeOrange;

    [Header("List Objects")]
    [SerializeField] List<Transform> lsGrid;
    [SerializeField] List<Transform> lsOrange;
    [SerializeField] List<Transform> lsBlock;

    private GameObject grid;
    private GameObject orange;
    private GameObject obstacle;
    private void Awake()
    {
        grid = GameObject.FindGameObjectWithTag(NameTag.TAG_GRID);
        orange = GameObject.FindGameObjectWithTag(NameTag.TAG_ORANGE);

        for (int i = 0; i < numNodeBlock; i++)
        {
            obstacle = Instantiate(nodeBlock);
            obstacle.transform.SetParent(obstaclesParent.transform);
        }
    }

    private void Start()
    {
        foreach (Transform item in grid.transform)
            lsGrid.Add(item);

        foreach (Transform item in orange.transform)
            lsOrange.Add(item);

        foreach (GameObject item in GameObject.FindGameObjectsWithTag(NameTag.TAG_OBSTACLE))
            lsBlock.Add(item.transform);

        Time.timeScale = 1;

        this.SetPosNodeDefault();
    }

    private void SetPosNodeDefault()
    {
        int count = 0;

        foreach (Transform item in lsBlock)
        {
            item.transform.position = lsGrid[posNodeBlock[count]].position;
            lsGrid[posNodeBlock[count]].GetComponent<NodeGrid>().IsReplaced = true;
            count++;
        }

        for (int i = 0; i < lsOrange.Count; i++)
        {
            lsGrid[posNodeOrange[i]].gameObject.GetComponent<NodeGrid>().IsReplaced = true;
            lsOrange[nodeIndex[i]].position = lsGrid[posNodeOrange[i]].position;
        }
    }

    public List<Transform> ListGid
    {
        get => this.lsGrid;
    }

    public List<Transform> ListOrange
    {
        get => this.lsOrange;
    }
}
