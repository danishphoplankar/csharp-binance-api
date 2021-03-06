﻿using BinanceAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BinanceAPI.BinanceClient;

namespace BinanceExecute
{
    class Examples
    {
        static void Main(string[] args)
        {
            
            var binanceClient = new BinanceAPI.BinanceClient();
            var binanceService = new BinanceService(binanceClient);

            //GET TICKER DEPTH
            var getDepth = binanceService.GetDepthAsync("BNBBTC");     
            Task.WaitAll(getDepth);
            dynamic depth = getDepth.Result;
            Console.WriteLine(depth);

            //GET ACCOUNT INFORMATION
            var getAccount = binanceService.GetAccountAsync();
            Task.WaitAll(getAccount);
            dynamic account = getAccount.Result;
            Console.WriteLine(account);

            //GET ORDERS FOR SYMBOL
            var getOrders = binanceService.GetOrdersAsync("BNBBTC", 100);
            Task.WaitAll(getOrders);
            dynamic orders = getOrders.Result;
            Console.WriteLine(orders);

            //GET MY TRADES
            var getMyTrades = binanceService.GetTradesAsync("WTCBTC");
            Task.WaitAll(getAccount);
            dynamic trades = getMyTrades.Result;
            Console.WriteLine(trades);

            //GET ALL PRICES
            List<Prices> prices = new List<Prices>();
            prices = binanceService.ListPrices();
            Console.WriteLine(prices);

            //GET PRICE OF SYMBOL
            double symbol = binanceService.GetPriceOfSymbol("BNBBTC");
            Console.WriteLine("Price of BNB: " + symbol);

            //PLACE BUY ORDER
            var placeBuyOrder = binanceService.PlaceBuyOrderAsync("NEOBTC", 1.00, 00.008851);
            Task.WaitAll(placeBuyOrder);
            dynamic buyOrderResult = placeBuyOrder.Result;
            Console.WriteLine(buyOrderResult);

            //PLACE SELL ORDER
            var placeSellOrder = binanceService.PlaceSellOrderAsync("NEOBTC", 1.00, 00.008851);
            Task.WaitAll(placeSellOrder);
            dynamic sellOrderResult = placeSellOrder.Result;
            Console.WriteLine(sellOrderResult);

            //TEST ORDER---------------------------------------------------------------------------
            var placeOrderTest = binanceService.PlaceTestOrderAsync("NEOBTC", "SELL", 1.00, 00.006151);
            Task.WaitAll(placeOrderTest);
            dynamic testOrderResult = placeOrderTest.Result;
            Console.WriteLine(testOrderResult);
            //-------------------------------------------------------------------------------------

            //CHECK ORDER STATUS BY ID
            var checkOrder = binanceService.CheckOrderStatusAsync("NEOBTC", 5436663);
            Task.WaitAll(checkOrder);
            dynamic checkOrderResult = checkOrder.Result;
            Console.WriteLine(checkOrderResult);

            //DELETE ORDER BY ID
            var deleteOrder = binanceService.CancelOrderAsync("NEOBTC", 5436663);
            Task.WaitAll(deleteOrder);
            dynamic deleteOrderResult = deleteOrder.Result;
            Console.WriteLine(deleteOrderResult);
        }
    }

}