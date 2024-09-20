using UnityEngine;

public class CheckWinCondition : MonoBehaviour
{
    public GameObject box;          // The rectangular box
    public GameObject[] blocks;     // Array of T-blocks to check

    private Collider boxCollider;   // Collider of the rectangular box

    void Start()
    {
        // Get the box's Collider component
        boxCollider = box.GetComponent<Collider>();
    }

    void Update()
    {
        // Check the win condition every frame
        if (CheckAllBlocksInsideBox())
        {
            Debug.Log("You win! All blocks are inside the box.");
            // Trigger any win logic here, like showing a UI or ending the level
        }
    }

    // Function to check if all blocks are inside the box and not touching the borders
    bool CheckAllBlocksInsideBox()
    {
        // Get the bounds of the box
        Bounds boxBounds = boxCollider.bounds;

        // Iterate through all blocks
        foreach (GameObject block in blocks)
        {
            // Get the bounds of the current block
            Collider blockCollider = block.GetComponent<Collider>();
            Bounds blockBounds = blockCollider.bounds;

            // Check if the block is within the box's bounds
            if (!IsBlockInsideBox(blockBounds, boxBounds))
            {
                // If any block is not fully inside the box, return false
                return false;
            }
        }

        // If all blocks are inside the box, return true
        return true;
    }

    // Function to check if a single block is fully inside the box's bounds
    bool IsBlockInsideBox(Bounds blockBounds, Bounds boxBounds)
    {
        // Check if the block's min and max bounds are within the box's min and max bounds
        bool insideX = blockBounds.min.x >= boxBounds.min.x && blockBounds.max.x <= boxBounds.max.x;
        bool insideY = blockBounds.min.y >= boxBounds.min.y && blockBounds.max.y <= boxBounds.max.y;
        bool insideZ = blockBounds.min.z >= boxBounds.min.z && blockBounds.max.z <= boxBounds.max.z;

        // Return true only if the block is fully inside the box in all axes
        return insideX && insideY && insideZ;
    }
}
