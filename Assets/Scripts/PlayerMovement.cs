using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 1.0f;
    private int moveSpeedRest;

    //from dialogue vid
    private NPC_Controller npc; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!inDialogue()) //if statement is from dialogue vid, may have to delete
        {
            moveH = Input.GetAxis("Horizontal") * moveSpeed;
            moveV = Input.GetAxis("Vertical") * moveSpeed;
            rb.velocity = new Vector2(moveH, moveV);//OPTIONAL rb.MovePosition();

            Vector2 direction = new Vector2(moveH, moveV);

            FindObjectOfType<PlayerAnimation>().SetDirection(direction);
        }        
    }

    //From Dialogue Vid, may have to delete

    private bool inDialogue()
    {
        if(npc != null)
        {
            return npc.DialogueActive();
        }

        else
        {
            return false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "NPC")
        {
            //npc = collision.gameObject.GetComponent<NPC_Controller>(); //old code from npc controller was still being used

            if (Input.GetKeyDown(KeyCode.Space))
            {

                //collision.gameObject.GetComponent<NPC_Controller>().ActivateDialogue(); //old code from npc controller was still being used
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            npc = null;
        }
    }
}
