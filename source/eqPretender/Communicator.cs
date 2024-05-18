namespace eqPretender
{
    //Interface
    public interface ICommunication
    {
        void Initialize(string port);
        string SendAndReceive(string message);
        void abort();
    }

    public class Communicator
    {
        private ICommunication communication;
        private bool valid;

        //For search only
        public Communicator(string cType)
        {
            switch (cType.ToUpper())
            {
                case "N":
                    SetCommunicationMode(new UdpCommunication());
                    break;
                case "S":
                    SetCommunicationMode(new SerialCommunication());
                    break;
                default:
                    valid = false;
                    break;
            }
        }

        public Communicator(string cType, string connection)
        {
            valid = true;
            switch (cType.ToUpper())
            {
                case "N":
                    SetCommunicationMode(new UdpCommunication());
                    break;
                case "S":
                    SetCommunicationMode(new SerialCommunication());
                    break;
                default:
                    valid = false;
                    break;
            }
            Initialize(connection);
        }
        private void SetCommunicationMode(ICommunication communication)
        {
            this.communication = communication;
        }
        private void Initialize(string connection)
        {
            communication.Initialize(connection);
        }
        public string SendAndReceive(string message)
        {
            if (!valid) return ("ERROR\r");
            return communication.SendAndReceive(message);
        }
        public void abort()
        {
            communication.abort();
        }
    }
}
