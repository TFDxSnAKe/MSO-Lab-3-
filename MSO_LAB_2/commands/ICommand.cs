namespace MSO_LAB_3.commands
{
    public interface ICommand // lets make it an interface after all 
    {
        void Execute(Player player);
        string Log(); // made this an inheritable func
    }
}
