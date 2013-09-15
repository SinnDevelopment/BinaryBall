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
    float buttonX;
    float buttonY;
    float buttonW;
    float buttonH;
    static string serverName = "";
    static string game = "";
    static string motd = "";
    static int port = 25000;
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
        while (refreshing)
        {
            if (MasterServer.PollHostList().Length > 0)
            {
                refreshing=false;
                Debug.Log(MasterServer.PollHostList().Length + " Servers Found on LAN");
                hostData = MasterServer.PollHostList();
            }
        }
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
        
    }

    void RefreshHostList()
    {
        MasterServer.RequestHostList(game);
        refreshing = true;
                
    }

   
    void OnGui()
    {
        if (GUI.Button(new Rect(buttonX, buttonY, buttonW, buttonH), "Start LAN Server"))
        {
            Debug.Log("[INFO] LAN SERVER STARTED...");

        }
        if (GUI.Button(new Rect(buttonX, buttonY, buttonW, buttonH), "Refresh LAN Hosts"))
        {

            Debug.Log("[INFO] REFRESHING LOCAL NETWORK SERVER LIST...");

        }
        
       
            for (int i = 0; i > hostData.Length; i++)
            {
                GUI.Button(new Rect(buttonX * 1.5f + buttonW, buttonY * 1.2f + (buttonH * i), buttonW * 3, buttonH * .5f), hostData[i].gameName);
            }
       
    }

    #endregion
}
