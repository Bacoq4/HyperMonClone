using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.Movement
{
    [CreateAssetMenu]
    public class ScSwerveInputData : ScriptableObject
    {
        [SerializeField] private float _swerveX;

        public float SwerveX
        {
            get => _swerveX;
            set => _swerveX = value;
        }
        
    }

}
   