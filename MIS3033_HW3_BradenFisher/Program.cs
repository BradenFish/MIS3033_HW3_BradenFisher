// MIS 3033 HW 3
// Braden Fisher, 113492081
using a;
using System.Buffers.Text;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("HW3");

string menuStr;
menuStr = @"
Option Menu
1. Add a new receipt
2. Show all receipts
3. Show receipt based on a receipt ID
4. Edit a receipt based on a receipt ID
5. Delete a receipt based on a receipt ID
6. Show the receipt with the highest total
7. Show the average total of all receipts
Press other keys to exit...
";


ReceiptDB db = new ReceiptDB();

while (true)
{
    Console.WriteLine(menuStr);
    Console.Write("Input your option:");

    string userInputStr;
    userInputStr = Console.ReadLine();

    if (userInputStr == "1")
    {
        Console.WriteLine("Add a new receipt");

        Console.WriteLine("Receipt ID: ");
        string inputStr;
        inputStr = Console.ReadLine();
        string receiptID = inputStr;

        Console.Write("N Cogs: ");
        inputStr = Console.ReadLine();  
        int nCogs = Convert.ToInt32(inputStr);

        Console.Write("N Gears: ");
        inputStr = Console.ReadLine();
        int nGears = Convert.ToInt32(inputStr);

        Receipt r = new Receipt() { ReceiptID = receiptID, CogQuantity = nCogs, GearQuantity = nGears};
        r.CalculateTotal();

        db.receiptTbl.Add(r);
        db.SaveChanges();
        Console.WriteLine(r);


    }
    else if (userInputStr == "2")
    {
        // method 1
        // var r = db.receiptTbl; // collection
        // foreach (Receipt receipt in r)
        // {
        //     Console.WriteLine(receipt);
        // }

        // method 2
        var r = db.receiptTbl.ToList();
        for (int i = 0; i < r.Count; i++)
        {
            Console.WriteLine(r[i]);
        }
    }
    else if (userInputStr == "3")
    {
        Console.WriteLine("Show receipt based on a receipt ID");
        Console.WriteLine("Receipt ID: ");
        string rIDStr;
        rIDStr = Console.ReadLine();

        var r = db.receiptTbl.Where(x => x.ReceiptID == rIDStr).FirstOrDefault(); // collection
        if (r == null)
        {
            Console.WriteLine($"Receipt {rIDStr} does not exist in the database");
        }
        else
        {
            Console.WriteLine(r);
        }
    }
    else if (userInputStr == "4")
    {
        Console.WriteLine("Edit receipt based on receipt ID");
        Console.Write("Input receipt ID: ");
        string rIDStr = Console.ReadLine();

       Receipt r = db.receiptTbl.Where(x => x.ReceiptID == rIDStr).FirstOrDefault(); // [] collection
        if (r == null)
        {
            Console.WriteLine($"Receipt {rIDStr} does not exist in the database");
        }
        else
        {
            Console.Write ("N Cogs: ");
            string nCogStr = Console.ReadLine();
            int nCogsNew = Convert.ToInt32(nCogStr);

            Console.Write("N Gears: ");
            string nGearStr = Console.ReadLine();
            int nGearNew = Convert.ToInt32(nGearStr);

            r.CogQuantity = nCogsNew;
            r.GearQuantity = nGearNew;

            r.CalculateTotal();

            db.SaveChanges();

            Console.WriteLine("The new receipt is: ");
            Console.WriteLine(r);
        }
    }
    else if (userInputStr == "5")
    {
        Console.WriteLine("Delete a receipt based on receipt ID");
        Console.Write("Input receipt ID: ");
        string rIDStr = Console.ReadLine();

        Receipt r1 = db.receiptTbl.Where(s => s.ReceiptID == rIDStr).FirstOrDefault();

        if (r1 == null)
        {
            Console.WriteLine($"The receipt ID {rIDStr} does not exist in the database");
        }
        else
        {
            db.receiptTbl.Remove(r1);
            db.SaveChanges();

            Console.WriteLine($"The receipt {rIDStr} has been deleted successfully");
            Console.WriteLine(r1);
        }

    }
    else if (userInputStr == "6")
    {
        Console.WriteLine("Show the receipt with the highest total: ");
        Receipt r2 = db.receiptTbl.ToList().MaxBy(x => x.Total);
        Console.WriteLine(r2);
    }
    else if (userInputStr == "7")
    {
        Console.WriteLine("Show the average of all receipts: ");
        double r3 = db.receiptTbl.Average(x => x.Total);
        Console.WriteLine($"{r3:C2}");
    }
    else
    {
        Console.WriteLine("Thank you for using this system, goodbye!");
        break;
    }
}
