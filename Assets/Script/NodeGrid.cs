using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGrid : MonoBehaviour
{
    [SerializeField] bool isReplaced = false;

    public bool IsReplaced
    {
        get => this.isReplaced;
        set => this.isReplaced = value;
    }
}
