namespace Listy.Tests
{
    public abstract class ConcernFor<T>
    {
        protected ConcernFor()
        {
            Context();
            Subject = Given();
            When();
        }

        protected T Subject { get; private set; }

        protected virtual void Context()
        {
        }

        protected abstract T Given();

        protected virtual void When()
        {
        }
    }
}