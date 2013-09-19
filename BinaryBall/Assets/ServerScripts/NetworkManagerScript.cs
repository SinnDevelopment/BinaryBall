using UnityEngine;
using System.Collections;

public class NetworkManagerScript : MonoBehaviour 
{
    /// <summary>
    /// LAN SERVER for BinaryBall
    /// </summary>
   
    #region Private Variables
    
    private static int maxPlayers = 40;
    private static bool paidVersion = false;
    private HostData[] hostData;
    #endregion
    #region Public Variables
    public GameObject playerPrefab;
    public Vector3 cameraoffset;
    public Transform spawnObject;
    public Camera mainCamera;
    float buttonX;
    float buttonY;
    float buttonW;
    float buttonH;
    public string serverName = "";
    public string game = "";
    public string motd = "";
    public int port = 25000;
    bool refreshing = false;
    #endregion
    #region Private Methods and Functions
    private void GetVersion()
    {
        
        if (paidVersion)
        {
            game = "SERVER_LAN_P";
            maxPlayers = 32;
            serverName = "BinaryBall LAN Server [P] ";
        }
        else
        {
            game = "SERVER_LAN_NP";
            maxPlayers = 4;
            serverName = "BinaryBall LAN Server [NP] ";
        }
    }

    #endregion

    #region Public Methods/Functions
    void Start () 
    {
        buttonH = Screen.width * 0.1f;
        buttonW = Screen.width * 0.1f;
        buttonX = Screen.width * 0.05f;
        buttonY = Screen.width * 0.05f;
        //playerPrefab = CameraBehaviourScript.targetplayer;
	}
    void Update()
    {
        cameraoffset = mainCamera.transform.position;
        if (refreshing)
        {
            if (MasterServer.PollHostList().Length > 0)
            {
                refreshing=false;
                Debug.Log(MasterServer.PollHostList().Length + " Servers Found on LAN");
                hostData = MasterServer.PollHostList();
            }
        }
    }
    void OnServerInitialized()
    {
        Debug.Log("[INFO] SERVER INIT COMPLETE");
        SpawnPlayer();
    }
    void OnConnectedToServer()
    {
        SpawnPlayer();
    }
    void SpawnPlayer()
    {

       // Network.Instantiate(mainCamera, playerPrefab.transform.position +cameraoffset , Quaternion.identity, 1);

        Network.Instantiate(playerPrefab, Vector3.up * 5, Quaternion.identity, 0);
       
    }
    void StartServer()
    {
        Network.InitializeServer(maxPlayers, port, !Network.HavePublicAddress());
        MasterServer.RegisterHost(game, serverName, motd);

    }
    void OnMasterServerEvent(MasterServerEvent msevent)
    {
        if (msevent.Equals(MasterServerEvent.RegistrationSucceeded))
        {
            Debug.Log("Server Registered Successfully");
            
        }
        if (msevent == MasterServerEvent.HostListReceived)
            hostData = MasterServer.PollHostList();
        
        
    }

    void RefreshHostList()
    {
        MasterServer.RequestHostList(game);
        refreshing = true;
                
    }


    void OnGUI()
    {
        if (!Network.isClient && !Network.isServer)
        {
            if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
            {
                StartServer();
            }

            if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts"))
            {
                RefreshHostList();

            }

            if (hostData != null)
            {
                for (int i = 0; i < hostData.Length; i++)
                {
                    if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostData[i].gameName))
                    {
                        JoinServer(hostData[i]);
                    }
                }
            }
        }
    }
    private void JoinServer(HostData hostData)
    {
        Network.Connect(hostData);
    }
 

    #endregion
}
