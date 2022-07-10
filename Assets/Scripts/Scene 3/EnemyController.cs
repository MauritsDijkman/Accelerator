using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float lookRadius = 10f;
    [SerializeField] private float damage = 1f;
    [SerializeField] private float timeStun = 3f;
    [SerializeField] private float rotationSpeed = 3f;

    [Header("Objects")]
    [SerializeField] private Transform target;

    private NavMeshAgent agent;
    private Animator animator;

    private bool stunActive = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (!GameManager_Level3.instance.inputEnabled || stunActive)
            return;

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            animator.SetBool("walk", true);
            agent.SetDestination(target.position);
            agent.angularSpeed = rotationSpeed;

            if (distance <= agent.stoppingDistance)
                FaceTarget();
        }
        else
            animator.SetBool("walk", false);

        Debug.Log("Distance: " + Vector3.Distance(target.transform.position, transform.position));

        if (Vector3.Distance(target.transform.position, transform.position) <= agent.stoppingDistance)
            StartCoroutine(DoDamage(damage, timeStun));
    }

    private IEnumerator DoDamage(float _damage, float _timeStun)
    {
        animator.SetBool("attack", true);
        animator.SetBool("walk", false);
        target.GetComponent<PlayerHealth_Game3>().DoDamage(_damage);
        stunActive = true;

        yield return new WaitForSeconds(_timeStun);
        stunActive = false;
        animator.SetBool("attack", false);
        animator.SetBool("walk", true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
