public class PlayerModifier
{
    protected Player _player;
    protected PlayerModifier Next;
    public PlayerModifier(Player player)
    {
        _player = player;
    }
    public void Add(PlayerModifier mod)
    {
        if (Next != null)
        {
            Next.Add(mod);
        }
        else
        {
            Next = mod;
        }
    }
    public virtual void Handle() => Next?.Handle();
}