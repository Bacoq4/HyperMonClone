using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.Movement
{
    [CreateAssetMenu]
    public class ScSwerveSettings : ScriptableObject
    {
        [SerializeField] private float _maxSwerveAmount;
        public float MaxSwerveAmount { get { return _maxSwerveAmount; } }

    
        [SerializeField] private float _positionClampLeft;
        public float PositionClampLeft { get { return _positionClampLeft; } }

    
        [SerializeField] private float _positionClampRight;
        public float PositionClampRight { get { return _positionClampRight; } }

    
        [SerializeField] private float _swerveSpeed;
        public float SwerveSpeed { get { return _swerveSpeed; } set { _swerveSpeed = value; } }


        [SerializeField] private float _forwardSpeed;
        public float ForwardSpeed { get { return _forwardSpeed; } set{ _forwardSpeed = value; } }

    }

}
