using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using UnityEngine;


public class MoveNavi : MonoBehaviour
{
    BoxCollider2D doorCol;

    public Vector3 playerInPosition;
    private Vector3 changePosition;
    private GameObject navi;
    private AstarPath _astarPath;
    private List<GridGraph> _gridGraphs;
    private Collider2D[] doorColliders;
    private GameObject[] enemies;
    private GameObject[] doors;
    void Awake()
    {
        doorCol = GetComponent<BoxCollider2D>();

        switch (gameObject.name)
        {
            case "LeftDoor":
                playerInPosition = Vector3.left;
                break;
            case "RightDoor":
                playerInPosition = Vector3.right;
                break;
            case "UpDoor":
                playerInPosition = Vector3.up;
                break;
            case "DownDoor":
                playerInPosition = Vector3.down;
                break;
        }
    }

    private void Start()
    {
        navi = GameObject.FindWithTag("GameController");
        _astarPath = navi.GetComponent<AstarPath>();
        _gridGraphs = new List<GridGraph>();
        for (int i = 0; i < Mathf.Min(2, _astarPath.graphs.Length); i++)
        {
            if (_astarPath.graphs[i] is GridGraph)
            {
                _gridGraphs.Add(_astarPath.graphs[i] as GridGraph);
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(OpenDoor(collision.gameObject));
        }
    }
    IEnumerator OpenDoor(GameObject collision)
    {
        yield return new WaitForEndOfFrame();
        Debug.Log("���̵�");
        collision.gameObject.transform.position += playerInPosition * 4;

        if (gameObject.name == "UpDoor")
        {
            foreach (GridGraph gridGraph in _gridGraphs)
            {
                gridGraph.center.y += 10;
                gridGraph.Scan();
            }
        }
        else if (gameObject.name == "DownDoor")
        {
            foreach (GridGraph gridGraph in _gridGraphs)
            {
                gridGraph.center.y -= 10;
                gridGraph.Scan();
            }
        }
        else if (gameObject.name == "RightDoor")
        {
            foreach (GridGraph gridGraph in _gridGraphs)
            {
                gridGraph.center.x += 18;
                gridGraph.Scan();
            }
        }
        else if (gameObject.name == "LeftDoor")
        {
            foreach (GridGraph gridGraph in _gridGraphs)
            {
                gridGraph.center.x -= 18;
                gridGraph.Scan();
            }
        }
    }
}