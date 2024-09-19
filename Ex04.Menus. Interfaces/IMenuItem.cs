namespace Ex04.Menus.Interfaces
{
    public interface IMenuItem
    {
        string GetName();
        void SetLevel(uint i_Level);
        void Invoke();
    }
}
