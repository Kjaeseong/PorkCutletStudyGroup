using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _nonBuildBlock;
    [SerializeField] private BlockManager _blockManager;
    public int SelectBlock { get; set; }
    [SerializeField] private Camera _mapCiewCam;
    private int _layerMask;
    public Vector2 BlockPosition { get; private set; }

    private void Start() 
    {
        _blockManager = GetComponentInParent<BlockManager>();
        _layerMask = 1 << LayerMask.NameToLayer("Plane");
    }

    private void Update() 
    {
        SetBlockPosition();
    }

    private void SetBlockPosition()
    {
        Ray ray = _mapCiewCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 50f, _layerMask))
        {
            BlockPosition = new Vector2(Mathf.Round(hit.point.x), Mathf.Round(hit.point.z));
            _nonBuildBlock.transform.position = new Vector3(BlockPosition.x, 0f, BlockPosition.y);
            SetPlacement();
        }
    }

    private void SetPlacement()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _blockManager.PlacementBlock(SelectBlock, BlockPosition);
        }
    }
}
