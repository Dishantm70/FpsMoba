using UnityEngine;
using UnityEngine.Networking;

public class SelectorCameraController : NetworkBehaviour {
    public GameObject ass;
    public GameObject arc;

   // GameDataManager gm;

	// Use this for initialization
	void Start () {
    //    gm = GameObject.Find("GameManager").GetComponent<GameDataManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
            return;
        if (arc == null)
            Debug.Log("ooh");
        float moveh;
        bool click;
        moveh = Input.GetAxisRaw("Horizontal");
        click = Input.GetButtonDown("Fire1");
        if(click==true)
        {
            RaycastHit hit= new RaycastHit();
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit))
            {
                if(hit.transform.gameObject.name =="2")
                {
                    CmdChangeCharacter(gameObject.GetComponent<NetworkIdentity>(), 1);

                }
                if (hit.transform.gameObject.name == "1")
                {
                    CmdChangeCharacter(gameObject.GetComponent<NetworkIdentity>(), 2);


                }
            }

        }
        gameObject.transform.position += new Vector3(moveh/5, 0, 0);	
	}

    [Command]
    void CmdChangeCharacter(NetworkIdentity id, int playerNo)
    { 

        GameObject player=null;
        if(playerNo==1)
            player = ass;
        if(playerNo==2)
            player = arc;
      //  Debug.Log(":(");
        NetworkConnection conn = id.connectionToClient;
        GameObject pl = Instantiate<GameObject>(player);
        NetworkServer.ReplacePlayerForConnection(conn, pl, 0);
        Destroy(gameObject);
        Debug.Log("destroy");
    }
}
