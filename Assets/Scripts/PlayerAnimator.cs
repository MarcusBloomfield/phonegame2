using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] FixedJoystick fixedJoystick;

    private void Update()
    {
        if (fixedJoystick.Direction.x != 0 && fixedJoystick.Direction.y != 0)
        {
            animator.SetFloat("Blend", 1);
        }
        else
        {
            animator.SetFloat("Blend", 0);
        }
    }
    public void Chop()
    {
        animator.Play("Chop", -1 ,0f);
    }
    public void PickUp()
    {
        animator.Play("Pick Up", -1, 0f);
    }
}
