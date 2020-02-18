using System;

namespace ModelLibrary
{
    public class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public string RegisterNumber { get; set; }

        public override string ToString()
        {
            return "Model: "+ Model+ " Color: "+ Color + " Reg Number: " + RegisterNumber;
        }
    }
}
