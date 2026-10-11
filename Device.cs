
using System;
namespace DeviceManage{
public enum DeviceStatus
{
    Active,
    UnderMaintenance,
    Retired
}

public abstract class Device
{
    public string DeviceId { get; }
    public string Name { get; set; }
    public int YearIntroduced { get; set; }
    public decimal PurchasePrice { get; set; }
    public DeviceStatus Status { get; set; }

    public int YearsUsed =>
        DateTime.Now.Year - YearIntroduced;

    protected Device(
        string deviceId,
        string name,
        int yearIntroduced,
        decimal purchasePrice,
        DeviceStatus status = DeviceStatus.Active)
    {//yeu cau
        if (string.IsNullOrWhiteSpace(deviceId))
            throw new ArgumentException("Ma thiet bi khong duoc rong.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Ten thiet bi khong duoc rong.");

        if (yearIntroduced < 1 ||
            yearIntroduced > DateTime.Now.Year)
            throw new ArgumentException("Nam su dung khong hop le.");

        if (purchasePrice <= 0)
            throw new ArgumentException("Gia mua phai lon hon 0.");

        DeviceId = deviceId;
        Name = name;
        YearIntroduced = yearIntroduced;
        PurchasePrice = purchasePrice;
        Status = status;
    }

    // phương thức trừu tượng chí phí bảo trì dự kiến
    public abstract decimal CalculateMaintenanceCost();

    public override string ToString()
    {
        return $"Ma: {DeviceId}, Ten: {Name}, " +
               $"Nam su dung: {YearIntroduced}, " +
               $"Gia mua: {PurchasePrice:N0} VND, " +
               $"Trang thai: {Status}";
    }
}
}
