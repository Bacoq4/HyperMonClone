using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.Movement
{
    public class ForwardMovement : MonoBehaviour
    {
        [SerializeField] private ScSwerveSettings swerveSettings;

        void Update()
        {
            float forwardMoveAmount = Time.deltaTime * swerveSettings.ForwardSpeed;

            transform.Translate(0, 0, forwardMoveAmount);
        }
    }

}
