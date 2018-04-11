using System;
using Complete;
using UnityEngine;

public class TroopManager : MonoBehaviour
{
    public TankManager[] m_Tanks;

    private int m_TanksSpawned = 0;

    public bool SpawnItemTroopEnabled { get { return m_TanksSpawned < m_Tanks.Length; } }

    public void Spawn(int index = 0)
    {
        m_Tanks[index].m_Instance = Instantiate(original: m_Tanks[index].m_TankPrefab,
                                                position: m_Tanks[index].m_SpawnPoint.position,
                                                rotation: m_Tanks[index].m_SpawnPoint.rotation) as GameObject;

        m_Tanks[index].m_PlayerNumber = index + 1;
        m_Tanks[index].SetupAI();
        m_TanksSpawned++;
    }

    internal void Spawn(object v)
    {
        throw new NotImplementedException();
    }
}
