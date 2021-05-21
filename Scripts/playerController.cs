using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 2.5f;
    public float moveX;
    public bool suelo;
    public Transform paw;
    public LayerMask floorLayer;
    public float jumpForce = 4.5f;
    public int life = 1;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        suelo = Physics2D.OverlapCircle(paw.position, 0.23f, floorLayer);

        moveX = speed * Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && suelo){
            rb.AddForce(new Vector2(moveX, jumpForce), ForceMode2D.Impulse);
        }

        
    }

    void OnTriggerEnter2D(Collider2D other) {
        string gameTag = other.gameObject.tag;
        if(other.gameObject.CompareTag("life")){
            Debug.Log(other.gameObject.tag);
            Destroy(other.gameObject);
            lifeAdmin(gameTag);
        }

    }


    private void OnCollisionEnter2D(Collision2D col) 
    {
        string gameTag = col.gameObject.tag;
        lifeAdmin(gameTag);
        if(col.gameObject.tag.Equals("pinchos")){
            transform.position = new Vector2(-11, 0);
        }
        
    }

    void lifeAdmin(string tag){
        if(tag.Equals("pinchos")){
            life = life - 1;
        }else if(tag.Equals("life")){
            life = life + 1;
        }
        Debug.Log(life);
    }
}
