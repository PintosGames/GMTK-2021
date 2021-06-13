using UnityEngine;

public class SwitchText : MonoBehaviour
{
    public void OnAnimationDone()
    {
        GetComponent<Animator>().SetBool("anim", false);
    }
}
