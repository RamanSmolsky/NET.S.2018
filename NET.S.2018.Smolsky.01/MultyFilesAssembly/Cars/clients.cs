using System;
using Car;

class Program
{
    static void Main()
    {
        Auto babyAuto = new Auto();
        babyAuto.AutoInfo();

        SportCar sportMan = new SportCar();
        sportMan.SportCarInfo();

        MiniCar styleIsEverything = new MiniCar();
        styleIsEverything.MiniCarInfo();

        Console.ReadLine();
    }
}