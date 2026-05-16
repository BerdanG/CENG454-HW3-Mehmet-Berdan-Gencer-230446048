using System;

public static class GameEvents
{
    public static Action<int> OnCoreDamaged;

    public static Action OnCoreDestroyed;
}