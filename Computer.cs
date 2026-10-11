using Sysyem;
namespace DeviceManage
{
    // khai báo class computer
    public class Computer : Device, INetworkable
    {
    public int RamGB { get; set; }
    public string ProcessorType { get; set; }
    public bool HasDedicatedGPU { get; set; }

    public string IpAddress { get; private set; } = "";
    public bool IsConnected => !string.IsNullOrEmpty(IpAddress);

    public Computer(
        string deviceId, string name, int yearIntroduced,
        decimal purchasePrice, int ramGB, string processorType,
        bool hasDedicatedGPU,
        DeviceStatus status = DeviceStatus.Active)
        : base(deviceId, name, yearIntroduced, purchasePrice, status)
    {
        if (ramGB <= 0)
            throw new ArgumentException("RAM phai lon hon 0.");

        if (string.IsNullOrWhiteSpace(processorType))
            throw new ArgumentException("Loai CPU khong duoc rong.");

        RamGB = ramGB;
        ProcessorType = processorType;
        HasDedicatedGPU = hasDedicatedGPU;
    }
        // các method
    public override decimal CalculateMaintenanceCost()
    {
        decimal rate = 0.05m;

        if (HasDedicatedGPU)
            rate += 0.02m;

        if (YearsUsed > 5)
            rate += 0.01m;

        return PurchasePrice * rate;
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

    public override string ToString()
    {
        return base.ToString() +
               $", RAM: {RamGB}GB, CPU: {ProcessorType}, " +
               $"GPU roi: {HasDedicatedGPU}";
    }

    }


}