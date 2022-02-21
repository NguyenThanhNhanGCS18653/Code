using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private float motorForce;
    public float MyMotorForce 
    {
        get
        {
            return motorForce;
        }
        set
        {
            motorForce = value;
        }
    }

    [SerializeField]
    private float breakForce;

    [SerializeField]
    private float maxSteerAngle;

    [SerializeField]
    private GameObject smokeEffect;
    [SerializeField]
    private GameObject startEffect;

   
    private float timeStart = 3f;
    [SerializeField]
    private Text timeStartTxt;

    private float zInput;
    private float yInput;
    private float currentSteerAngle;
    private bool isBreaking;
    private float currentBreakForce;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTrasnform;
    [SerializeField] private Transform rearRightWheelTrasnform;


    [SerializeField]
    private Sounds sound;
    private void Start()
    {
        smokeEffect.SetActive(false);
        startEffect.SetActive(false);
    }

    private void Update()
    {
        
        if (Mathf.Abs(zInput) > 0.1f)
        {
            sound.PlaySound("engine");
            smokeEffect.SetActive(true);
            startEffect.SetActive(true);
        }
        else
        {
            smokeEffect.SetActive(false);
            startEffect.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        //timeStart -= 1 * Time.fixedDeltaTime;
        //timeStartTxt.text = timeStart.ToString("0");
        StartCoroutine(CountDown());
        if (timeStart <= 0)
        {
            GetInput();
            HandleMotor();
            HandleSteering();
            UpdateWheel();
            timeStartTxt.gameObject.SetActive(false);
        }
    }
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(.5f);
        timeStart -= 1 * Time.fixedDeltaTime;
        timeStartTxt.text = timeStart.ToString("0");
    }
    void GetInput()
    {
        zInput = Input.GetAxis("Vertical");

        yInput = Input.GetAxis("Horizontal");

        isBreaking = Input.GetKey(KeyCode.Space);
        if (isBreaking  && Mathf.Abs(zInput) != 0)
        {
            sound.PlaySound("brake");
        }
    }

    void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = zInput * motorForce;
        frontRightWheelCollider.motorTorque = zInput * motorForce;
        currentBreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    void ApplyBreaking()
    {
        frontLeftWheelCollider.brakeTorque = currentBreakForce;
        frontRightWheelCollider.brakeTorque = currentBreakForce;
        rearLeftWheelCollider.brakeTorque = currentBreakForce;
        rearRightWheelCollider.brakeTorque = currentBreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * yInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheel()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTrasnform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTrasnform);
    }
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pose;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pose, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pose;
    }
}
