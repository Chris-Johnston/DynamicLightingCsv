// Generates a CSV containing X, Y, Z lamp array information for each device
// that's currently connected

using Windows.Devices.Enumeration;
using Windows.Devices.Lights;
using Windows.Foundation;

var lampArrayDevices = await DeviceInformation.FindAllAsync(LampArray.GetDeviceSelector()).AsTask();
var fileCount = 0;

foreach (var device in lampArrayDevices)
{
    var lampArray = await LampArray.FromIdAsync(device.Id);

    Console.WriteLine($"Lamp Array ID: {device.Id} has {lampArray.LampCount} lamps");

    var filename = $"lamparray.{fileCount}.csv";

    using (var file = File.OpenWrite(filename))
    using (var writer = new StreamWriter(file))
    {
        writer.WriteLine("X,Y,Z");

        for (var i = 0; i < lampArray.LampCount; i++)
        {
            var lampInfo = lampArray.GetLampInfo(i);

            writer.Write(lampInfo.Position.X);
            writer.Write(",");
            writer.Write(lampInfo.Position.Y);
            writer.Write(",");
            writer.Write(lampInfo.Position.Z);
            writer.WriteLine();
        }
    }

    Console.WriteLine($"Finished writing to {filename}");
    fileCount++;
}