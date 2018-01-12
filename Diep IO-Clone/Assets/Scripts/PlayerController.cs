using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 25f;

    //public Transform healthGameObject;

    //private float _health;

    //public float Health
    //{
    //    get { return _health; }
    //    set
    //    {
    //        _health = value;
    //        SetHealthGraphics();
    //    }
    //}

    public Transform bulletSlot;
    public Transform bulletPrefab;

    void Start()
    {
        //Health = 100;
    }

    //void SetHealthGraphics()
    //{
    //    healthGameObject.localScale = (new Vector3(_health / 100f, 1, 1));
    //}

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

        //Health -= 5 * Time.deltaTime;
    }
}
