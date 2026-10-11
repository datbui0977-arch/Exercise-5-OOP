
using System;
using System.Collections.Generic;
namespace DeviceManage
{
class Program
{
    static void Main()
    {
        // 1. Tao thiet bi
        Computer c1 = new Computer(
            "PC01", "May tinh 1", 2019, 20000000m,
            16, "Intel Core i5", false);

        Computer c2 = new Computer(
            "PC02", "May tinh 2", 2024, 30000000m,
            32, "Intel Core i7", true);

        Printer p1 = new Printer(
            "PR01", "May in laser", 2023, 5000000m,
            "Laser", 120000, false);

        NetworkPrinter p2 = new NetworkPrinter(
            "PR02", "May in mang mau", 2025, 8000000m,
            "Inkjet", 20000, true);

        Projector pj1 = new Projector(
            "PJ01", "May chieu", 2018, 15000000m,
            4000, 4000);

        // 2. Tao hai phong
        LabRoom room1 = new LabRoom("R01", "Phong may 1", 4);
        LabRoom room2 = new LabRoom("R02", "Phong may 2", 4);

        // 3. Them thiet bi vao phong
        room1.AddDevice(c1);
        room1.AddDevice(c2);
        room1.AddDevice(p1);

        room2.AddDevice(p2);
        room2.AddDevice(pj1);

        // 4. Thu them thiet bi trung ma
        try
        {
            Computer duplicate = new Computer(
                "PC01", "May tinh trung ma", 2025,
                10000000m, 8, "Intel Core i3", false);

            room1.AddDevice(duplicate);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Loi: " + ex.Message);
        }

        // 5. In danh sach va tinh chi phi bao tri
        room1.PrintDevices();
        room2.PrintDevices();

        // 6. Liet ke thiet bi can bao tri
        Console.WriteLine("\nTHIET BI CAN BAO TRI:");

        foreach (Device device in room1.GetDevicesRequiringMaintenance())
            Console.WriteLine(device.DeviceId + " - " + device.Name);

        foreach (Device device in room2.GetDevicesRequiringMaintenance())
            Console.WriteLine(device.DeviceId + " - " + device.Name);

        // 7. Ket noi mang qua interface
        Console.WriteLine("\nKET NOI MANG:");

        List<INetworkable> networkDevices =
            new List<INetworkable> { c1, c2, p2 };

        int index = 1;

        foreach (INetworkable device in networkDevices)
        {
            device.Connect($"192.168.1.{index + 10}");

            Console.WriteLine(
                $"IP: {device.IpAddress}, " +
                $"Da ket noi: {device.IsConnected}");

            index++;
        }

        // 8. Ngat ket noi
        foreach (INetworkable device in networkDevices)
        {
            device.Disconnect();
            Console.WriteLine(
                $"Sau khi ngat ket noi: {device.IsConnected}");
        }
    }
}
}
