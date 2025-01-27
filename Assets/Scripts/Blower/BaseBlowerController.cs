using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BaseBlowerController : MonoBehaviour
{
    //private
    Rigidbody2D rb;
    Vector3 reflectDir;

    //serialize
    [SerializeField] protected float rotationSpeed = 200f;
    [SerializeField] protected Transform blowPoint;
    [SerializeField] protected AudioClip blowSound;
    protected Bubble bubbleRef;
    protected AudioSource audioSource;

    [Header("variables for straight raycast")]
    [SerializeField] protected float rayDistance = 10f;
    [SerializeField] protected float blowForce = 50f;
    [SerializeField] protected float reflectForce = 3000f;
    [SerializeField] protected float reflectForceWhileBubble = 1000f;
    [SerializeField] protected float reflectForceAngular = 2000f;

    [Header("variables for angular raycast")]
    [SerializeField] protected float rayAngleOffset = 0.25f;
    [SerializeField] protected float rayAngleForceMultiplier = 25f;
    [SerializeField] protected float rayAngleDistance = 7f;


    [Header("UI")]
    [Range(1f, 10f)][SerializeField] protected float fuelDecreaseRate = 1f;
    [Range(10f, 100f)][SerializeField] protected float maxFuel = 100f;
    [SerializeField] protected int playerID = 1;


    //vfx
    [Header("VFX")]
    [SerializeField] protected ParticleSystem blowVFX;


    [Header("Layers")]
    [SerializeField] protected LayerMask hitLayer;
    [SerializeField] protected LayerMask netLayer;

    #region Unity methods

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        maxFuel = 100f;
        SetupAudio();
    }

    private void SetupAudio()
    {
        audioSource = transform.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = blowSound;
        audioSource.loop = true;
        audioSource.volume = 0.1f;
        audioSource.Stop();
    }

    #endregion


    #region Mechanics


    protected virtual void BlowerRotation(float playerRotation)
    {
        if (playerRotation != 0f)
        {
            Vector3 vector3 = new Vector3(0f, 0f, playerRotation * Time.deltaTime * rotationSpeed);
            Quaternion quaternion = Quaternion.Euler(vector3);
            transform.rotation *= quaternion;
        }
    }

    protected virtual void BlowerONBlowBubble()
    {
        blowVFX.Play();


        if (!audioSource.isPlaying)
        {
            Debug.Log("Playing   :" + gameObject.name);
            audioSource.Play();
        }

        RaycastHit2D hit2 =
            Physics2D.Raycast(blowPoint.position, blowPoint.transform.right +
            (blowPoint.transform.up * rayAngleOffset), rayAngleDistance, hitLayer);
        RaycastHit2D hit3 =
            Physics2D.Raycast(blowPoint.position, blowPoint.transform.right -
            (blowPoint.transform.up * rayAngleOffset), rayAngleDistance, hitLayer);

        //bubble raycasthit 
        if (hit2.collider != null || hit3.collider != null)
        {
            RaycastHit2D actualHitFromAngle = (hit2) ? hit2 : hit3;
            float force;

            RaycastHit2D hit1 = Physics2D.Raycast(blowPoint.position, blowPoint.transform.right, rayDistance, hitLayer);

            if (hit1.collider != null)
            {
                force = blowForce * ((rayDistance - hit1.distance) / rayDistance);

                if (bubbleRef == null && hit1.transform.TryGetComponent<Bubble>(out Bubble bubble))
                {
                    bubbleRef = bubble;
                    bubbleRef.ApplyAirForce(blowPoint.transform.right, force);
                }
                else if (bubbleRef && hit1.transform == bubbleRef.transform)
                {
                    bubbleRef.ApplyAirForce(blowPoint.transform.right, force);
                }

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

        RaycastHit2D netHit = Physics2D.Raycast(blowPoint.position, blowPoint.transform.right, rayDistance, netLayer);

        if (netHit)
        {
            Debug.Log("Net hit");
            BlowerMoveByBlow(netHit, false);
        }

    }

    protected virtual void BlowerMoveByBlow(RaycastHit2D hit, bool isAngular = false)
    {
        reflectDir = -blowPoint.transform.right;

        float force;
        if (hit.collider.tag == "Bubble")
        {
            force = reflectForceWhileBubble * ((rayDistance - hit.distance) / rayDistance);
        }
        else if (hit.transform.gameObject.layer != netLayer)
        {
            force = isAngular ? reflectForceAngular : reflectForce * ((rayDistance - hit.distance) / rayDistance);
        }
        else
        {
            force = reflectForce * ((rayDistance - hit.distance) / rayDistance);
        }


        rb.AddForce(reflectDir * force * Time.fixedDeltaTime, ForceMode2D.Force);
    }


    protected virtual void ActivatePower(BasePowerUp powerUp)
    {

    }

    protected virtual void DeactivatePower(BasePowerUp powerUp)
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
