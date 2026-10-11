using System;
namespace DeviceManage
{
    // khai báo class printer
    public class Printer : Device
{
    public string PrinterType { get; set; }
    public long PagesPrinted { get; set; }
    public bool IsColor { get; set; }

    // set các properties
    public Printer(
        string deviceId, string name, int yearIntroduced,
        decimal purchasePrice, string printerType,
        long pagesPrinted, bool isColor,
        DeviceStatus status = DeviceStatus.Active)
        : base(deviceId, name, yearIntroduced, purchasePrice, status)
    {
        if (printerType != "Laser" && printerType != "Inkjet")
            throw new ArgumentException("Loai may in khong hop le.");

        if (pagesPrinted < 0)
            throw new ArgumentException("So trang khong hop le.");

        PrinterType = printerType;
        PagesPrinted = pagesPrinted;
        IsColor = isColor;
    }

    // ghi đè method tính phí bảo trì
    public override decimal CalculateMaintenanceCost()
    {
        decimal cost = PurchasePrice * 0.04m;

        if (PagesPrinted > 100000)
            cost += 500000m;

        if (IsColor)
            cost += 300000m;

        return cost;
    }

    public override string ToString()
    {
        return base.ToString() +
               $", Loai may in: {PrinterType}, " +
               $"So trang: {PagesPrinted:N0}, Mau: {IsColor}";
    }
}
}