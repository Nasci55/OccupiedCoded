using UnityEngine;

public class AnimMenu : MonoBehaviour
{
    public Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void MenuAnim()
    {
        _anim.SetTrigger("MenuAnim");
    }
}
