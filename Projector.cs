
using System;
namespace DeviceManage
{
    

public class Projector : Device
{
    public int BrightnessLumens { get; set; }
    public int LampHoursUsed { get; set; }

    public Projector(
        string deviceId, string name, int yearIntroduced,
        decimal purchasePrice, int brightnessLumens,
        int lampHoursUsed,
        DeviceStatus status = DeviceStatus.Active)
        : base(deviceId, name, yearIntroduced, purchasePrice, status)
    {
        if (brightnessLumens <= 0)
            throw new ArgumentException("Do sang phai lon hon 0.");

        if (lampHoursUsed < 0)
            throw new ArgumentException("So gio su dung khong hop le.");

        BrightnessLumens = brightnessLumens;
        LampHoursUsed = lampHoursUsed;
    }

    // tính phí bảo trì
    public override decimal CalculateMaintenanceCost()
    {
        decimal cost = PurchasePrice * 0.03m;

        if (LampHoursUsed > 3000)
            cost += 1500000m;

        return cost;
    }

    public override string ToString()
    {
        return base.ToString() +
               $", Do sang: {BrightnessLumens} lumen, " +
               $"Gio bong den: {LampHoursUsed}";
    }
}
}
