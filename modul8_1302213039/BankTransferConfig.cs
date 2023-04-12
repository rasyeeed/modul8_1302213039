using modul8_1302213039;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_1302213039
{
    public class BankTransferConfig
    {
        public BankTransfer config;

        private const string filePath = "C:\\Telkom\\Semester 4\\KPL\\modul8_1302213039\\";
        private const string fileLocation = filePath + "bank_transfer_config.json";

        public BankTransferConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }

        private BankTransfer ReadConfigFile()
        {
            string hasilBaca = File.ReadAllText(fileLocation);
            config = JsonSerializer.Deserialize<BankTransfer>(hasilBaca);
            return config;
        }

        private void SetDefault()
        {
            string lang = "id";
            Transfer transfer = new Transfer(1000000, 6500, 19500);
            List<string> methods = new List<string>();
            methods.Add("RTO (real-time)");
            methods.Add("SKN");
            methods.Add("RTGS");
            methods.Add("BI FAST");
            Confirmation confirmation = new Confirmation("yes", "ya");
            config = new BankTransfer(lang, transfer, methods, confirmation);
        }
        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };

            string textTulis = JsonSerializer.Serialize(config, options);
            File.WriteAllText(fileLocation, textTulis);
        }
    }
}