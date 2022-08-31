using UnityEngine;
public class GroundCheck : MonoBehaviour
{
    public float distanceToCheck=0.1f;
    public bool isGrounded=true;
    private void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, distanceToCheck))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}