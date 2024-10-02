using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperMovement : MonoBehaviour
{
    [SerializeField] private String _keyName;
    private HingeJoint2D _hingeJoint2D;
    private JointMotor2D _defaultMotor;
    private JointMotor2D _modifiedMotor;

    void Start()
    {
        _hingeJoint2D = GetComponent<HingeJoint2D>();
        _defaultMotor = _hingeJoint2D.motor;
        _modifiedMotor = _defaultMotor;
        _modifiedMotor.motorSpeed = - _modifiedMotor.motorSpeed;

        _hingeJoint2D.motor = _modifiedMotor;
    }

    void Update()
    {
        if (Input.GetKeyDown(_keyName)) {
            RotateUp();
        }
    }

    private void RotateUp()
    {
        _hingeJoint2D.motor = _defaultMotor;
        StartCoroutine(RotateDown());
    }

    private IEnumerator RotateDown()
    {
        if (_hingeJoint2D.limits.max > 0)
        {
            yield return new WaitUntil(() => _hingeJoint2D.limitState == JointLimitState2D.UpperLimit);
        }
        else
        {
            yield return new WaitUntil(() => _hingeJoint2D.limitState == JointLimitState2D.LowerLimit);
        }
        _hingeJoint2D.motor = _modifiedMotor;
    }
}
