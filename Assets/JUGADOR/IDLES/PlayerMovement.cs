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

    public Animator playerAnimator;
    private Vector3 targetPosition;
    private Vector3 playerOriginalPosition;

    public bool MirarArriba { get; private set; }
    public bool MirarAbajo { get; private set; }
    public bool MirarIzquierda { get; private set; }
    public bool MirarDerecha { get; private set; }
    public bool isPunching;
    public bool isDead;
    public bool DeadPause;

    public bool isSigilo;
    private bool esperando = false;
    public float idleTime = 0.0f;

    public bool isMoving;
    public bool canMove = true;
    public Controlador controlador;

    private float targetScale = 5.0f;
    private float currentScale = 5.0f;


    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        targetPosition = transform.position;
        ResetDirectionBools();
        isMoving = false;
    }

    private void Update()
    {

    if (Input.GetKeyDown(KeyCode.I))
    {
        FindObjectOfType<InventarioCanvasScript>().MostrarInventario();
    }


        if(DeadPause == true && Input.GetMouseButtonDown(0)){
            playerAnimator.speed = 1;
            Debug.Log("NASHE");
            StartCoroutine(ResetDeadAnimation(0.617f));
            playerAnimator.SetBool("MirarIzquierda", false);
            playerAnimator.SetBool("MirarDerecha", false);
            playerAnimator.SetBool("MirarArriba", false);
            playerAnimator.SetBool("MirarAbajo", true);
            
        }

        if (Input.GetMouseButtonDown(0) && canMove)
        {

            playerAnimator.SetBool("isWalking", true);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            

            // if (Physics.Raycast(ray, out hit))
            // {
            //     if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Colliders"))
            //     {
            //         return;
            //     }
            // }

            if (isMoving)
            {
                if (hasClickedOnObject)
                {
                    hasClickedOnObject = false;

                }
            }
            else if (!isMoving)
            {

            }


            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;
            targetPosition.y -= -1.3f;
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
                    isMoving = true;
                    hasClickedOnObject = true;
                    return;
                }
            }

            Vector3 movement = (targetPosition - transform.position).normalized;

            if (!canMove)
            {
                movement = Vector3.zero;
            }

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
                

                if(isPunching == true){
                Debug.Log("Punching");
                Debug.Log("Metiendo el golpe");
                playerAnimator.SetBool("isPunching", true);
                StartCoroutine(ResetPunchingAnimation(1.4f));
                }

                if(isDead == true){
                Debug.Log("Haciendose el muerto");
                playerAnimator.SetBool("isDead", true);
                StartCoroutine(PauseDeadAnimation(1.6f));


                // 
                }
            }
            else
            {
                // SetDirectionBools();
                // Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
                // playerAnimator.SetBool("isWalking", true);
                // transform.Translate(movement * moveSpeed * Time.deltaTime);
                // currentScale = Mathf.Lerp(currentScale, targetScale, scaleChangeSpeed * Time.deltaTime);
                // Vector3 newScale = new Vector3(currentScale, currentScale, 1f);
                // transform.localScale = newScale;

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
                // playerAnimator.SetBool("isWalking", true);
                
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
        

        if (isMoving == true)
            {
                idleTime = 0.0f; // Reset idle time
                esperando = false; // Reset esperando
                playerAnimator.SetBool("isIdle", false);
            }
            else if (isMoving == false)
            {
                idleTime += Time.deltaTime; // Increase idle time
                if (idleTime >= 6.0f && !esperando)
                {
                    esperando = true;
                    playerAnimator.SetBool("isIdle", true);
                    // Activate the 'Esperando' boolean here
                    // You can replace the Debug.Log with setting your boolean as needed.
                    Debug.Log("Player is waiting for 6 seconds.");
                    // Set your boolean 'Esperando' to true here
                }
            }

        if(isSigilo == true){
            playerAnimator.SetBool("isSigilo", true);
            moveSpeed = 2.0f; 
            scaleChangeSpeed = 1.75f;

        }else{
            moveSpeed = 4.0f; 
            scaleChangeSpeed = 3.5f;            
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
            if (!isCollidingWithObject) 
            {
                // targetPosition = transform.position;
                Debug.Log("Colisión detectada con objeto");
                isCollidingWithObject = true;
                // playerOriginalPosition = transform.position;
                // canMove = true;
                StartCoroutine(ReactivateMovementAfterDelay());
            }
        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Objeto"))
        {
            Debug.Log("Salida de colisión con objeto");
            isCollidingWithObject = false;
        }
    }

    private IEnumerator ReactivateMovementAfterDelay()
    {
        yield return new WaitForSeconds(0.2f); 
        canMove = true;
    }



    public void MoveTowardsPosition(Vector3 targetPosition)
    {

        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);

    }


    public IEnumerator ResetPunchingAnimation(float tiempoEspera = 1.3f)
    {  
            yield return new WaitForSeconds(tiempoEspera);
            playerAnimator.SetBool("isPunching", false);
            isPunching = false;           

    }

    public IEnumerator ResetDeadAnimation(float tiempoEspera = 0.617f)
    {  
            playerAnimator.speed = 1f;
            ResetDirectionBools();
            yield return new WaitForSeconds(tiempoEspera);
            playerAnimator.SetBool("isDead", false);
            canMove = true;
            isDead = false;         
            DeadPause = false;  

    }
    public IEnumerator PauseDeadAnimation(float tiempoEspera = 1.7f)
    {  
            yield return new WaitForSeconds(tiempoEspera);
            // playerAnimator.SetBool("isDead", false);
            // isDead = false;  
            playerAnimator.speed = 0f;
            isMoving = false;
            canMove = false;
            isDead = true; 
            DeadPause = true;


    }
}
