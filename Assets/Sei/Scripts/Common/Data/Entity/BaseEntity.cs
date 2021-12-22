namespace Sei.Common.Data.Entity
{
    public abstract class BaseEntity<T> where T : new()
    {
        private T _t;

        protected void Init(T t) => _t = t;

        public T Get() => _t;

        public void Set(T t) => _t = t;
    }
}