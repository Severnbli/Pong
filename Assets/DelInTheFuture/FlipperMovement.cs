using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperMovement : MonoBehaviour
{
    private HingeJoint2D _hingeJoint2D;
    [SerializeField] private String _keyName;

    void Start()
    {
        _hingeJoint2D = GetComponent<HingeJoint2D>();
        _hingeJoint2D.useMotor = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(_keyName)) {
            RotateUp();
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ball") {
            Debug.Log("Hit a ball! " + Time.realtimeSinceStartup);
        }
    }

    private void RotateUp()
    {
        _hingeJoint2D.useMotor = true;
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
        _hingeJoint2D.useMotor = false;
    }
}
