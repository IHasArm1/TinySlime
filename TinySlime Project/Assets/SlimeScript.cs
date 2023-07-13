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

    private bool canMove = true;

    private void Update()
    {

        if(!timerIsActive && canMove)
        {
            StartCoroutine(JumpTimer());
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
            transform.position = Vector2.Lerp(initialPosition, targetPosition, normalizedTime);

            yield return null;
        }

        // Ensure the object reaches the exact target position
        transform.position = targetPosition;

        isJumping = false;
        anim.SetBool("isIdle", true);
        timerIsActive = false;
    }


}
