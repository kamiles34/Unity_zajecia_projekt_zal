using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{

    public float life;
    public float contactdamage = 5f;
    private float deathtimer = 5f;
    private float flipdelay = 0.75f;

    private Transform playerPos;
    private bool facingRight = false;

    public Slider healthBar;
    public GameObject slider;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        playerPos = GameObject.FindWithTag("Player").transform;

        if (playerPos.position.x > transform.position.x && !facingRight)
            if (flipdelay <= 0) { 
                Flip(); }
            else { 
                flipdelay -= Time.deltaTime; }

        if (playerPos.position.x < transform.position.x && facingRight)
            if (flipdelay <= 0) { 
                Flip();}
            else { 
                flipdelay -= Time.deltaTime; }

        if (life <= 0)
        {
            anim.SetTrigger("Death");
            if (deathtimer <= 0)
            {
                Destroy(gameObject);
                slider.SetActive(false);
            }
            else
            {
                deathtimer -= Time.deltaTime;
            }
            
        }

        healthBar.value = life;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && life > 0)
        {
            collision.gameObject.GetComponent<CharacterController2D>().ApplyDamage(contactdamage, transform.position);
        }
    }

    public void ApplyDamage(float damage)
    {
            damage = Mathf.Abs(damage);
            life -= damage;

    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingRight = !facingRight;
    }
}