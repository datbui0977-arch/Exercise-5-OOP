
using System;
using System.Collections.Generic;
using System.Linq;
namespace DeviceManage
{// class quản lý thiết bị
    public class LabRoom
{
    public string RoomId { get; }
    public string RoomName { get; set; }
    public int Capacity { get; }

    private readonly List<Device> devices = new List<Device>();

    public LabRoom(string roomId, string roomName, int capacity)
    {
        if (string.IsNullOrWhiteSpace(roomId))
            throw new ArgumentException("Ma phong khong duoc rong.");

        if (string.IsNullOrWhiteSpace(roomName))
            throw new ArgumentException("Ten phong khong duoc rong.");

        if (capacity <= 0)
            throw new ArgumentException("Suc chua phai lon hon 0.");

        RoomId = roomId;
        RoomName = roomName;
        Capacity = capacity;
    }

    //hàm thêm thiết bị
    public void AddDevice(Device device)
    {
        if (device == null)
            throw new ArgumentNullException(nameof(device));

        if (devices.Any(d => d.DeviceId == device.DeviceId))
            throw new InvalidOperationException("Trung ma thiet bi.");

        if (devices.Count >= Capacity)
            throw new InvalidOperationException("Phong da day.");

        devices.Add(device);
    }
    // hàm xóa thiết bị
    public bool RemoveDevice(string deviceId)
    {
        Device device = FindDevice(deviceId);

        if (device == null)
            return false;

        return devices.Remove(device);
    }
    // hàm tìm kiếm thiết bị
    public Device? FindDevice(string deviceId)
    {
        return devices.FirstOrDefault(
            d => d.DeviceId == deviceId);
    }
    // hàm tính phí bảo trì, phí bảo trì sẽ tự động tính đúng theo từng loại thiết bị khi gọi method trừu tượng tính phí, điều này thể hiện tính đa hình
    public decimal CalculateAnnualMaintenanceCost()
    {
        decimal total = 0;

        foreach (Device device in devices)
        {
            total += device.CalculateMaintenanceCost();
        }

        return total;
    }
    //hàm tìm thiết bị theo yêu cầu
    public List<Device> GetDevicesRequiringMaintenance()
    {
        return devices
            .Where(d => d.Status == DeviceStatus.UnderMaintenance
                     || d.YearsUsed > 5)
            .ToList();
    }

    public void PrintDevices()
    {
        Console.WriteLine($"\nPhong: {RoomName} ({RoomId})");

        foreach (Device device in devices)
        {
            Console.WriteLine(device);
            Console.WriteLine(
                $"  Chi phi bao tri: " +
                $"{device.CalculateMaintenanceCost():N0} VND");
        }

        Console.WriteLine(
            $"Tong chi phi: {CalculateAnnualMaintenanceCost():N0} VND");
    }

    public List<Device> GetAllDevices()
    {
        return new List<Device>(devices);
    }
}
}