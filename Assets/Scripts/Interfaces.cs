public interface IPopper<T>
{
    void BalloonPopFunc(T gameObject);
}
public interface IScore<T>
{
    short ScorePoint(T scoreChange);
}