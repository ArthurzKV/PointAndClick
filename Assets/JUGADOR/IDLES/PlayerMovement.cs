using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del jugador.
    public float rotationSpeed = 10f; // Velocidad de rotación del jugador.
    public float scaleChangeSpeed = 2f; // Velocidad de cambio de escala.
    
    public float minYScale = 3.0f; // Escala mínima en el eje Y.
    public float maxYScale = 7.0f; // Escala máxima en el eje Y.

    public float minYScaleChange = 1.0f; // Valor mínimo de cambio de escala en el eje Y.
    public float maxYScaleChange = -1.0f;  // Valor máximo de cambio de escala en el eje Y.

    private Animator playerAnimator; // Animator del jugador.

    private Vector3 targetPosition; // Posición del destino.

    // Public bools para la dirección del jugador.
    public bool MirarArriba { get; private set; }
    public bool MirarAbajo { get; private set; }
    public bool MirarIzquierda { get; private set; }
    public bool MirarDerecha { get; private set; }

    public bool isMoving; // Variable de estado para controlar si el jugador está en movimiento.
    private bool canMove = true; // Agrega esta variable para habilitar/deshabilitar el movimiento del jugador.

    private float targetScale = 6.0f; // Escala de destino.
    private float currentScale = 6.0f; // Escala actual.

    private void Start()
    {
        playerAnimator = GetComponent<Animator>(); // Obtener el componente Animator del jugador.
        targetPosition = transform.position; // Inicialmente, el destino es la posición actual del jugador.
        ResetDirectionBools(); // Restablecer los bools de dirección.
        isMoving = false;
    }

    private void Update()
    {
        // Si se hace clic con el botón izquierdo del ratón.
        if (Input.GetMouseButtonDown(0) && canMove)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Colliders"))
                {
                    // El jugador hizo clic en un objeto en la capa "Colliders", no se permite el movimiento.
                    return;
                }
            }

            // Obtener la posición del clic en el mundo con un pequeño offset hacia abajo en Y.
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0; // Asegurarse de que el valor Z sea 0 para el plano 2D.
            targetPosition.y -= -1f; // Offset en el eje Y para que los pies lleguen al destino.
            isMoving = true; // El jugador está en movimiento.
            ResetDirectionBools(); // Restablecer los bools de dirección al principio del movimiento.
        }

        if (isMoving)
        {
            // Calcular la dirección del movimiento hacia el destino.
            Vector3 movement = (targetPosition - transform.position).normalized;

            // Calcular el componente en el eje Y del movimiento.
            float moveY = movement.y;

            // Calcular el cambio de escala basado en el movimiento en el eje Y.
            float scaleChange = moveY > 0 ? maxYScaleChange : minYScaleChange;
            targetScale = 6.0f + scaleChange * Mathf.Abs(moveY) * scaleChangeSpeed;
            targetScale = Mathf.Clamp(targetScale, minYScale, maxYScale);

            // Si el movimiento es principalmente horizontal, establece el escalado a la escala actual.
            if (Mathf.Abs(moveY) < 0.1f)
            {
                targetScale = currentScale -0.03f;
            }

            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;

            // Calcular la distancia al destino.
            float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

            if (distanceToTarget < 0.1f)
            {
                // El jugador ha llegado al destino.
                isMoving = false;
                SetDirectionBools();
            }
            else
            {
                // float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;

                if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
                {
                    // Movimiento predominante en el eje X.
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
                    // Movimiento predominante en el eje Y.
                    if (movement.y > 0)
                    {
                        MirarArriba = true;
                    }
                    else
                    {
                        MirarAbajo = true;
                    }
                }



                // Calcular la rotación deseada en función de la dirección del movimiento.
                Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

                // Configurar la animación del jugador para caminar.
                playerAnimator.SetBool("MirarArriba", MirarArriba);
                playerAnimator.SetBool("MirarAbajo", MirarAbajo);
                playerAnimator.SetBool("MirarIzquierda", MirarIzquierda);
                playerAnimator.SetBool("MirarDerecha", MirarDerecha);
                playerAnimator.SetBool("isWalking", true);

                // Mover el jugador hacia el destino con la velocidad de movimiento.
                transform.Translate(movement * moveSpeed * Time.deltaTime);

                // Cambiar la escala gradualmente.
                currentScale = Mathf.Lerp(currentScale, targetScale, scaleChangeSpeed * Time.deltaTime);
                Vector3 newScale = new Vector3(currentScale, currentScale, 1f);
                transform.localScale = newScale;
            }
        }
        else
        {
            // Si el jugador no se está moviendo, configurar la animación de Idle y desactivar isWalking.
            playerAnimator.SetBool("isWalking", false);
        }
    }

    private void ResetDirectionBools()
    {
        // Restablecer los bools de dirección.
        MirarArriba = false;
        MirarAbajo = false;
        MirarIzquierda = false;
        MirarDerecha = false;
    }

    private void SetDirectionBools()
    {
        // Establecer los bools de dirección en el Animator.
        playerAnimator.SetBool("MirarArriba", MirarArriba);
        playerAnimator.SetBool("MirarAbajo", MirarAbajo);
        playerAnimator.SetBool("MirarIzquierda", MirarIzquierda);
        playerAnimator.SetBool("MirarDerecha", MirarDerecha);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisión detectada");
        // Colisión detectada, desactiva el movimiento del jugador.
        canMove = false;
        isMoving = false;
        StartCoroutine(ReactivateMovementAfterDelay());
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Salida de colisión");
        // El jugador no está en colisión, permite el movimiento nuevamente.
        canMove = true;
    }

    private IEnumerator ReactivateMovementAfterDelay()
    {
        yield return new WaitForSeconds(0.3f); // Espera 1 segundo.
        canMove = true; // Restablece la capacidad de movimiento.
    }

}
