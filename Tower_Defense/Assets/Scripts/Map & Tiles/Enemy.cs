using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float arrivalThreshold;
    public int health;
    public int DamageToPlayer;
    public Path path;
    public Waypoint currentWaypoint;
    public TextMeshProUGUI HealthText;
    
    private void Start()
    {
        HealthText.text = FindObjectOfType<GameManager>().PlayerHealth + " ";
        SetupPath();
    }
    private void FixedUpdate()
    {
        Vector2 direction = currentWaypoint.getPosition() - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //tank
        //Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, currentWaypoint.getPosition(), step);
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
        
    }
    void SetupPath()
    {
        path = FindObjectOfType<Path>();
        currentWaypoint = path.getPathStart();
    }
    void PathComplete(int value)
    {
        int newHealth = FindObjectOfType<GameManager>().PlayerHealth -= value;
        HealthText.text =  newHealth + " ";
        Destroy(gameObject);
        if (FindObjectOfType<GameManager>().PlayerHealth == 0)
        {
            FindObjectOfType<GameManager>().Endgame();
        }
    }
}
