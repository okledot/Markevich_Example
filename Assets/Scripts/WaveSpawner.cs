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
        
        List<float> size = new List<float>() {0.04f, 0.08f, 0.16f};

        while ( ((posX >= -10) && (posX <= 10) ) && ( (posY >= -6) && (posY <= 6) ) )
        {
            posX = Random.Range(-12f, 12f);
            posY = Random.Range(-8f, 8f);
        }

        int level = (int)Random.Range(0, 5);
        Debug.Log(level);
        enemy.GetComponent<Enemy>().speed = 6 - (1.2f * level);
        enemy.GetComponent<Transform>().localScale = new Vector3(0.04f + (0.04f * level) , 0.04f + (0.04f * level), 0.04f + (0.04f * level));

        Vector3 pos = new Vector3(posX, posY, -1);
        Instantiate(enemy, pos, Quaternion.identity);
        
    }
}
