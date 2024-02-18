using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject[] spawn;
    private Collider2D _collider2D;
    private bool _isSpawning = true;

    private GameObject navi;
    private AstarPath _astarPath;
    private List<GridGraph> _gridGraphs;
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _isSpawning)
        {
            _collider2D.enabled = false;
            SpawnRandomMonsterPattern();
            _isSpawning = false;
        }
    }

    void SpawnRandomMonsterPattern()
    {
        int randomPattern = Random.Range(0, spawn.Length);
        SpawnMonsterPattern(randomPattern, transform.position);
        foreach (GridGraph gridGraph in _gridGraphs)
        {
            gridGraph.Scan();
        }
    }

    GameObject SpawnMonsterPattern(int patternIndex, Vector3 spawnPosition)
    {
        Debug.Log("����");
        return Instantiate(spawn[patternIndex], spawnPosition, Quaternion.identity);
    }
}
