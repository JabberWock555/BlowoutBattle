using UnityEngine;

public class BaseBlowerController : MonoBehaviour
{
    //private
    Rigidbody2D rb;
    BaseBlowerInputs playerInputs;
    RaycastHit2D hit;
    Vector3 reflectDir;



    //serialize
    [SerializeField] protected float rotationSpeed = 5f;
    [SerializeField] protected Transform blowPoint;
    [SerializeField] protected float rayDistance = 1f;
    [SerializeField] protected LayerMask bubbleLayer;
    [SerializeField] protected float blowForce = 1f;
    [SerializeField] protected float reflectForce = 1f;

    #region Unity methods

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInputs = GetComponent<BaseBlowerInputs>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        BlowerRotation();
    }


    private void FixedUpdate()
    {

        BlowerONBlowBubble();
        BlowerMoveByBlow();
    }

    #endregion


    #region Mechanics


    protected virtual void BlowerRotation()
    {
        if (playerInputs.rotationInput != 0f)
        {
            Vector3 vector3 = new Vector3(0f, 0f, playerInputs.rotationInput * Time.deltaTime * rotationSpeed);
            Quaternion quaternion = Quaternion.Euler(vector3);
            transform.rotation *= quaternion;
        }
    }

    protected virtual void BlowerONBlowBubble()
    {
        if (playerInputs.isBlowerON)
        {

            hit = Physics2D.Raycast(blowPoint.position, blowPoint.transform.right, rayDistance, bubbleLayer);

            if (hit)
            {
                float force = blowForce * ((rayDistance - hit.distance) / rayDistance);



                if (hit.transform.TryGetComponent<Bubble>(out Bubble rb))
                    rb.ApplyAirForce(blowPoint.transform.right, force);

            }

        }
    }

    protected virtual void BlowerMoveByBlow()
    {


        reflectDir = -blowPoint.transform.right;

        if (playerInputs.isBlowerON)
        {
            if (hit)
            {
                Debug.Log("Floor hit");
                float force = reflectForce * ((rayDistance - hit.distance) / rayDistance);
                rb.AddForce(reflectDir * force * Time.fixedDeltaTime, ForceMode2D.Force);
            }
        }

    }


    protected virtual void UsePowerUps()
    {

    }


    #endregion


    #region Draw

    void OnDrawGizmos()
    {
        if (blowPoint)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(blowPoint.position, transform.right * rayDistance);
        }

        if (rb)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(blowPoint.position, rb.linearVelocity);
        }

    }
    #endregion
}
