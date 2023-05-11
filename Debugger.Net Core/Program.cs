
using System;
using DaanV2.UUID;

namespace Debugger.Net_Core {
    internal class Program {
        private static String _Folder = AppDomain.CurrentDomain.BaseDirectory;

        private static void Main(String[] args) {
            UUID UUID = UUIDFactory.CreateUUID(4, 2);
            Byte[] Adress = DaanV2.UUID.Generators.Version1.Utillity.GetMacAddressBytes();

            if (!_Folder.EndsWith("\\")) {
                _Folder += "\\";
            }

            Benchmark.TestAll(_Folder);

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
