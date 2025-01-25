using Unity.VisualScripting;
using UnityEngine;

public class BaseBlowerController : MonoBehaviour
{
    //private
    Rigidbody2D rb;
    BaseBlowerInputs playerInputs;

    Vector3 reflectDir;

    //serialize
    [SerializeField] protected float rotationSpeed = 200f;
    [SerializeField] protected Transform blowPoint;
    [SerializeField] protected float rayDistance = 10f;
    [SerializeField] protected LayerMask hitLayer;
    [SerializeField] protected float blowForce = 50f;
    [SerializeField] protected float reflectForce = 3000f;
    [SerializeField] protected float reflectForceAngular = 2000f;
    [SerializeField] protected float rayAngleOffset = 0.25f;
    [SerializeField] protected float rayAngleForceMultiplier = 25f;
    [SerializeField] protected float rayAngleDistance = 7f;

    //vfx
    [SerializeField] ParticleSystem blowVFX;


    #region Unity methods

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInputs = GetComponent<BaseBlowerInputs>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        BlowerRotation();
    }


    protected virtual void FixedUpdate()
    {
        BlowerONBlowBubble();
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
            blowVFX.Play();

            RaycastHit2D hit2 =
                Physics2D.Raycast(blowPoint.position, blowPoint.transform.right +
                (blowPoint.transform.up * rayAngleOffset), rayAngleDistance, hitLayer);
            RaycastHit2D hit3 =
                Physics2D.Raycast(blowPoint.position, blowPoint.transform.right -
                (blowPoint.transform.up * rayAngleOffset), rayAngleDistance, hitLayer);

            if (hit2.collider != null || hit3.collider != null)
            {
                RaycastHit2D actualHitFromAngle = (hit2) ? hit2 : hit3;
                float force;

                RaycastHit2D hit1 = Physics2D.Raycast(blowPoint.position, blowPoint.transform.right, rayDistance, hitLayer);

                if (hit1.collider != null)
                {
                    force = blowForce * ((rayDistance - hit1.distance) / rayDistance);

                    if (hit1.transform.TryGetComponent<Bubble>(out Bubble bubble))
                        bubble.ApplyAirForce(blowPoint.transform.right, force);

                    BlowerMoveByBlow(hit1, false);

                }
                else
                {
                    force = rayAngleForceMultiplier * ((rayDistance - hit1.distance) / rayDistance);
                    if (actualHitFromAngle.transform.TryGetComponent<Bubble>(out Bubble bubble))
                        bubble.ApplyAirForce(blowPoint.transform.right, force);

                    BlowerMoveByBlow(actualHitFromAngle, true);

                }

            }

        }
        else
        {
            if (blowVFX.isPlaying)
                blowVFX.Stop();
        }
    }

    protected virtual void BlowerMoveByBlow(RaycastHit2D hit, bool isAngular = false)
    {
        reflectDir = -blowPoint.transform.right;

        float force = isAngular ? reflectForceAngular : reflectForce * ((rayDistance - hit.distance) / rayDistance);
        rb.AddForce(reflectDir * force * Time.fixedDeltaTime, ForceMode2D.Force);
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
            Gizmos.DrawRay(blowPoint.position, (blowPoint.transform.right + (blowPoint.transform.up * rayAngleOffset)) * rayAngleDistance);
            Gizmos.DrawRay(blowPoint.position, (blowPoint.transform.right - (blowPoint.transform.up * rayAngleOffset)) * rayAngleDistance);
        }

        if (rb)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(blowPoint.position, rb.linearVelocity);
        }

    }
    #endregion
}
