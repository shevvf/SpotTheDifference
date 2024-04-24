namespace Difference.Infrastructure.AbstractStateMachine.States
{
    public interface IEnterParam : IExitable
    {
        void EnterParam(object param);
    }
}