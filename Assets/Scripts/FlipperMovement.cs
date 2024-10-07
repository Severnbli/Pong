using System.Collections;
using UnityEngine;

public class FlipperMovement : MonoBehaviour
{
    private HingeJoint2D _hingeJoint2D;
    private JointMotor2D _defaultMotor;
    private JointMotor2D _modifiedMotor;

    private bool _isActive = true;
    private string _keyName;

    void Start()
    {
        if (gameObject.tag == "LeftFlipper") {
            _keyName = GameManager.getLeftPlayerKey();    
        } else if (gameObject.tag == "RightFlipper") {
            _keyName = GameManager.getRightPlayerKey();
        }

        _hingeJoint2D = GetComponent<HingeJoint2D>();

        _defaultMotor = _hingeJoint2D.motor;
        _modifiedMotor = _defaultMotor;
        _modifiedMotor.motorSpeed = - _modifiedMotor.motorSpeed;

        _hingeJoint2D.motor = _modifiedMotor;
    }

    void Update()
    {
        if (Input.GetKeyDown(_keyName) && _isActive) {
            RotateUp();
        } else if (Input.GetKeyUp(_keyName)) {
            RotateDown();
        }
    }

    private void RotateUp()
    {
        _hingeJoint2D.motor = _defaultMotor;
    }

    private void RotateDown()
    {
        _hingeJoint2D.motor = _modifiedMotor;
    }

    public void changeStatus() {
        _isActive = !_isActive;
    }
}
