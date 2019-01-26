using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fountain : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private LoseMenu loseMenu;
    private int score = 0;
    

    private void Start()
    {
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<Enemy>().alive = false;
            score += 1;
            scoreText.text = score.ToString();
        }


        if (col.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            Debug.Log("Dead by Fountain");
            loseMenu.ToggleEndMenu();
        }
    }
}
