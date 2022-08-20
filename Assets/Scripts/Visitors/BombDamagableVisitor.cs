using UnityEngine;

public class BombDamagableVisitor : MonoBehaviour, IDamagableVisitor
{
    public void Visit(Enemy enemy)
    {
        enemy.Disable();
    }

    public void Visit(Bomb bomb)
    {
    }

    public void Visit(Block block)
    {
        block.gameObject.SetActive(false);
    }
}
