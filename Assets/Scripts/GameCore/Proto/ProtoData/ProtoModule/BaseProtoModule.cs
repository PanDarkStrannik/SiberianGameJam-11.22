namespace GameCore.Proto
{
    public abstract class BaseProtoModule
    {
        public string ModuleName => GetType().Name;
    }
}