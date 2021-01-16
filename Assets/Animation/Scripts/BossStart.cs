using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStart : MonoBehaviour
{
    public GameObject BossHP;
    public Animator BattleStart;

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            BossHP.SetActive(true);
            BattleStart.SetTrigger("Start");
        }
    }
}
