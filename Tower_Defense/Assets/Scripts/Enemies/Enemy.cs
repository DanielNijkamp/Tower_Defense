using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float baseSpeed;

    public float slowspeed;
    public float bossslowspeed;

    [SerializeField] private float arrivalThreshold;
    [SerializeField] private float RotationSpeed;

    public float health;
    public int DamageToPlayer;
    public int DamageMoney;
    
    public Waypoint currentWaypoint;
    public Path path;
    public TextMeshProUGUI HealthText;
    public bool isTopDown;
    private bool IsAtEnd;
    public Slider Healthbar;
    
    
    public bool isBoss;



    private void Start()
    {
        IsAtEnd = false;
        HealthText = GameObject.Find("HealthTextObject").GetComponent<TextMeshProUGUI>();
        HealthText.text = FindObjectOfType<GameManager>().PlayerHealth + " ";
        SetupPath();
    }
    private void FixedUpdate()
    {
        Vector2 direction = currentWaypoint.getPosition() - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

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
        if (isTopDown)
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
        if (IsAtEnd == false)
        {
            FindObjectOfType<GameManager>().PlayerWealth += DamageMoney;
        }
        if (isTopDown)
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
        this.IsAtEnd = true;
        Die();
        int newHealth = FindObjectOfType<GameManager>().PlayerHealth -= value;
        HealthText.text = newHealth + " ";
        if (FindObjectOfType<GameManager>().PlayerHealth <= 0)
        {
            
            FindObjectOfType<GameManager>().Endgame();
        }
        
    }
    public void TakeDamage(float amount)
    {
        health -= amount;;
    }
    private void Awake()
    {
        speed = baseSpeed;
    }
    
}
