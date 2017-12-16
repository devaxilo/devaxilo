namespace DevaxiloS.Infras.Commands
{
    public class Command : ICommand
    {
        public int Id { get; private set; }

        public Command() { }

        public Command(int id)
        {
            Id = id;
        }
    }
}
