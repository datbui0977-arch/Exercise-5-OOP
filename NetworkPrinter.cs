using System;
namespace DeviceManage
{
    public class NetworkPrinter : Printer, INetworkable
{
    public string IpAddress { get; private set; } = "";
    public bool IsConnected => !string.IsNullOrEmpty(IpAddress);

    public NetworkPrinter(
        string deviceId, string name, int yearIntroduced,
        decimal purchasePrice, string printerType,
        long pagesPrinted, bool isColor,
        DeviceStatus status = DeviceStatus.Active)
        : base(deviceId, name, yearIntroduced, purchasePrice,
               printerType, pagesPrinted, isColor, status)
    {
    }

    public void Connect(string ipAddress)
    {
        if (IsConnected)
            throw new InvalidOperationException("Thiet bi dang ket noi.");

        if (string.IsNullOrWhiteSpace(ipAddress))
            throw new ArgumentException("IP khong duoc rong.");

        IpAddress = ipAddress;
    }

    public void Disconnect()
    {
        IpAddress = "";
    }
}
}