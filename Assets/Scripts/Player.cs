using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LoseMenu loseMenu;
    private Vector3 pos;
    private void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = -1;
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Dead by Enemy");
            Time.timeScale = 0;
            loseMenu.ToggleEndMenu();
        }

    }
}
