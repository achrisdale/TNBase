namespace TNBase.Domain
{
    public enum ListenerStates
    {
        ACTIVE, // listener actively received recordings
        DELETED, // listener is soft deleted awaiting for property to be returned
        PAUSED, // listener temporarily suspended from receiving recordings
        RESERVED // wallet number is reserved after listener is deleted
    }
}