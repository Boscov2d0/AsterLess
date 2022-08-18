using UnityEngine;
public class ControlFliying : State
{
    public override void Movement(Player player) 
    {
        player.Rigidbody.drag = 10;
        Debug.Log(player.Rigidbody.drag);
    }
}