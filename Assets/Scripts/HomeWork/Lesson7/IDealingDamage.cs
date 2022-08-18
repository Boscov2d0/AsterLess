public interface IDealingDamage
{
    void Visit(AsteroidFactory hit);
    void Visit(UFOFactory hit);
    //void Visit(Knight hit, InfoCollision info);
}