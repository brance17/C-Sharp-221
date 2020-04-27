using System;
using System.Collections.Generic;
using System.Text;

namespace PoCos
{
    class Airplane
    {

        public string Manufacturer { get; set; }

        public int Model { get; set; }

        public string Variant { get; set; }

        public int Passengers { get; set; }

        public string Engine { get; set; }



        public Airplane(string manufacturer, int model, string variant, int passengers, string engine)
        {
            Manufacturer = manufacturer;
            Model = model;
            Variant = variant;
            Passengers = passengers;
            Engine = engine;
            
        }

        public string getManufacturer()
        {
            return Manufacturer;
        }


        public int getModel()
        {
            return Model;
        }


        public string getVariant()
        {
            return Variant;
        }


        public int getPassengers()
        {
            return Passengers;
        }

        public string getEngine()
        {
            return Engine;
        }


        public string AirplaneInfo()
        {
            return ($"Manufacturer: {getManufacturer()}\n  Model:{getModel()}\n Variant: {getVariant()}\n Capacity: {getPassengers()}\n Engine: {getEngine()}\n");

        }
