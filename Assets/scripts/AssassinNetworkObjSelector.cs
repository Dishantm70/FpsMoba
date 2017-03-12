using UnityEngine.Networking;
using UnityEngine;

public class AssassinNetworkObjSelector : NetworkBehaviour {

    [SerializeField]
    Behaviour[] ObjectsToDisable;

    [SerializeField]
    Camera Maincam;
   
    [SerializeField]
    GameObject[] ObjectsToEnable;

    // Use this for initialization
    void Start () {
        if (isLocalPlayer)
        {
            Camera.main.gameObject.SetActive(false); ;
           // Camera.main.tag = "Untagged";
            Maincam.tag = "MainCamera";
           
        }
        if (!isLocalPlayer)
        {
            Debug.Log("problem");
            Maincam.gameObject.SetActive(false);
        }
        SettingsForRemote();
    }

    void setCamera()
    {
        
    }

    void SettingsForRemote()
    {
        if (!isLocalPlayer)
        {
            int i = 0;
            for (i = 0; i < ObjectsToDisable.Length; i++)
            {
                ObjectsToDisable[i].enabled = false;
            }

            for (i = 0; i < ObjectsToEnable.Length; i++)
            {
             //   Debug.Log("enabling");
                ObjectsToEnable[i].SetActive(true);
            }
        }
    } 


    
}
