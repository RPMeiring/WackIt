using System;

namespace Core.Interface
{
    /// <summary>
    /// interface for the npc's in the level.
    /// </summary>
    public interface IMoleHandler
    {
        void Spawn(float showDuration, Action OnFinishAnimation);
        void DeSpawn();
        void Hit();
    }
}
