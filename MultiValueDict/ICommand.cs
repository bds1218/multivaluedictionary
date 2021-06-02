namespace MultiValueDict
{
    public interface ICommand
    {
        void Execute(IMultiValueDictionary dictionary, string[] args);
    }
}
