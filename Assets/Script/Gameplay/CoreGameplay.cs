using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public static class CoreGameplay
{
    public static bool IsReplaced(Vector3 pos)
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag(NameTag.TAG_OBSTACLE))
        {
            if (pos == item.transform.position)
            {
                return true;
            }
        }

        foreach (GameObject item in GameObject.FindGameObjectsWithTag(NameTag.TAG_PLAYER))
        {
            if (pos == item.transform.position)
            {
                return true;
            }
        }

        return false;
    }

    public static bool IsNodeAt(Vector3 pos)
    {
        foreach (Transform item in GameObject.FindGameObjectWithTag(NameTag.TAG_GRID).transform)
        {
            if (pos == item.position)
            {
                return true;
            }
        }
        return false;
    }

    public static void StartMovingObject(float distance, Vector2 swipeDelta, List<Transform> lsOrange)
    {
        Vector3 pos = Vector3.zero;

        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
        {
            if (swipeDelta.x > 0)
            {
                foreach (Transform item in lsOrange)
                {
                    pos = new Vector3(item.transform.position.x + distance, item.transform.position.y);

                    if (IsReplaced(pos) || !CoreGameplay.IsNodeAt(pos))
                        continue;

                    item.transform.DOMoveX(item.transform.position.x + distance, .25f);
                }
            }
            else
            {
                foreach (Transform item in lsOrange)
                {
                    pos = new Vector3(item.transform.position.x - distance, item.transform.position.y);

                    if (IsReplaced(pos) || !CoreGameplay.IsNodeAt(pos))
                        continue;

                    item.transform.DOMoveX(item.transform.position.x - distance, .25f);
                }
            }
        }
        else
        {
            if (swipeDelta.y > 0)
            {
                foreach (Transform item in lsOrange)
                {
                    pos = new Vector3(item.transform.position.x, item.transform.position.y + distance);

                    if (IsReplaced(pos) || !CoreGameplay.IsNodeAt(pos))
                        continue;

                    item.transform.DOMoveY(item.transform.position.y + distance, .25f);
                }
            }
            else
            {
                foreach (Transform item in lsOrange)
                {
                    pos = new Vector3(item.transform.position.x, item.transform.position.y - distance);

                    if (IsReplaced(pos) || !CoreGameplay.IsNodeAt(pos))
                        continue;

                    item.transform.DOMoveY(item.transform.position.y - distance, .25f);
                }
            }
        }
    }

    public static bool IsWinGame(float distance, List<Transform> ls)
    {
        if (
            ls[2].position + new Vector3(distance, 0) == ls[3].position
            && ls[2].position - new Vector3(0, distance) == ls[0].position
            && ls[0].position + new Vector3(distance, 0) == ls[1].position
            )
        {
            Debug.Log("Win Game");
            return true;
        }

        return false;
    }
}
