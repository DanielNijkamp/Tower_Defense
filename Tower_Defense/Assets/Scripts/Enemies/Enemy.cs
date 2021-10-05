using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float baseSpeed;

    [SerializeField] private float arrivalThreshold;
    [SerializeField] private float RotationSpeed;
    public int health;
    public int DamageToPlayer;
    public Path path;
    public Waypoint currentWaypoint;
    public TextMeshProUGUI HealthText;
    public bool isTank;
    public Slider Healthbar;


    private void Start()
    {
        
        HealthText = GameObject.Find("HealthTextObject").GetComponent<TextMeshProUGUI>();
        HealthText.text = FindObjectOfType<GameManager>().PlayerHealth + " ";
        SetupPath();
    }
    private void FixedUpdate()
    {
        Vector2 direction = currentWaypoint.getPosition() - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //tank
        Quaternion rotation = Quaternion.AngleAxis(angle, transform.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation,RotationSpeed * Time.deltaTime);

        transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.getPosition(), speed * Time.deltaTime);
        float distanceToWaypoint = Vector2.Distance(transform.position, currentWaypoint.getPosition());
        if (distanceToWaypoint <= arrivalThreshold)
        {
            if (currentWaypoint == path.getPathEnd())
            {
                PathComplete(DamageToPlayer);
            }
            else
            {
                currentWaypoint = path.getNextWayPoint(currentWaypoint);

            }
        }
        this.Healthbar.value = health;

        if (health <= 0)
        {
            Die();
        }
        if (isTank)
        {
            Healthbar.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.6f);
        }
        
        
    }
    void SetupPath()
    {
        path = FindObjectOfType<Path>();
        currentWaypoint = path.getPathStart();
    }
    void Die()
    {
        if (isTank)
        {
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        
    }
    void PathComplete(int value)
    {
        Die();
        int newHealth = FindObjectOfType<GameManager>().PlayerHealth -= value;
        HealthText.text = newHealth + " ";
        if (FindObjectOfType<GameManager>().PlayerHealth <= 0)
        {
            
            FindObjectOfType<GameManager>().Endgame();
        }
        
    }
    private void Awake()
    {
        speed = baseSpeed;
    }
}
