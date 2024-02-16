using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    private int enemyCount;
    private GameObject[] enemies;
    private Collider2D[] doorColliders;


    private void OnDestroy()
    {
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
        doorColliders = new Collider2D[doors.Length];
        for (int i = 0; i < doors.Length; i++)
        {
            doorColliders[i] = doors[i].GetComponent<Collider2D>();
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;
        if (enemyCount == 0)
        {
            Debug.Log("���� ����");
            foreach (Collider2D doorCollider in doorColliders)
            {
                if (doorCollider != null)
                {
                    doorCollider.isTrigger = false;
                }
            }
        }
    }
}