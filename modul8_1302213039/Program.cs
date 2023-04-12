using modul8_1302213039;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        BankTransferConfig tfbank = new BankTransferConfig();
        Console.Write("Pilih bahasa (id/en): ");
        string bahasa = Console.ReadLine();
        string language = bahasa;
        
        

        if (language == "id" || language == "en")
        {
            if (language == "en")
            {
                Console.Write("Please insert the amount of money to transfer: ");
            }
            else if (language == "id")
            {
                Console.Write("Masukkan jumlah uang yang akan di-transfer: ");
            }


            int jumlah = Convert.ToInt32(Console.ReadLine());
            int biaya;
            if (jumlah <= tfbank.config.transfer.threshold)
            {
                biaya = tfbank.config.transfer.low_fee;
            }
            else
            {
                biaya = tfbank.config.transfer.high_fee;
            }

            int total = jumlah + biaya;

            if (language == "en")
            {
                Console.WriteLine("Transfer fee = " + biaya);
                Console.WriteLine("Total amount = " + total);
            }
            else if (language == "id")
            {
                Console.WriteLine("Biaya transfer = " + biaya);
                Console.WriteLine("Total biaya = " + total);
            }

            if (language == "en")
            {
                Console.WriteLine("Select tranfer method:");
            }
            else if (language == "id")
            {
                Console.WriteLine("Pilih metode transfer:");
            }

            for (int i = 0; i < tfbank.config.methods.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + tfbank.config.methods[i]);
            }
            Console.WriteLine("Ketik: ");
            string metode = Console.ReadLine();

            if (language == "en")
            {
                Console.WriteLine("Please type " + tfbank.config.confirmation.en +
                    " to confirm the transaction: ");
            }
            else if (language == "id")
            {
                Console.WriteLine("Ketik " + tfbank.config.confirmation.id +
                    " untuk mengkonfirmasi transaksi: ");
            }
            string konfirmasi = Console.ReadLine();

            if (language == "en")
            {
                if (konfirmasi == tfbank.config.confirmation.en)
                {
                    Console.WriteLine("The transfer is completed");
                }
                else
                {
                    Console.WriteLine("Transfer is cancelled");
                }
            }
            else if (language == "id")
            {
                if (konfirmasi == tfbank.config.confirmation.id)
                {
                    Console.WriteLine("Proses transfer berhasil");
                }
                else
                {
                    Console.WriteLine("Transfer dibatalkan");
                }
            }
        }
        else
        {
            Console.WriteLine("Unknown language");
        }
    }
}