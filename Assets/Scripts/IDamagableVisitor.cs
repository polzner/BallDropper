
public interface IDamagableVisitor
{
    void Visit(Enemy enemy);
    void Visit(Bomb bomb);
    void Visit(Block block);
}