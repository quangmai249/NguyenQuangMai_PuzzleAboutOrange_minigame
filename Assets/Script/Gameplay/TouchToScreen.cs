using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToScreen : MonoBehaviour
{
    [SerializeField] Vector2 startTouchPos, endTouchPos;
    [SerializeField] GameObject square;

    private List<Transform> lsGrid;
    private List<Transform> lsOrange;
    private Gameplay gameplay;
    private UIManager uiManager;

    private float distanceNode;
    private void Awake()
    {
        gameplay = GameObject.FindGameObjectWithTag(NameTag.TAG_GAME_CONTROLLER).GetComponent<Gameplay>();
    }

    private void Start()
    {
        lsGrid = gameplay.ListGid;
        lsOrange = gameplay.ListOrange;

        uiManager = GameObject.FindGameObjectWithTag(NameTag.TAG_UI_MANAGER).GetComponent<UIManager>();
    }

    private void Update()
    {
        SwipeOnScreen();
    }

    private void SwipeOnScreen()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPos = this.GetTouchPosition(0);
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPos = this.GetTouchPosition(0);
                StartCoroutine(nameof(StartMovingWipe));
            }

            return;
        }
    }

    private IEnumerator StartMovingWipe()
    {
        Vector2 swipeDelta = endTouchPos - startTouchPos;
        distanceNode = Vector2.Distance(lsGrid[0].position, lsGrid[1].position);

        if (swipeDelta.magnitude > 0.3)
        {
            CoreGameplay.StartMovingObject(distanceNode, swipeDelta, lsOrange);
            yield return new WaitForSeconds(0.35f);

            if (CoreGameplay.IsWinGame(distanceNode, lsOrange))
            {
                uiManager.EndGame(0);
            }
        }
    }

    private Vector3 GetTouchPosition(int indexTouch)
    {
        return new Vector3(
            Camera.main.ScreenToWorldPoint(Input.GetTouch(indexTouch).position).x,
            Camera.main.ScreenToWorldPoint(Input.GetTouch(indexTouch).position).y,
            0);
    }
}
