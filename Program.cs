using System.IO.Packaging;

if (args.Length != 2)
{
    Console.Error.WriteLine("Expected 2 arguments: file to extract and extract location");
    return;
}

var appFile = args[0];
var extractPath = args[1];

using var packageStream = File.Open(appFile, FileMode.Open);
using var package = Microsoft.Dynamics.Nav.CodeAnalysis.Packaging.NavAppPackage.Open(packageStream, allowWrite: false);
using var content = Package.Open(package.ContentStream, FileMode.Open, FileAccess.Read);

foreach (var part in content.GetParts())
{
    Console.WriteLine("Extracting: " + part.Uri.ToString());

    var filePath = System.IO.Path.Join(extractPath, part.Uri.ToString());
    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(filePath));

    using var fileStream = File.OpenWrite(filePath);
    part.GetStream().CopyTo(fileStream);
}
