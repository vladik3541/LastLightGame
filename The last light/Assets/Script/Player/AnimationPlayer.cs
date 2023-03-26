using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Walk(float value) => animator.SetFloat("Walk", value);

    public void JumpAnim(bool value) => animator.SetBool("Jump", value);
    public void EnterAnim(bool value) => animator.SetBool("Enter", value);

    public void NoLight(bool value) => animator.SetBool("NoLight", value);

    public void UnderLamp(bool value) => animator.SetBool("Coma", value);//under the lamp

    //Enter
    public void EnterAnim() => animator.SetTrigger("Enter");

    //FirstTime
    public void GetsUpAnim(bool value) => animator.SetBool("FirstTime", value);
    //DeathFrom..
    public void Nip() => animator.SetTrigger("DeathFromNip");
    public void Trap() => animator.SetTrigger("Trap");
    public void Spikes() => animator.SetTrigger("DeathSpikes");
    public void Eue() => animator.SetTrigger("DeathEue");
}
