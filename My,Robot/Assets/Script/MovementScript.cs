using UnityEngine;
using System.Collections;
using Assets.Script;

public class MovementScript : MonoBehaviour
{

    Vector2 finalCoordinates = new Vector2(0, 0);
    Vector2 movementVector = new Vector2(0, 0);
    float stepDistance = 0.02f; //How far the player can step per frame.
    // Use this for initialization
    float angle = 0; //angle of velocity



    void Start()
    {

    }
    /*  Movement Controls and Events will be placed in here. (Note that this is regarding player movement only) */
    // Update is called once per frame
    void Update()
    {
        Rigidbody2D player_rb = GameInfo.player.GetComponent<Rigidbody2D>();
        Vector2 playerPosition = GameInfo.player.transform.position;


        if (Input.GetMouseButton(0))
        {
            Camera camera = Camera.main;
            Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

            finalCoordinates = mousePosition;



            Vector2 movementVectorLocal = mousePosition - playerPosition;
            movementVectorLocal.Normalize();

            angle = Vector2.Angle(playerPosition, mousePosition);

            movementVector = movementVectorLocal;

            player_rb.velocity = movementVectorLocal;

        }

         if ((playerPosition - finalCoordinates).magnitude <= stepDistance)
            player_rb.velocity = new Vector2(0,0);
        }

    }
