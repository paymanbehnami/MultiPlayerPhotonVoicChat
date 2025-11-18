using System;

public static class RoomEvents
{
    public static Action OnConnectedToServer;
    public static Action<string> OnRoomJoined;
    public static Action<string> OnRoomCreationFailed;
}
