using System.Collections.Generic;
using Complete;
using UnityEngine;

public class TroopManager : MonoBehaviour
{
    public TankManager[] m_Tanks;
    public GameObject m_TankPrefab;
    public List<Transform> wayPointsForAI;

    private int m_TanksSpawned = 0;

    public bool SpawnItemTroopEnabled { get { return m_TanksSpawned < m_Tanks.Length; } }

    public void Spawn(int index = 0)
    {
        m_Tanks[index].m_Instance = Instantiate(original: m_TankPrefab,
                                                position: m_Tanks[index].m_SpawnPoint.position,
                                                rotation: m_Tanks[index].m_SpawnPoint.rotation) as GameObject;

        m_Tanks[index].m_PlayerNumber = index + 1;
        m_Tanks[index].SetupAI(wayPointsForAI);
        m_TanksSpawned++;
    }
}
