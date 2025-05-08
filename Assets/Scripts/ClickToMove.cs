using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    public Camera mainCamera;
    private Animator animator;
    private NavMeshAgent agent;
    private static readonly string SPEED_PARAMETER = "Blend";
    private float velocitySmoothing = 0.1f; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                NavMeshHit navHit;
                if (NavMesh.SamplePosition(hit.point, out navHit, 1.0f, NavMesh.AllAreas))
                {
                    agent.SetDestination(navHit.position);
                }
            }
        }

        
        float currentSpeed = agent.velocity.magnitude;
        float smoothedSpeed = Mathf.Lerp(animator.GetFloat(SPEED_PARAMETER), currentSpeed, velocitySmoothing);
        animator.SetFloat(SPEED_PARAMETER, smoothedSpeed);
    }
}
