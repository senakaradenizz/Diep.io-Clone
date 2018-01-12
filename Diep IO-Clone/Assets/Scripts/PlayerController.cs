using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour {

    private const float MAX_HEALTH = 100f;

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
                _health = 0;
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

        Health = MAX_HEALTH;
    }

    void SetHealthGraphics()
    {
        float mappedValue = Map(Health, 0, MAX_HEALTH, 0, 1);

        healthGraphic.localScale = new Vector3(mappedValue, 1, 1);
    }

    float Map(float value, float low1, float high1, float low2, float high2)
    {
        return low2 + (high2 - low2) * (value - low1) / (high1 - low1);
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
