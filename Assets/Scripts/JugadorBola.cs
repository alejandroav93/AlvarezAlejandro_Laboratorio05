
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorBola : MonoBehaviour
{
    public float force = 1.5f;
    Rigidbody rb;
    LevelManager manager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        manager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (rb)
        {
            rb.AddForce(Input.GetAxis("Horizontal") * force, 0, Input.GetAxis("Vertical") * force);
        }
    }
    void Jump()
    {
        if (rb && Mathf.Abs(rb.velocity.y) < 0.05f)
        {
          GameObject.FindObjectOfType<AudioManager>().PlayJump();
            rb.AddForce(0, force *2, 0, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && manager.Score <3){
            GameObject.FindObjectOfType<AudioManager>().PlayDeath();

            Destroy(gameObject);
        }

        
    }
    private void OnCollisionStay(Collision collision)
    {

    }
    private void OnCollisionExit(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            GameObject.FindObjectOfType<AudioManager>().PlayCoin();

            Destroy(other.gameObject);
            manager.Score++;
        }
    }
}
