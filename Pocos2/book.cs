using System;
using System.Collections.Generic;
using System.Text;

namespace PoCos
{
    class Book
    {

        public string Title { get; set; }

        public string Author { get; set; }

        public int  Pages { get; set; }

        public int SKU { get; set; }

        public string Publisher { get; set; }

        public double Price { get; set; }



        public Airplane(string title, string author, int pages, int sku, string publisher, double price)
        {
            Manufacturer = manufacturer;
            Model = model;
            Variant = variant;
            Passengers = passengers;
            Engine = engine;
            
        }

        public string getTitle()
        {
            return Title;
        }


        public string getAuthor()
        {
            return Author;
        }


        public int getPages()
        {
            return Pages;
        }


        public int SKU()
        {
            return SKU;
        }

        public string getPublisher()
        {
            return Publisher;
        }

        public double getPrice()
        {
            return Price;
        }

        public string BookInfo()
        {
            return ($"Title: {getTitle()}\n  Author: {getAuthor()}\n Pages: {getPages()}\n SKU: {getSKU()}\n Publisher: {getPublisher()}\n {getPrice()}");

        }
    }
}