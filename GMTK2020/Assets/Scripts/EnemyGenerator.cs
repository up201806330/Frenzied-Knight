using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public int enemyCount = 0;

    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private int maxCount = 7;
    [SerializeField]
    private float cooldown = 5f;

    [SerializeField]
    private bool active = false;

    private void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < maxCount && active)
        {
            yield return new WaitForSeconds(cooldown);
            int x = (Random.Range(0,2) == 0 ? Random.Range(-9, -5) : Random.Range(6, 9)), y = Random.Range(-4, 5);
            GameObject clone = Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(x, y, 1), Quaternion.identity) as GameObject;
            clone.SetActive(true);
            enemyCount++;
            cooldown *= 0.9f;
        }
    }
}