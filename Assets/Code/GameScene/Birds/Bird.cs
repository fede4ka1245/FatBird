using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bird : MonoBehaviour, IBird
{
    Rigidbody rigidbody;
    [SerializeField]
    protected const float velocity = 17;
    protected Game Game;
    bool isCollisionEffectOn;
    
    protected void Start()
    {
        isCollisionEffectOn = true;
        rigidbody = GetComponent<Rigidbody>();
        Game = FindObjectOfType<Game>();
    }

    public void Jump()
    {
        rigidbody.velocity = velocity * transform.up;
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" && isCollisionEffectOn)
            Death();
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pipes" && isCollisionEffectOn)
        {
            Game.Score++;
            Game.ShowScore();
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pipe" && isCollisionEffectOn)
            Death();
    }

    public void Reborn()
    {
        StartCoroutine(OffCollisionEffect());
    }

    IEnumerator OffCollisionEffect()
    {
        isCollisionEffectOn = false;
        Game.OnShield();

        yield return new WaitForSeconds(2f);

        isCollisionEffectOn = true;
        Game.OffShield();
    }

    public void Death()
    {
        Game.Death();
        Time.timeScale = 0;
    }
}
