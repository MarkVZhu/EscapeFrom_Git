using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles moving the attached game object between waypoints
/// </summary>
public class OnOffDoor : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("A list of transforms to move between")]
    public List<Transform> waypoints;
    [Tooltip("How fast to move the platform")]
    public float moveSpeed = 1f;

    // Whether or not the waypoint mover is stopped
    [HideInInspector]
    public bool stopped = false;

    private bool allowMove = false;

    private Color doorColor;

    private Color newColor = Color.green;

    // The previous waypoint or the starting position
    private Vector3 previousTarget;
    // The current waypoint being moved to
    private Vector3 currentTarget;
    // The index of the current Target ub tge waypoints list
    private int currentTargetIndex;
    // The current direction being travelled in
    [HideInInspector]
    public Vector3 travelDirection;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player"&&stopped)
        {
            allowMove = true;
            if (this.GetComponent<SpriteRenderer>().color != newColor)
                this.GetComponent<SpriteRenderer>().color = newColor;
            else
                this.GetComponent<SpriteRenderer>().color = doorColor;
        }
    }

    /// <summary>
    /// Description:
    /// Standard Unity function called once before the first update
    /// Input:
    /// none
    /// Return:
    /// void (no return)
    /// </summary>
    void Start()
    {
        InitializeInformation();
        doorColor = this.GetComponent<SpriteRenderer>().color;
    }

    /// <summary>
    /// Description:
    /// Standard Unity function called once every frame
    /// Input:
    /// none
    /// Return:
    /// void
    /// </summary>
    void Update()
    {
        ProcessMovementState();
    }

    /// <summary>
    /// Description:
    /// Processes current state and does movement accordingly
    /// Input:
    /// none
    /// Return:
    /// void (no return)
    /// </summary>
    void ProcessMovementState()
    {
        if (stopped)
        {
            StartCheck();
        }
        else
        {
            Travel();
        }
    }


    /// <summary>
    /// Description:
    /// Checks to see if the waypoint mover can start movement again
    /// Input:
    /// none:
    /// return:
    /// void (no return)
    /// </summary>
    void StartCheck()
    {
        if (allowMove)
        {
            stopped = false;
            allowMove = false;
            previousTarget = currentTarget;
            currentTargetIndex += 1;
            if (currentTargetIndex >= waypoints.Count)
            {
                currentTargetIndex = 0;
            }
            currentTarget = waypoints[currentTargetIndex].position;
            CalculateTravelInformation();
        }
    }

    /// <summary>
    /// Description:
    /// Sets up the first previous target and current target
    /// then calls CalculateTravelInformation to initilize travel direction 
    /// Inuputs:
    /// none
    /// Returns:
    /// void (no return)
    /// </summary>
    void InitializeInformation()
    {
        previousTarget = this.transform.position;
        currentTargetIndex = 0;
        if (waypoints.Count > 0)
        {
            currentTarget = waypoints[0].position;
        }
        else
        {
            waypoints.Add(this.transform);
            currentTarget = previousTarget;
        }

        CalculateTravelInformation();
    }

    /// <summary>
    /// Description:
    /// Calculates the current traveling direction using the previousTarget and the currentTarget
    /// Inuputs:
    /// none
    /// Returns:
    /// void (no return)
    /// </summary>
    void CalculateTravelInformation()
    {
        travelDirection = (currentTarget - previousTarget).normalized;
    }

    /// <summary>
    /// Description:
    /// Translates the transform in the direction towards the next waypoint
    /// Input:
    /// none
    /// Returns:
    /// void
    /// </summary>
    void Travel()
    {
        transform.Translate(travelDirection * moveSpeed * Time.deltaTime);
        bool overX = false;
        bool overY = false;
        bool overZ = false;

        Vector3 directionFromCurrentPositionToTarget = currentTarget - transform.position;

        if (directionFromCurrentPositionToTarget.x == 0 || Mathf.Sign(directionFromCurrentPositionToTarget.x) != Mathf.Sign(travelDirection.x))
        {
            overX = true;
            transform.position = new Vector3(currentTarget.x, transform.position.y, transform.position.z);
        }
        if (directionFromCurrentPositionToTarget.y == 0 || Mathf.Sign(directionFromCurrentPositionToTarget.y) != Mathf.Sign(travelDirection.y))
        {
            overY = true;
            transform.position = new Vector3(transform.position.x, currentTarget.y, transform.position.z);
        }
        if (directionFromCurrentPositionToTarget.z == 0 || Mathf.Sign(directionFromCurrentPositionToTarget.z) != Mathf.Sign(travelDirection.z))
        {
            overZ = true;
            transform.position = new Vector3(transform.position.x, transform.position.y, currentTarget.z);
        }

        // If we are over the x, y, and z of our target we need to stop
        if (overX && overY && overZ)
        {
            BeginWait();
        }
    }

    /// <summary>
    /// Description:
    /// Starts the waiting, sets up the needed variables for waiting
    /// Input:
    /// none
    /// Return:
    /// void (no return)
    /// </summary>
    void BeginWait()
    {
        stopped = true;
    }
}
