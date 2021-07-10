using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DarrenController : MonoBehaviour
{
    [SerializeField] private Camera controllerCamera;       // The camera currently used to access ScreenPointToRay
    [SerializeField] private NavMeshAgent navAgent;         // The agent to move the GameObject

    [SerializeField] private Animator darrenAnimator;
    [SerializeField] private string animatorControllerSpeed;
    [SerializeField] private string animatorCoinThrow;

    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private LayerMask clickableEntities;
    private bool coinTossed;

    // Update is called once per frame
    void Update()
    {
        // If the player has pressed the left mouse button this frame...
        if (Input.GetMouseButtonDown(0))
        {
            // If the Ray collided with something in the given Mouse Position...
            if (Physics.Raycast(controllerCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                // Set Agent Destination to the Hit Point position
                navAgent.SetDestination(hit.point);
            }
        }

        // If the player has pressed the right mouse button this frame...
        if (Input.GetMouseButtonDown(1) && !coinTossed)
        {
            // If the Ray collided with something in the given Mouse Position...
            if (Physics.Raycast(controllerCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                if (clickableEntities == (clickableEntities | 1 << hit.transform.gameObject.layer)) return;

                darrenAnimator.SetTrigger(animatorCoinThrow);

                // Coin toss
                Instantiate(coinPrefab, hit.point, Quaternion.identity);
                SendAIToCoin(hit.point);

                coinTossed = true;
            }
        }

        darrenAnimator.SetFloat(animatorControllerSpeed, navAgent.velocity.magnitude);
    }


    private void SendAIToCoin(Vector3 coinPos)
    {
        GuardAI[] guards = FindObjectsOfType<GuardAI>();

        foreach (GuardAI guard in guards)
        {
            guard.distracted = true;
            guard.navAgent.SetDestination(coinPos);
        }
    }

    public void SoftWalk()
    {

    }
}