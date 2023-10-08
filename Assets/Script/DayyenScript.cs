using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class DayyenScript : MonoBehaviour
{
    public Transform[] waypoints;
    public AudioClip chaseAudioClip;
    public AudioClip jumpscareAudioClip;
    public float roamRadius = 10f;
    public float playerDetectionRadius = 5f;
    public float waypointChangeInterval = 5f;
    public float chaseSpeed = 5f;
    public float roamSpeed = 3.5f;
    public Transform player;

    private NavMeshAgent navMeshAgent;
    private AudioSource audioSource;
    private int currentWaypointIndex = 0;
    private bool isChasing = false;
    private bool playerCaught = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (waypoints.Length > 0)
        {
            SetWaypointDestination(currentWaypointIndex);
            InvokeRepeating("ChangeWaypointDestination", waypointChangeInterval, waypointChangeInterval);
        }
    }

    void Update()
    {
        if (!playerCaught && IsPlayerNearby())
            StartChasing();
        else if (!isChasing)
            StartCoroutine(ResumeRoamingAfterDelay(10f));

        if (audioSource.clip == chaseAudioClip && !audioSource.isPlaying)
            gameObject.SetActive(false);
    }

    bool IsPlayerNearby()
    {
        return Vector3.Distance(transform.position, player.position) < playerDetectionRadius;
    }

    private void StartChasing()
    {
        if (!isChasing)
        {
            isChasing = true;
            navMeshAgent.stoppingDistance = 1f;
            navMeshAgent.speed = chaseSpeed;

            if (!audioSource.isPlaying && chaseAudioClip != null)
            {
                audioSource.clip = chaseAudioClip;
                audioSource.Play();
            }
        }

        navMeshAgent.SetDestination(player.position);
    }

    private void ChangeWaypointDestination()
    {
        if (!isChasing && waypoints.Length > 0)
            SetWaypointDestination(++currentWaypointIndex % waypoints.Length);
    }

    private void SetWaypointDestination(int waypointIndex)
    {
        if (waypoints.Length > 0)
        {
            navMeshAgent.stoppingDistance = 0.1f;
            navMeshAgent.speed = roamSpeed;
            navMeshAgent.SetDestination(waypoints[waypointIndex].position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
            PlayerCaught();
    }

    private void PlayerCaught()
    {
        if (!playerCaught && waypoints.Length > 0)
        {
            int randomWaypointIndex = Random.Range(0, waypoints.Length);
            player.position = waypoints[randomWaypointIndex].position;
        }

        if (jumpscareAudioClip != null)
        {
            audioSource.clip = jumpscareAudioClip;
            audioSource.Play();
        }

        playerCaught = true;
        gameObject.SetActive(false);
    }

    private IEnumerator ResumeRoamingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerCaught = false;
        SetWaypointDestination(++currentWaypointIndex % waypoints.Length);
    }
}
