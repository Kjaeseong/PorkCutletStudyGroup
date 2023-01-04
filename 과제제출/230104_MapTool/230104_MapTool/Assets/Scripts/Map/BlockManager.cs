using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlockManager : MonoBehaviour
{
    private enum Block
    {
        BUSH, WALL, WATER
    }

    [Serializable] public class BlockGroup
    {
        [field: SerializeField] public GameObject BlockPrefab { get; private set; }
        [field: SerializeField] public int PoolSize { get; private set; }
        public List<GameObject> Pool { get; set; }
    }
    
    [field: SerializeField] public BlockGroup[] Group { get; private set; }
    public GameObject[,] PlacementBlockArr { get; private set; }

    private void Start() 
    {
        PlacementBlockArr = new GameObject[20, 20];

        for(int i = 0; i < Group.Length; i++)
        {
            CreatePool(Group[i]);
        }
    }

    private void CreatePool(BlockGroup Group)
    {
        Group.Pool = new List<GameObject>();
        for(int i = 0; i < Group.PoolSize; i++)
        {
            Group.Pool.Add(Instantiate(Group.BlockPrefab));
            Group.Pool[i].transform.parent = transform;
            DeactivateBlock(Group.Pool[i]);
        }
    }

    public void DeactivateBlock(GameObject Block)
    {
        Block.transform.position = new Vector3(0f, 0f, 0f);
        Block.SetActive(false);
    }

    public void PlacementBlock(int GroupNum, Vector2 Position)
    {
        if(PlacementBlockArr[(int)Position.x, (int)Position.y] != null)
        {
            DeactivateBlock(PlacementBlockArr[(int)Position.x, (int)Position.y]);
        }

        for(int i = 0; i < Group[GroupNum].Pool.Count; i++)
        {
            if(!Group[GroupNum].Pool[i].activeSelf)
            {
                PlacementBlockArr[(int)Position.x, (int)Position.y] = Group[GroupNum].Pool[i];
                Group[GroupNum].Pool[i].transform.position = new Vector3(Position.x, 0f, Position.y);
                Group[GroupNum].Pool[i].SetActive(true);
                break;
            }
        }
    }
}