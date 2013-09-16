using UnityEngine;
using System.Collections;

public class NetworkManagerScript : MonoBehaviour 
{
    /// <summary>
    /// LAN SERVER for BinaryBall
    /// </summary>
   
    #region Private Variables
    
    private static int maxPlayers = 4;
    private static bool paidVersion = false;
    private HostData[] hostData;
    #endregion
    #region Public Variables
    public GameObject playerPrefab;
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
	}
    void Update()
    {
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
        //Network.Instantiate(mainCamera, mainCamera.transform.position, Quaternion.identity, 0);
       
            Network.Instantiate(playerPrefab, spawnObject.position, Quaternion.identity, 0);
       
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
        if (msevent.Equals(MasterServerEvent.RegistrationFailedNoServer))
        {
            Debug.Log("No Server to register... please tell jamiesinn about this");
        }
        
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


            if (GUI.Button(new Rect(buttonX, buttonY, buttonW, buttonH), "Start LAN Server"))
            {
                Debug.Log("[INFO] LAN SERVER STARTED...");
                StartServer();

            }
            if (GUI.Button(new Rect(buttonX, buttonY *1.2f + buttonH, buttonW, buttonH), "Refresh LAN Hosts"))
            {
                RefreshHostList();
                Debug.Log("[INFO] REFRESHING LOCAL NETWORK SERVER LIST...");

            }

            if (hostData != null)
            {
                for (int i = 0; i > hostData.Length; i++)
                {
                    if (GUI.Button(new Rect(buttonX * 1.5f + buttonW, buttonY * 1.2f + (buttonH * i), buttonW * 3, buttonH * .5f), hostData[i].gameName))
                    {
                        Network.Connect("localhost");
                    }
                }
            }
        }
    }
 

    #endregion
}
