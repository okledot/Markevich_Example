using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int count = 5;
    [SerializeField] private int newLevelCount = 5;
    private GameObject[] _enemy;

    private float width = 20f;
    private float height = 16f;

    private void Awake()
    {
        for (int i = 1; i <= count; i++)
            Spawn();
    }


    private void Update()
    {
        _enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (_enemy.Length == 0)
        {
            count += newLevelCount;
            for (int i = 1; i <= count; i++)
                Spawn();
        }

    }

    private void Spawn()
    {
        float posX = 0f;
        float posY = 0f;
        //while ((posX >= -10) && (posX <= 10))
            posX = Random.Range(-12f, 12f);
        while ((posY >= -6) && (posY <= 6)) posY = Random.Range(-8f, 8f);

        Vector3 pos = new Vector3(posX, posY, -1);
        Instantiate(enemy, pos, Quaternion.identity);
    }
}
