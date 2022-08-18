using UnityEngine;

public class Drift : State
{

    public override void Movement(Player player) 
    {
        player.Rigidbody.drag = 0;
        Debug.Log(player.Rigidbody.drag);
    }
}