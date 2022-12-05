using System;

public interface IMoleHandler
{
    void Spawn(float showDuration, Action OnFinishAnimation);
    void DeSpawn();
    void Hit();
}
