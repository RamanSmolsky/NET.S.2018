using System;

namespace Task3.Solution
{
    public delegate void EventHandler<StockUpdatedEventArgs>(object source, StockUpdatedEventArgs e);

    public class StockUpdatedEventArgs: EventArgs
    {
        public StockInfo StockInfo;

        public StockUpdatedEventArgs(StockInfo stockInfo)
        {
            StockInfo = stockInfo;
        }
    }

    public class Stock
    {
        public EventHandler<StockUpdatedEventArgs> StockUpdated;

        protected virtual void OnStockUpdated(object sender, StockUpdatedEventArgs e)
        {
            StockUpdated?.Invoke(sender, e);
        }

        private StockInfo stockInfo;

        public Stock()
        {
            stockInfo = new StockInfo();
        }

        public void Market()
        {
            Random rnd = new Random();
            stockInfo.USD = rnd.Next(20, 40);
            stockInfo.Euro = rnd.Next(30, 50);

            StockUpdated(this, new StockUpdatedEventArgs(stockInfo));
        }
    }
}