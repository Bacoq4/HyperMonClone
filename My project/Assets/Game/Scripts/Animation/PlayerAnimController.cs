using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoreGame.Animation
{
    public class PlayerAnimController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void setIsRunning(bool b)
        {
            animator.SetBool("isRunning",b);
        }
        public void playThrowAnim()
        {
            animator.SetTrigger("throw");
        }
    }
}