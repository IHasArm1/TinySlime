using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    public float distance = 5f;
    public float moveDuration = 2f;

    [SerializeField] private Animator anim;

    private Vector2 targetPosition;
    private bool isJumping = false;

    private bool timerIsActive = false;

    [HideInInspector]
    public bool canMove = true;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        transform.rotation = new(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);

        if(!timerIsActive && canMove)
        {
            StartCoroutine(JumpTimer());
        }

        if(!canMove)
        {
            StopAllCoroutines();
            timerIsActive = false;
            isJumping = false;
            anim.SetBool("isIdle", true);
        }

    }

    public void PoopSlime()
    {

    }

    private IEnumerator JumpTimer()
    {
        timerIsActive = true;

        float randomTime = Random.Range(1.5f, 5.5f);

        yield return new WaitForSeconds(randomTime);

        yield return StartCoroutine(StartJumping());
    }

    private IEnumerator StartJumping()
    {
        anim.SetTrigger("jump");
        anim.SetBool("isIdle", false);
        isJumping = true;

        yield return new WaitForSeconds(0.50f);

        StartCoroutine(SlimeJump());
    }

    private IEnumerator SlimeJump()
    {
        // Generate random direction
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        // Calculate target position based on the distance
        targetPosition = (Vector2)transform.position + (randomDirection * distance);

        // Store the initial position and the start time
        Vector2 initialPosition = transform.position;
        float startTime = Time.time;

        // Move towards the target position over the specified duration using lerp
        while (Time.time - startTime < moveDuration)
        {
            float normalizedTime = (Time.time - startTime) / moveDuration;
            Vector2 newPosition = Vector2.Lerp(initialPosition, targetPosition, normalizedTime);

            // Check for collisions before updating the position
            if (!IsColliding(newPosition))
            {
                rb.MovePosition(newPosition);
            }

            yield return null;
        }

        // Ensure the object reaches the exact target position
        rb.MovePosition(targetPosition);

        isJumping = false;
        anim.SetBool("isIdle", true);
        timerIsActive = false;
    }

    private bool IsColliding(Vector2 newPosition)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, 1.2f); // Adjust the 0.2f radius as needed

        foreach (Collider2D collider in colliders)
        {
            if (collider != null && collider != GetComponent<Collider2D>() && collider.isTrigger == false)
            {
                // Check for any 2D collider in the way, except the slime itself and any triggers
                return true;
            }
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position - new Vector3(0, 0.2f), 1.2f);
    }

}
