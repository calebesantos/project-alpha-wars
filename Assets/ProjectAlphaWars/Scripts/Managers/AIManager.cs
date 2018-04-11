using Complete;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    //public GameObject[] m_TankPrefabs;
    //public TankManager[] m_Tanks;
    //public List<Transform> wayPointsForAI;
    public BaseManager m_base;

    private GameManager gameManager;
    private CameraControl cameraControl;
    private TroopManager troopManager;

    #region unity methods

    void Start()
    {
        loadVariables();
    }

    private void loadVariables()
    {
        troopManager = gameObject.GetComponent<TroopManager>();
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager)
            cameraControl = gameManager.m_CameraControl;
    }

    void Update()
    {
        SpawnNewItemTroop();
    }

    /// <summary>
    /// Lógica para se deverá iniciar um novo item de tropa e qual será selecionado
    /// - Avaliar se é possível ainda enviar mais alguém da tropa
    /// Se a base já tem alguém instanciando
    /// </summary>
    private void SpawnNewItemTroop()
    {
        Debug.Log("Enter");
        if (!troopManager.SpawnItemTroopEnabled || m_base.Busy)
            return;

        Debug.Log("Pass");
        troopManager.Spawn();
    }

    #endregion


    private void SetCameraTargets()
    {
        //// Create a collection of transforms the same size as the number of tanks.
        //Transform[] targets = new Transform[m_Tanks.Length];

        //// For each of these transforms...
        //for (int i = 0; i < targets.Length; i++)
        //{
        //    // ... set it to the appropriate tank transform.
        //    targets[i] = m_Tanks[i].m_Instance.transform;
        //}

        //// These are the targets the camera should follow.
        //cameraControl.m_Targets = targets;
    }


    private void SpawnAllTanks()
    {
        //// Setup the AI tanks
        //for (int i = 0; i < m_Tanks.Length; i++)
        //{
        //    // ... create them, set their player number and references needed for control.
        //    m_Tanks[i].m_Instance =
        //        Instantiate(m_TankPrefabs[i], m_Tanks[i].m_SpawnPoint.position, m_Tanks[i].m_SpawnPoint.rotation) as GameObject;
        //    m_Tanks[i].m_PlayerNumber = i + 1;
        //    m_Tanks[i].SetupAI(wayPointsForAI);
        //}
    }
}
