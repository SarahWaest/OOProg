﻿namespace SOLID.IoC.No
{
    public abstract class Animal : IAnimal
    {
        public abstract void Act();

        public bool FoodAround(string food)
        {
            return true;
        }
    }
}