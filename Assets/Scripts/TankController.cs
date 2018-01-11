using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TankController : MonoBehaviour {

    Camera camera;
    Transform body;
    Rigidbody2D rb2D;
    Vector3 movement;
    public float speed;
    public static TankController instance;





    void Awake()
    {
        camera = Camera.main;
        body = GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();
    }




    void Update()
    {

        
    }


    

    void FixedUpdate()
    {
        // Distance from camera to object.  We need this to get the proper calculation.
        float camDis = camera.transform.position.y - body.position.y;

        // Get the mouse position in world space. Using camDis for the Z axis.
        Vector3 mouse = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        float AngleRad = Mathf.Atan2(mouse.y - body.position.y, mouse.x - body.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;

        rb2D.rotation = angle;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        Move(horizontal, vertical);

    }

    void Move(float horizontal, float vertical)
    {
        movement.Set(horizontal, vertical, 0);
        movement = movement.normalized * speed * Time.deltaTime;
        rb2D.MovePosition(transform.position + movement);
    }

  

}
