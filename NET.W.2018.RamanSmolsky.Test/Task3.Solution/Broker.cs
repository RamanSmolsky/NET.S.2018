using System;

namespace Task3.Solution
{
    public class Broker
    {
        public string Name { get; set; }

        private Stock _stock;

        public Broker(string name, Stock stock)
        {
            this.Name = name;
            _stock = stock;
            _stock.StockUpdated += Update;
        }

        public void Update(object sender, StockUpdatedEventArgs stockInfo)
        {
            StockInfo sInfo = stockInfo.StockInfo;

            if (sInfo.USD > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
        }

        public void StopTrade()
        {
            _stock.StockUpdated -= Update;
        }
    }
}