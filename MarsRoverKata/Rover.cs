namespace MarsRoverKata
{
    public class Rover
    {
        private int positionY;

        public Rover()
        {
            positionY = 1;
        }

        public void ExecuteCommand(string commands)
        {
            foreach (var command in commands)
            {
                if (command == 'f')
                {
                    positionY++;
                }
            }
        }

        public override string ToString()
        {
            return $"(1,{positionY}) - N";
        }
    }
}