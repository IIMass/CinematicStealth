using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    [Header("Components")]
    public NavMeshAgent navAgent;         // The agent to move the GameObject
    [SerializeField] private Animator guardAnimator;

    [Header("Animator Parameters")]
    [SerializeField] private string animatorAgentSpeed;
    [SerializeField] private string animatorAlerted;
    [SerializeField] private string animatorCapture;


    [Header("Patrol")]
    [SerializeField] private PatrolMode patrolMode;
    [SerializeField] private float reachDestinationThreshold;
    [SerializeField] private List<PatrolPointInfo> patrolPoints;

    private enum PatrolMode { Cyclical, BackAndForth }
    private bool reachedDestination = false;
    private bool doReverse = false;
    private int currentPatrolPoint = 0;
    private float pauseTimer = 0f;

    [Header("Coin Distraction")]
    public bool distracted;


    // Start is called before the first frame update
    void Start()
    {
        StartPatrol();
    }
    void StartPatrol()
    {
        if (patrolPoints.Count != 0 && patrolPoints[0] != null)
        {
            navAgent.SetDestination(patrolPoints[0].transform.position);
            currentPatrolPoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
        AnimatorUpdate();
    }

    void Patrol()
    {
        if (patrolPoints.Count > 1 && !distracted)
        {
            reachedDestination = Vector3.Distance(transform.position, navAgent.destination) <= reachDestinationThreshold;

            if (reachedDestination)
            {
                if (patrolPoints[currentPatrolPoint].timeToWait > 0 && pauseTimer < patrolPoints[currentPatrolPoint].timeToWait)
                {
                    pauseTimer += Time.deltaTime;
                }
                else
                {
                    switch (patrolMode)
                    {
                        case PatrolMode.Cyclical:
                            currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Count;

                            break;

                        case PatrolMode.BackAndForth:
                            currentPatrolPoint += doReverse ? -1 : 1;

                            if (doReverse)
                            {
                                if (currentPatrolPoint == 0) doReverse = false;
                            }
                            else
                            {
                                if (currentPatrolPoint == patrolPoints.Count - 1) doReverse = true;
                            }

                            break;
                    }

                    navAgent.SetDestination(patrolPoints[currentPatrolPoint].transform.position);
                    pauseTimer = 0f;
                }
            }
        }
    }

    void AnimatorUpdate()
    {
        guardAnimator.SetFloat(animatorAgentSpeed, navAgent.velocity.magnitude);
    }


    private void OnDrawGizmosSelected()
    {
        switch (patrolMode)
        {
            case PatrolMode.Cyclical:
                for (int i = 0; i < patrolPoints.Count; i++)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(patrolPoints[i].transform.position, 0.5f);

                    Gizmos.color = Color.white;
                    Gizmos.DrawLine(patrolPoints[i].transform.position, patrolPoints[(i + 1) % patrolPoints.Count].transform.position);
                }

                break;

            case PatrolMode.BackAndForth:
                for (int i = 0; i < patrolPoints.Count; i++)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(patrolPoints[i].transform.position, 0.5f);

                    if (i < patrolPoints.Count - 1)
                    {
                        Gizmos.color = Color.white;
                        Gizmos.DrawLine(patrolPoints[i].transform.position, patrolPoints[(i + 1)].transform.position);
                    }
                }

                break;
        }
    }
}
