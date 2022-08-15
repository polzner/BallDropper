using UnityEngine;

public class DamagableVisitor : MonoBehaviour, IDamagableVisitor
{
    [SerializeField] private BlockSpawner _blockSpawner;

    public virtual void Visit(Enemy enemy)
    {
        enemy.Disable();
        _blockSpawner.Spawn();
    }


    public virtual void Visit(Bomb bomb)
    {
        bomb.Explode(this, bomb.transform.position);
    }

    public virtual void Visit(Block block)
    {
       block.gameObject.SetActive(false);
    }
}
