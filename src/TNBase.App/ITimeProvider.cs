using System;

namespace TNBase.App;

public interface ITimeProvider
{
    DateTime UtcNow { get; }
}