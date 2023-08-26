namespace HttpContextMoq.Generic
{
    public interface IContextMock<TMock> where TMock : class
    {
        TMock Mock { get; }
    }
}
