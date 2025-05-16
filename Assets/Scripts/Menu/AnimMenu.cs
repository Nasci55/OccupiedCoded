using UnityEngine;
using UnityEngine.UI;

public class AnimMenu : MonoBehaviour
{
    public Animator _anim;
    public Button button;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void MenuAnim()
    {
        _anim.SetTrigger("MenuAnim");
        button.gameObject.SetActive(false);
    }

    public void EnableOption0()
    {
        _anim.SetInteger("Option", 0);
    }

    public void EnableOption1()
    {
        _anim.SetInteger("Option", 1);
    }
    public void EnableOption2()
    {
        _anim.SetInteger("Option", 2);
    }

}
