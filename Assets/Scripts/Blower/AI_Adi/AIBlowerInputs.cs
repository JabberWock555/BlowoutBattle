using System;
using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class AIBlowerInputs : BaseBlowerInputs
{
    private Transform bubble;
    private float decisionTimer = 0f;
    private float decisionInterval = 1f; // Time in seconds between AI decisions
    private float rotationSpeed = 5f;

    private Vector2 directionToBubble;

    [SerializeField] private BoxCollider2D net;
    private Vector3 netTopRightPt;
    
    // Autopilot
    private Action executePilotStage;
    private PilotStage currentPilotStage = PilotStage.TakePosition;
    private enum PilotStage
    {
        SetTargetPosition,
        TakePosition,
        BlowBubble,
        RechargeFuel
    }
    private bool isBubbleBlown = false; // Make sure bubble is blown atleast once before changing stage
    
    // take position in relation to net, recharge fuel, if fuel full be aggressive,
    // recharge according to bubbles posn in relatn to net. if in front of and below net (enemy side)
    // then recharge. if too much in front of net, recharge
    // take posn a decent bit behind bubble so itll still work even w the bubble's momentum
    // if too high up from ground then wait before taking position (determine max effective height)
    // set action stage (taking position, blowing)
    // Headbutting can be achieved. First see relative positions of bubble, blower, ground, net, etc,
    // then ram bubble if applicable
    
    // Control flow by using coroutines to enter and exit flight stages based on time or trigger conditions
    // ex stage: defense. if(above bubble), start a coroutine that will set variable target position
    // that'll start from beside you and end under the bubble (otherwise blower will collide with bubble instead 
    // of going around it) and when location is under bubble coroutine terminates after setting appropriate flight stage 
    // Similarly, if bubble much ahead of net, start coroutine to set savefuel stage which runs until bubble is close again
    // if player is above bubble then player at risk so savefuel again (programming agressive state will take too long)
    
    // Basic flow / loop: take position such that line drawn from you and bubble goes above net, rotate, blow.
    // To determine this position you can simply choose to return the bubble to the trajectory from where it arrived
    // Also can start coroutines based on criteria. eg, after taking position, stay in blow mode as long as 
    // blow trajectory takes blower over net, otherwise reposition
    
    // If saving fuel and bubble is behind attack boundary and fuel is full, sit atop net and 
    // keep blowing as long as fuel is above certain limit. Maybe dont do this already lost some points (play defence)
    
    // Advanced: determine whether to blow or ram based on which activity's signed angle is smaller
    
    protected override void Awake()
    {
        netTopRightPt = net.bounds.max;
    }

    private void Update()
    {
        if (bubble == null)
        {
            // Try to find the bubble again if it was not found at the start or was destroyed
            bubble = FindAnyObjectByType<Bubble>()?.transform;
            return;
        }

        directionToBubble = bubble.position - transform.position;
        //PointToPosition(bubble.position);
        HandleAutopilot();
        
        // Simple AI decision making on an interval
        decisionTimer += Time.deltaTime;
        if (decisionTimer >= decisionInterval)
        {
            decisionTimer = 0f;
            MakeDecision();
        }
    }

    private void HandleAutopilot()
    {
        switch (currentPilotStage)
        {
            /*case PilotStage.SetTargetPosition:
                Vector3 targetPos = CalculateTargetPosition();
                executePilotStage = () => TakePosition(targetPos, 0.5f);
                currentPilotStage = PilotStage.TakePosition;
                break;*/
            
            case PilotStage.TakePosition:
                MoveAndBlow();
                break;
            
            case PilotStage.BlowBubble:
                BlowBubble();
                break;
            case PilotStage.RechargeFuel:
                FuelRechargeStage();
                break;
        }
    }

    private Vector3 CalculateTargetPosition()
    {
        float timeInSeconds = 0.2f;
        Rigidbody2D bubbleRb = bubble.GetComponent<Rigidbody2D>();
        
        Vector3 futurePosition = 
            bubbleRb.position + (bubbleRb.linearVelocity * timeInSeconds);
        Debug.DrawRay(futurePosition, Vector3.up, Color.cyan);

        Vector3 targetPosition = futurePosition + Vector3.right;
        
        Vector3 blowDirection = bubble.position - targetPosition;
        Debug.Log(Vector2.SignedAngle(blowDirection, Vector3.left));
        if (Vector2.SignedAngle(blowDirection, Vector3.left) <= 5f)
        {
            // Blow direction is below instead of upwards
            targetPosition += Vector3.down;
        }
        Debug.DrawRay(targetPosition, Vector3.up, Color.green);
        
        return targetPosition;
    }

    private void MakeDecision()
    {

        
        // 2. Blowing Logic
        // A simple logic: blow if the bubble is in front of the blower
        float angleDifference = Vector3.Angle(transform.right, directionToBubble);
        if (angleDifference < 10f) // Blow if the bubble is within a 10-degree cone
        {
            isBlowerONInput = true;
        }
        else
        {
            isBlowerONInput = false;
        }
    }

    private void PointToPosition(Vector3 spotToPoint)
    {
        Vector3 directionToPoint = spotToPoint - transform.position;
        PointToDirection(directionToPoint);
    }

    private bool PointToDirection(Vector3 directionToPoint)
    {
        float angleToPoint = Vector2.SignedAngle(transform.right, directionToPoint); 
       if (Mathf.Abs(angleToPoint) >= 5f)
        {
            rotationInput = -Mathf.Sign(angleToPoint);
            return false;
        }
        else
        {
            rotationInput = 0;
            return true;
        }
    }

    /// <summary> Command blower to move to a position </summary>
    /// <param name="position">Target position</param> <param name="distanceThreshold">Distance to stop away from position</param>
    /// <returns>Returns true if target position reached</returns>
    private bool TakePosition(Vector3 position, float distanceThreshold)
    {
        Vector3 positionDir = position - transform.position;
        Vector3 directionToBlow = -positionDir;
        bool isPointingInDir = PointToDirection(directionToBlow);
        
        // Dont blow if close to position
        float distance = Vector3.Distance(transform.position, position);
        if (distance <= distanceThreshold)
        {
            return true;
        }
        
        // Only blow when pointing in correct direction
        if (isPointingInDir)
        {
            isBlowerONInput = true;
        }
        else
        {
            isBlowerONInput = false;
        }

        return false;
    }

    private void MoveAndBlow()
    {
        if (TakePosition(CalculateTargetPosition(), 0.5f))
        {
            // Reached position, rotate and blow bubble
            currentPilotStage = PilotStage.BlowBubble;
            isBubbleBlown = false;
        }
    }

    private void RepositionAndChangeState(Vector3 position, PilotStage stateToSet)
    {
        
    }

    // enum here, which we can feed into blowbubble which will change behaviour completely w each enum
    private Action bubbleBlowDelegate;
    private void BlowBubble(float blowTriggerDist, )
    {
        PointToPosition(bubble.position);
        if (Vector3.Distance(transform.position, bubble.position) < 2f)
        {
            isBlowerONInput = true;
            isBubbleBlown = true;
        }

        if (Vector3.Distance(transform.position, bubble.position) > 4F && isBubbleBlown)
        {
            currentPilotStage = PilotStage.RechargeFuel;
        }
    }

    private void FuelRechargeStage()
    {
        if (GetComponent<PlayerController>().totalCharging >= 1f)
        {
            // set position to atop net 
            // enter blow bubble state
        }
    }
    
    
    
    
    
}
