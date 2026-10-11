using Sysyem;
namespace DeviceManage
{
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
    }
    
}