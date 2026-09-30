using UnityEngine;
using Vuforia;

public class CactusProximity : MonoBehaviour
{
    [SerializeField] private ObserverBehaviour myTarget;
    [SerializeField] private ObserverBehaviour otherTarget;
    [SerializeField] private Animator animator;
    [SerializeField] private float attackDistance = 0.25f;

    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");

    private void Update()
    {
        if (!IsTracked(myTarget) || !IsTracked(otherTarget))
        {
            animator.SetBool(IsAttacking, false);
            return;
        }

        float distance = Vector3.Distance(
            myTarget.transform.position,
            otherTarget.transform.position);

        animator.SetBool(IsAttacking, distance <= attackDistance);
    }

    private static bool IsTracked(ObserverBehaviour target)
    {
        if (target == null) return false;
        var status = target.TargetStatus.Status;
        return status == Status.TRACKED || status == Status.EXTENDED_TRACKED;
    }
}