using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.Movement
{
    public class SwerveMovement : MonoBehaviour
    {
        [SerializeField] private ScSwerveInputData swerveInputData;
        [SerializeField] private ScSwerveSettings swerveSettings;

        void Update()
        {
            float swerveAmount = Time.deltaTime * swerveSettings.SwerveSpeed * swerveInputData.SwerveX;
            float forwardMoveAmount = Time.deltaTime * swerveSettings.ForwardSpeed;

            swerveAmount = Mathf.Clamp(swerveAmount, -swerveSettings.MaxSwerveAmount, swerveSettings.MaxSwerveAmount);

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, swerveSettings.PositionClampLeft, swerveSettings.PositionClampRight),
                transform.position.y,
                transform.position.z
            );

            transform.Translate(swerveAmount, 0, forwardMoveAmount);
        }
    }
}
