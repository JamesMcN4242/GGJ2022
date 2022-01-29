public class ResetTimer
{
    private float k_maxTime;
    private float m_timeRemaining;

    public ResetTimer(float levelTimeInSeconds)
    {
        m_timeRemaining = k_maxTime = levelTimeInSeconds;
    }

    public bool HasTimeLeft => m_timeRemaining > 0.0f;

    public float PortionRemaining => m_timeRemaining / k_maxTime;

    public void UpdateTime(float dt)
    {
        m_timeRemaining -= dt;
    }
}