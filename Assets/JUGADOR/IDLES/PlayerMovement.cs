using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float scaleChangeSpeed = 2f;
    private bool isCollidingWithObject = false;
    private bool hasClickedOnObject = false;

    public float minYScale = 3.0f;
    public float maxYScale = 7.0f;

    public float minYScaleChange = 1.0f;
    public float maxYScaleChange = -1.0f;

    private Animator playerAnimator;
    private Vector3 targetPosition;

    public bool MirarArriba { get; private set; }
    public bool MirarAbajo { get; private set; }
    public bool MirarIzquierda { get; private set; }
    public bool MirarDerecha { get; private set; }

    public bool isMoving;
    public bool canMove = true;

    private float targetScale = 6.0f;
    private float currentScale = 6.0f;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        targetPosition = transform.position;
        ResetDirectionBools();
        isMoving = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canMove)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Colliders"))
                {
                    return;
                }
            }

            if (isMoving)
            {
                if (hasClickedOnObject)
                {
                    hasClickedOnObject = false;
                    return;
                }
            }

            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;
            targetPosition.y -= -1f;
            isMoving = true;
            ResetDirectionBools();
        }

        if (isMoving)
        {
            if (isCollidingWithObject)
            {
                if (hasClickedOnObject)
                {
                    hasClickedOnObject = false;
                }
                else
                {
                    isMoving = false;
                    hasClickedOnObject = true;
                    return;
                }
            }

            Vector3 movement = (targetPosition - transform.position).normalized;

            if (!canMove)
            {
                movement = Vector3.zero;
                // directionToTarget = Vector3.zero;
                canMove = true;
            }

            // Vector3 movement = new Vector3(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed * 0.25f, 0);

            float moveY = movement.y;
            float scaleChange = moveY > 0 ? maxYScaleChange : minYScaleChange;
            targetScale = 6.0f + scaleChange * Mathf.Abs(moveY) * scaleChangeSpeed;
            targetScale = Mathf.Clamp(targetScale, minYScale, maxYScale);

            if (Mathf.Abs(moveY) < 0.1f)
            {
                targetScale = currentScale;
            }

            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

            if (distanceToTarget < 0.1f)
            {
                isMoving = false;
                SetDirectionBools();
            }
            else
            {
                if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
                {
                    if (movement.x > 0)
                    {
                        MirarDerecha = true;
                    }
                    else
                    {
                        MirarIzquierda = true;
                    }
                }
                else
                {
                    if (movement.y > 0)
                    {
                        MirarArriba = true;
                    }
                    else
                    {
                        MirarAbajo = true;
                    }
                }

                Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
                playerAnimator.SetBool("MirarArriba", MirarArriba);
                playerAnimator.SetBool("MirarAbajo", MirarAbajo);
                playerAnimator.SetBool("MirarIzquierda", MirarIzquierda);
                playerAnimator.SetBool("MirarDerecha", MirarDerecha);
                playerAnimator.SetBool("isWalking", true);
                transform.Translate(movement * moveSpeed * Time.deltaTime);
                currentScale = Mathf.Lerp(currentScale, targetScale, scaleChangeSpeed * Time.deltaTime);
                Vector3 newScale = new Vector3(currentScale, currentScale, 1f);
                transform.localScale = newScale;
            }
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }
    }

    private void ResetDirectionBools()
    {
        MirarArriba = false;
        MirarAbajo = false;
        MirarIzquierda = false;
        MirarDerecha = false;
    }

    private void SetDirectionBools()
    {
        playerAnimator.SetBool("MirarArriba", MirarArriba);
        playerAnimator.SetBool("MirarAbajo", MirarAbajo);
        playerAnimator.SetBool("MirarIzquierda", MirarIzquierda);
        playerAnimator.SetBool("MirarDerecha", MirarDerecha);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Objeto"))
        {
            Debug.Log("Colisión detectada con objeto");
            isCollidingWithObject = true;
            ReactivateMovementAfterDelay();
            // canMove = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Objeto"))
        {
            Debug.Log("Salida de colisión con objeto");
            isMoving = true;
            isCollidingWithObject = false;
            if (!hasClickedOnObject)
            {
                canMove = true;
                isMoving = true;
            }
        }
    }

    private IEnumerator ReactivateMovementAfterDelay()
    {
        yield return new WaitForSeconds(0f);
        canMove = true;
    }

}
