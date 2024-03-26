using System;
using System.Collections.Generic;
using CS_Rental_Service.Entities.Enums;
using CS_Rental_Service.Entities.Exceptions;
using CS_Rental_Service.Entities.Clients;
using CS_Rental_Service.Entities.Rentals;
using CS_Rental_Service.Entities;
using System.Text;


namespace CS_Rental_Service.Entities.Registers
{
    class Car_Register : Register
    {
        public List<Car> CarList { get; set; }
        public Car_Register(string registerType) : base(registerType)
        {
            CarList = new List<Car>();
        }
        public Car_Register()
        {}

        public void AddCar(Car car)
        {
            CarList.Add(car);
        }

    
        public void RemoveCar(string licensePlate) 
        {
            CarList.Remove(FindByLicensePlate(licensePlate));
        }
        

        public Car FindByLicensePlate(string licensePlate){
            Car findedCar = new Car();
            foreach(Car car in CarList) // fix
            {
                if (car.LicensePlate == licensePlate){
                    findedCar = car;
                }
            }
            return findedCar;
        }

        public Car FindByModel(string model)
        {
            Car findedCar = new Car();
            foreach(Car car in CarList)
            {
                if (car.Model == model)
                {
                    findedCar = car;
                }
            }
            return findedCar;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Car car in CarList)
            {
                sb.AppendLine(car.ToString());
            }
            return base.ToString()
                  + "\n" + sb.ToString();
        }
    }
}