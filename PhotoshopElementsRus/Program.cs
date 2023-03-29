using PhotoshopElementsRus.Properties;
using System;
using System.IO;


namespace PhotoshopElementsRus
{
    class Program
    {
        static string path = @"C:\Program Files\Adobe\Photoshop Elements 2021\Locales";
        static string dataPath = @"C:\ProgramData\Adobe\Photoshop Elements\19.0\Locale";

        static void Main()
        {
            Console.WriteLine(@"
 ____  _           _            _                 
|  _ \| |__   ___ | |_ ___  ___| |__   ___  _ __  
| |_) | '_ \ / _ \| __/ _ \/ __| '_ \ / _ \| '_ \ 
|  __/| | | | (_) | || (_) \__ \ | | | (_) | |_) |
|_|   |_| |_|\___/ \__\___/|___/_| |_|\___/| .__/ 
                                           |_|    
 _____ _                           _         ____   ___ ____  _   ____  _   _ 
| ____| | ___ _ __ ___   ___ _ __ | |_ ___  |___ \ / _ \___ \/ | |  _ \| | | |
|  _| | |/ _ \ '_ ` _ \ / _ \ '_ \| __/ __|   __) | | | |__) | | | |_) | | | |
| |___| |  __/ | | | | |  __/ | | | |_\__ \  / __/| |_| / __/| | |  _ <| |_| |
|_____|_|\___|_| |_| |_|\___|_| |_|\__|___/ |_____|\___/_____|_| |_| \_\\___/ 
");
            Console.WriteLine("------------------------------------------------------------------------------\n");
            Console.WriteLine("----------  ПРОГРАММА ДОЛЖНА БЫТЬ ЗАПУЩЕНА ОТ ИМЕНИ АДМИНИСТРАТОРА  ----------\n");
            Console.WriteLine("------------------------------------------------------------------------------\n");
            Console.Write("Русифицировать? (д/н) ");
            if (Console.ReadLine() == "д")
            {
                Rus();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        static void Rus()
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine($"Не удалось найти папку { path }\nНеобходимо указать вручную!");

                Console.Write("Папка: ");
                path = Console.ReadLine();
                Rus();
            }
            else
            {
                string ruPath = path + "\\ru_RU";
                string supportPath = path + "\\ru_RU\\Support Files";

                Directory.CreateDirectory(ruPath);
                File.WriteAllBytes(ruPath + "\\tw10428.dat", Resources.tw10428);

                Directory.CreateDirectory(supportPath);
                File.WriteAllBytes(supportPath + "\\BatchWin.atn", Resources.BatchWin);
                File.WriteAllBytes(supportPath + "\\Default ELTool Presets.tpl", Resources.Default_ELTool_Presets);
                File.WriteAllText(supportPath + "\\pack.inf", Resources.pack);

                Directory.CreateDirectory(dataPath + "\\ru_RU");
                File.WriteAllBytes(dataPath + "\\ru_RU\\MediaDatabase.db3", Resources.MediaDatabase);

                Console.WriteLine("Программа успешно руссифицирована!");
                Console.ReadKey();
            }
        }
    }
}
