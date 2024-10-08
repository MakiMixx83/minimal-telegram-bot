using System.Collections.Concurrent;

namespace MinimalTelegramBot.StateMachine;

/// <inheritdoc />
internal sealed class InMemoryUserStateRepository : IUserStateRepository
{
    private readonly ConcurrentDictionary<long, State> _states = new();

    /// <inheritdoc />
    public State? GetState(long userId)
    {
        _ = _states.TryGetValue(userId, out var state);
        return state;
    }

    /// <inheritdoc />
    public void SetState(long userId, State state)
    {
        _states.AddOrUpdate(userId, state, (_, _) => state);
    }

    /// <inheritdoc />
    public void DeleteState(long userId)
    {
        _states.TryRemove(userId, out _);
    }
}
