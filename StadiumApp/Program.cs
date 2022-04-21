using StadiumApp.Data;
using StadiumApp.Models;
using System;

namespace StadiumApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StadiumData stadiumData = new StadiumData();
            string answer = "";
            string stadiumName = "";
            string hourPriceStr;
            decimal hourPrice;
            string capacityStr;
            int capacity;
            string selectedIdStr;
            int selectedId;
            bool check = true;
            while (check)
            {
                Console.WriteLine("---MENU---");
                Console.WriteLine("1.Stadion elave et\n2.Stadionlari goster\n3.Verilmish id-li stadionu goster\n4.Verilmish id-li stadionu sil\n0.Proqrami bitir");
                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        do
                        {
                            Console.WriteLine("Stadion adi daxil edin:");
                            stadiumName = Console.ReadLine();
                        } while (String.IsNullOrEmpty(stadiumName));

                        do
                        {
                            Console.WriteLine("Stadionun saatliq qiymetini:");
                            hourPriceStr = Console.ReadLine();
                        } while (!decimal.TryParse(hourPriceStr, out hourPrice));

                        do
                        {
                            Console.WriteLine("Stadionun limitini daxil edin: ");
                            capacityStr = Console.ReadLine();
                        } while (!int.TryParse(capacityStr, out capacity));

                        Stadium stadium = new Stadium
                        {
                            Name = stadiumName,
                            HourPrice = hourPrice,
                            Capacity = capacity,
                        };
                        stadiumData.Add(stadium);
                        break;


                    case "2":

                        foreach (var item in stadiumData.GetAll())
                        {
                            Console.WriteLine($"{item.Id},{item.Name},{item.HourPrice},{item.Capacity}");
                        };
                        break;


                    case "3":
                        do
                        {
                            Console.WriteLine("Id daxil edin: ");
                            selectedIdStr = Console.ReadLine();
                        } while (!int.TryParse(selectedIdStr, out selectedId));

                        Console.WriteLine(stadiumData.GetById(selectedId).Name);

                        break;
                    case "4":
                        do
                        {
                            Console.WriteLine("Silinecek Stadionun Id-i daxil edin:");
                            selectedIdStr = Console.ReadLine();
                        } while (!int.TryParse(selectedIdStr, out selectedId));

                        stadiumData.DeleteById(selectedId);

                        break;
                    case "0":
                        Console.WriteLine("Proqram bitdi.");
                        check = false;
                        break;
                    default:
                        Console.WriteLine("Duzgun deyer daxil edin:");
                        break;
                }
            }
        }
    }
}
