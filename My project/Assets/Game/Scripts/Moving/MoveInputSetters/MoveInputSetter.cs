using UnityEngine;

namespace CoreGame.Movement
{
    public class MoveInputSetter : MonoBehaviour
    {
        [SerializeField] private ScMoveInputData moveInputData;
        void Update()
        {
            moveInputData.Horizontal = Input.GetAxisRaw("Horizontal");
            moveInputData.Vertical = Input.GetAxisRaw("Vertical");
        }
    }
}
