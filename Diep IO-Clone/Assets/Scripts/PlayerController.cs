using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 25f;

    private Transform healthGraphic;

    //public Transform healthGameObject;

    private float _health;

    public float Health
    {
        get { return _health; }
        set
        {
            _health = value;

            if (_health <= 0)
            {
                //Do something about Die!
                Debug.Log("You died!");
            }

            SetHealthGraphics();
        }
    }

    public Transform bulletSlot;
    public Transform bulletPrefab;

    void Start()
    {
        healthGraphic = transform.Find("Health");

        Health = 100;
    }

    void SetHealthGraphics()
    {
        healthGraphic.localScale = new Vector3(Health / 100, 1, 1);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Left Mouse pressed down.
        {
            //Get mouse position
            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = Input.mousePosition - objectPos;

            GameObject bullet = Instantiate(bulletPrefab.gameObject, bulletSlot.position, Quaternion.identity);
            bullet.GetComponent<BulletManager>().direction = dir;
        }

        Health -= 5 * Time.deltaTime;
    }
}
