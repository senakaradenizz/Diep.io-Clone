using UnityEngine;

public class EntityObstacle : MonoBehaviour {

    public enum ObstacleType
    {
        Triangle,
        Rectangle,
        Polygon
    }

    public ObstacleType obsType;

    public Transform healthGraphic;

    public float maxHealth;
    public float health;
    public float rewards;

    public float Health
    {
        get { return health; }
        set {
            health = value;

            if (health <= 0)
            {
                health = 0;
                //Do something about Die!
                Destroy(gameObject);
            }

            SetHealthGraphics();
        }
    }


    void Start()
    {
        healthGraphic = transform.Find("Health");

        switch (obsType)
        {
            case ObstacleType.Triangle:
                SetValues(10, 5);
                break;
            case ObstacleType.Rectangle:
                SetValues(25, 10);
                break;
            case ObstacleType.Polygon:
                SetValues(50, 25);
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        Health -= Time.deltaTime;
    }

    void SetHealthGraphics()
    {
        float mappedValue = Utility.Map(Health, 0, maxHealth, 0, 1);

        healthGraphic.localScale = new Vector3(mappedValue, 1, 1);
    }

    /// <summary>
    /// Set properties of that obstacle.
    /// </summary>
    /// <param name="maxHealth"></param>
    /// <param name="rewards"></param>
    void SetValues(float maxHealth, float rewards)
    {
        this.maxHealth = maxHealth;
        this.health = maxHealth;

        this.rewards = rewards;
    }

}
