using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DezainAI : MonoBehaviour
{
    public float roamRadius = 10f;
    public float stoppingDistance = 0.1f;
    public Transform[] waypoints;
    public float followCooldownDuration = 10f;
    public Transform player; // Change player type to Transform

    private int currentWaypointIndex = 0;
    private NavMeshAgent navMeshAgent;
    private Vector3 startingPosition;
    private bool isFollowingPlayer = false;
    private bool isOnCooldown = false;
    private bool isPlayerTouchingAI = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updatePosition = false;
        startingPosition = transform.position;

        // Make sure the player Transform is assigned in the Inspector
        if (player == null)
        {
            Debug.LogError("Player is not assigned to the AI. Please assign the player Transform in the Inspector.");
            enabled = false; // Disable the script if the player is not assigned to prevent errors.
        }

        // Shuffle the waypoints array randomly at the start
        ShuffleWaypoints();

        SetRandomDestination();
    }

    void Update()
    {
        if (isPlayerTouchingAI || isOnCooldown || isFollowingPlayer) return;

        if (waypoints.Length > 0 && navMeshAgent.remainingDistance <= stoppingDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
        else if (waypoints.Length == 0 && navMeshAgent.remainingDistance <= stoppingDistance)
        {
            SetRandomDestination();
        }

        Vector3 newPosition = navMeshAgent.nextPosition;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFollowingPlayer && !isOnCooldown)
        {
            Debug.Log("AI detected the player.");
            StartCoroutine(FollowPlayerCoroutine());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // If the player is touching the AI, temporarily disable NavMeshAgent to allow the AI to be pushed aside
            isPlayerTouchingAI = true;
            navMeshAgent.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Re-enable NavMeshAgent when the player stops touching the AI
            isPlayerTouchingAI = false;
            navMeshAgent.enabled = true;
        }
    }

    private IEnumerator FollowPlayerCoroutine()
    {
        isFollowingPlayer = true;

        while (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            navMeshAgent.SetDestination(player.position);
            yield return null;
        }

        TeleportPlayerToRandomPosition();
        StartCooldown();

        Debug.Log("Player has been teleported to a random position.");

        isFollowingPlayer = false;
    }

    private void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * roamRadius;
        randomDirection += startingPosition;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, roamRadius, NavMesh.AllAreas);
        navMeshAgent.SetDestination(hit.position);
    }

    private void TeleportPlayerToRandomPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * roamRadius;
        randomDirection += startingPosition;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, roamRadius, NavMesh.AllAreas))
        {
            player.position = hit.position;

            // The AI will teleport to a new random waypoint after teleporting the player
            SetRandomDestination();
        }
        else
        {
            // If a valid position is not found, try teleporting again
            TeleportPlayerToRandomPosition();
        }
    }

    private void StartCooldown()
    {
        isOnCooldown = true;
        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(followCooldownDuration);
        isOnCooldown = false;
    }

    // Shuffle the waypoints array randomly
    private void ShuffleWaypoints()
    {
        for (int i = 0; i < waypoints.Length; i++)
        {
            int randomIndex = Random.Range(i, waypoints.Length);
            Transform temp = waypoints[i];
            waypoints[i] = waypoints[randomIndex];
            waypoints[randomIndex] = temp;
        }
    }
}
