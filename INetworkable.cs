namespace DeviceManage{
public interface INetworkable
{
    string IpAddress { get; }
    void Connect(string ipAddress);
    void Disconnect();
    bool IsConnected { get; }
}
}
