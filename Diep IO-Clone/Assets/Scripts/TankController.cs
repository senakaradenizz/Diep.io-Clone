using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

    private Transform body;
    private Rigidbody2D rb2D;
    private Vector3 direction;
    private PlayerController playerController;

    public static TankController instance;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        body = GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        LookAtToMouse();

        //Getting input from user.
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);
    }

    void Move(float horizontal, float vertical)
    {
        direction = new Vector3(horizontal, vertical, 0);
        rb2D.velocity = direction.normalized * playerController.maxSpeed;
    }

    void LookAtToMouse()
    {
        // Distance from camera to object.  We need this to get the proper calculation.
        float camDis = Camera.main.transform.position.y - body.position.y;

        // Get the mouse position in world space. Using camDis for the Z axis.
        Vector3 mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        float AngleRad = Mathf.Atan2(mouse.y - body.position.y, mouse.x - body.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;

        rb2D.rotation = angle;
    }
}
