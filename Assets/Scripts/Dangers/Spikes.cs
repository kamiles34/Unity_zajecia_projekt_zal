using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private bool cooldownactive = false;
    public float cooldowntime = 1f;
    public float contactdamage = 5;


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !cooldownactive)
        {
            collision.gameObject.GetComponent<CharacterController2D>().ApplyDamage(contactdamage, transform.position);
            StartCoroutine(Damagecooldown());
            cooldownactive = true;
        }
    }

    IEnumerator Damagecooldown()
    {
        yield return new WaitForSeconds(cooldowntime);
        cooldownactive = false;
    }
}
