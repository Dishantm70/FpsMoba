using UnityEngine;
using UnityEngine.Networking;
public class AssassinUpDownLook : NetworkBehaviour {
    Animator anim;
    float mousepos = 0;
    float Prev = 0.5f;
    public float mouseSensitivity = .1f;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;
        mousepos = Input.GetAxis("Mouse Y") * mouseSensitivity;
        Debug.Log(mousepos);
        Prev += mousepos;
        Prev = Mathf.Clamp(Prev, 0, 1);
        anim.SetFloat("LookAngle", Prev);

    }
}
