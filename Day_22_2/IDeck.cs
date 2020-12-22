namespace Day_22_2
{
    public interface IDeck
    {
        bool IsEmpty();
        int PullTop();
        void PushBottom(int value);
        string Fingerprint();
        IDeck Copy(int count);
        int Count();
        string Score();
    }
}