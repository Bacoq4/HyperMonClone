using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.Movement
{
    public class SwerveInputSetter : MonoBehaviour
    {
        private float _lastFingerPositionX;
        private float _moveDifferenceAmount;

        [SerializeField] ScSwerveInputData _swerveInput;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButton(0))
            {
                _moveDifferenceAmount = Input.mousePosition.x - _lastFingerPositionX;
                _lastFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _moveDifferenceAmount = 0;
            }

            _swerveInput.SwerveX = _moveDifferenceAmount;

        }
    }
}