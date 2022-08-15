using UnityEngine;

public class Block : MonoBehaviour, IDamagable
{
    public void Accept(IDamagableVisitor visitor)
    {
        visitor.Visit(this);
    }
}
