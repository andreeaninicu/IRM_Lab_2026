using UnityEngine;
using Vuforia;

public class CactusProximity : MonoBehaviour
{
    [SerializeField] private ObserverBehaviour myTarget;
    [SerializeField] private ObserverBehaviour otherTarget;
    [SerializeField] private Animator animator;
    [SerializeField] private float attackDistance = 0.25f;
    [SerializeField] private bool showDistance = true;

    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");

    // Both cacti carry this script, but only one of them draws the overlay.
    private static CactusProximity overlayOwner;

    private float distance;
    private bool bothTracked;
    private bool attacking;

    private void OnEnable()
    {
        if (overlayOwner == null) overlayOwner = this;
    }

    private void OnDisable()
    {
        if (overlayOwner == this) overlayOwner = null;
    }

    private void Update()
    {
        bothTracked = IsTracked(myTarget) && IsTracked(otherTarget);

        if (bothTracked)
        {
            distance = Vector3.Distance(
                myTarget.transform.position,
                otherTarget.transform.position);
        }

        attacking = bothTracked && distance <= attackDistance;
        animator.SetBool(IsAttacking, attacking);
    }

    private void OnGUI()
    {
        if (!showDistance || overlayOwner != this) return;

        string text = bothTracked
            ? $"Distance: {distance * 100f:F1} cm (threshold {attackDistance * 100f:F0} cm)\nState: {(attacking ? "ATTACK" : "IDLE")}"
            : "Distance: -\nBoth cards must be visible";

        var style = new GUIStyle(GUI.skin.label) { fontSize = 28, fontStyle = FontStyle.Bold };
        style.normal.textColor = attacking ? Color.red : Color.white;
        GUI.Label(new Rect(20, 20, 900, 120), text, style);
    }

    private static bool IsTracked(ObserverBehaviour target)
    {
        if (target == null) return false;
        var status = target.TargetStatus.Status;
        return status == Status.TRACKED || status == Status.EXTENDED_TRACKED;
    }
}
